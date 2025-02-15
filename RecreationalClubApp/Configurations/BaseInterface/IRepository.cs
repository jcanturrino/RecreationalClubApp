using Configurations.BaseReturn.Interface;
using System.Linq.Expressions;
namespace Configurations.BaseInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IOperationResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<IOperationResult<TEntity>> GetByIdAsync(int id);
        Task<IOperationResult<IEnumerable<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IOperationResult<bool>> AddAsync(TEntity entity);
        Task<IOperationResult<bool>> UpdateAsync(TEntity entity);
        Task<IOperationResult<bool>> DeleteAsync(TEntity entity);
        Task<IOperationResult<TEntity>> AddAndReturnAsync(TEntity entity);
    }
}
