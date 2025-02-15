using Configurations.BaseReturn.Interface;
using Configurations.JWT;

namespace Configurations.BaseInterface
{
    public interface ITokenService : IBaseService<Tokens>
    {
        Task<IOperationResult<string>> GenerateTokenAsync(int usuarioId);
        Task<IOperationResult<string>> RefreshTokenAsync(string refreshToken);
        void ValidateToken(string token, string accion);
    }
}
