using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {

        public UsuarioService(IRepository<Usuario> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        { }

        public async Task<IOperationResult<string>> AuthenticateAsync(string username, string password)
        {
            var usuario = await _repository.FindAsync(u => u.NombreUsuario == username && u.Contrasena == password);
            var user = usuario.Data.FirstOrDefault();
            if (user == null) return IOperationResult<string>.ErrorResult("Autenticación fallida");

            return IOperationResult<string>.SuccessResult(this.GenerateJwtTokenAsync(user.NombreUsuario, user.Id).Result.Data.Token, "Autenticación exitosa");
        }
    }
}
