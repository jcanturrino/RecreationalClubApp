using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;


namespace Configurations.BaseLogic
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        protected BaseRepository(DbContext context, IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<IOperationResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            return await IOperationResult<IEnumerable<TEntity>>.TryExecuteAsync(async () =>
            {
                return await _context.Set<TEntity>().ToListAsync();
            });
        }

        public async Task<IOperationResult<TEntity>> GetByIdAsync(int id)
        {
            return await IOperationResult<TEntity>.TryExecuteAsync(async () =>
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                    throw new Exception("Entidad no encontrada");
                return entity;
            });
        }

        public async Task<IOperationResult<IEnumerable<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();
            var data = await context.Set<TEntity>().Where(predicate).ToListAsync();
            return IOperationResult<IEnumerable<TEntity>>.SuccessResult(data, "Consulta exitosa");
        }

        public async Task<IOperationResult<bool>> AddAsync(TEntity entity)
        {
            return await IOperationResult<bool>.TryExecuteAsync(async () =>
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            });
        }

        public async Task<IOperationResult<bool>> UpdateAsync(TEntity entity)
        {
            return await IOperationResult<bool>.TryExecuteAsync(async () =>
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            });
        }

        public async Task<IOperationResult<bool>> DeleteAsync(TEntity entity)
        {
            return await IOperationResult<bool>.TryExecuteAsync(async () =>
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            });
        }

        public async Task<IOperationResult<TEntity>> AddAndReturnAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return IOperationResult<TEntity>.SuccessResult(entity, "Entidad insertada con éxito");
        }
    }
}
