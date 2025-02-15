using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.BaseReturn.Interface;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(IRepository<Usuario> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        { }

        public async Task<IOperationResult<string>> AuthenticateAsync(string username, string password)
        {
            var usuario = await _repository.FindAsync(u => u.NombreUsuario == username && u.Contrasena == password);
            var user = usuario.Data.FirstOrDefault();
            if (user == null) return IOperationResult<string>.ErrorResult("Autenticación fallida");

            var tokenString = GenerateJwtToken(username);
            return IOperationResult<string>.SuccessResult(tokenString, "Autenticación exitosa");
        }
    }
}
