
using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using System.Linq.Expressions;
namespace Configurations.BaseLogic
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly ITokenRepository _tokenRepository;
        protected readonly string _jwtSecret;

        protected BaseService(IRepository<TEntity> repository, ServiceConfiguration serviceConfiguration)
        {
            _repository = repository;
            _tokenRepository = serviceConfiguration.TokenRepository;
            _jwtSecret = serviceConfiguration.JwtSecret;
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

        protected async Task<IOperationResult<Tokens>> GenerateJwtTokenAsync(string username, int usuarioId)
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
            var tokenString = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            var expiryDate = DateTime.UtcNow.AddHours(1);

            var tokenEntity = new Tokens
            {
                UsuarioId = usuarioId,
                Token = tokenString,
                RefreshToken = refreshToken,
                ExpiryDate = expiryDate,
                FechaCreacion = DateTime.UtcNow,
                FechaUltimaModificacion = DateTime.UtcNow
            };

            var result = await _tokenRepository.AddAndReturnAsync(tokenEntity);
            return IOperationResult<Tokens>.SuccessResult(result.Data, "Token generado con éxito");
        }


        public async Task<IOperationResult<TEntity>> AddAndReturnAsync(TEntity entity)
        {
            return await _repository.AddAndReturnAsync(entity);
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
