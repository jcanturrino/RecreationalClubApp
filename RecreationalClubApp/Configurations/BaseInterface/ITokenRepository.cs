using Configurations.BaseReturn.Interface;
using Configurations.JWT;


namespace Configurations.BaseInterface
{
    public interface ITokenRepository : IRepository<Tokens>
    {
        Task<IOperationResult<string>> GenerateTokenAsync(int usuarioId);
        Task<IOperationResult<string>> RefreshTokenAsync(string refreshToken);
        void ValidateToken(string token, string secret, string accion);
    }
}
