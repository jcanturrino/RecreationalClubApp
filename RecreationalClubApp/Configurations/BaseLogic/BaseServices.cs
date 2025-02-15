
using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using System.Linq.Expressions;
namespace Configurations.BaseLogic
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly string _jwtSecret;

        protected BaseService(IRepository<TEntity> repository, string jwtSecret)
        {
            _repository = repository;
            _jwtSecret = jwtSecret;
        }

        public async Task<IOperationResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IOperationResult<TEntity>> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IOperationResult<IEnumerable<TEntity>>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task<IOperationResult<bool>> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<IOperationResult<bool>> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<IOperationResult<bool>> DeleteAsync(int id)
        {
            var entityResult = await _repository.GetByIdAsync(id);
            if (!entityResult.Success) return IOperationResult<bool>.ErrorResult("Entidad no encontrada");
            return await _repository.DeleteAsync(entityResult.Data);
        }

        protected string GenerateJwtToken(string username)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, username)
                }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
