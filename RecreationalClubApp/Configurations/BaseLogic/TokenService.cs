using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using Entities;

namespace Configurations.BaseLogic
{

    public class TokenService : BaseService<Tokens>, ITokenService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        public TokenService(IRepository<Tokens> repository, ServiceConfiguration serviceConfiguration, IRepository<Usuario> usuarioRepository) : base(repository, serviceConfiguration)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<IOperationResult<string>> GenerateTokenAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId); // Asume que hay un método para encontrar al usuario
            if (usuario == null)
                return IOperationResult<string>.ErrorResult("Usuario no encontrado");

            var tokenEntity = await GenerateJwtTokenAsync(usuario.Data.NombreUsuario, usuario.Data.Id);
            return IOperationResult<string>.SuccessResult(tokenEntity.Data.Token, "Token generado con éxito");
        }

        public async Task<IOperationResult<string>> RefreshTokenAsync(string refreshToken)
        {
            var tokenEntity = await _repository.FindAsync(t => t.RefreshToken == refreshToken);
            var token = tokenEntity.Data.FirstOrDefault();
            if (token == null || token.ExpiryDate <= DateTime.UtcNow)
                return IOperationResult<string>.ErrorResult("Refresh token inválido o expirado");

            var newToken = await GenerateJwtTokenAsync(token.Usuario.NombreUsuario, token.UsuarioId);
            token.Token = newToken.Data.Token;
            token.ExpiryDate = newToken.Data.ExpiryDate;

            await _repository.UpdateAsync(token);
            return IOperationResult<string>.SuccessResult(newToken.Data.Token, "Token renovado con éxito");
        }

        private async Task<Tokens> GenerateJwtTokenAsync(string username, int usuarioId, string jwtSecret)
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

            await _repository.AddAsync(tokenEntity);
            return tokenEntity;
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
