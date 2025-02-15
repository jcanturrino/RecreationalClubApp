using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Entities;

namespace IServices
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<IOperationResult<string>> AuthenticateAsync(string username, string password);
    }

}
