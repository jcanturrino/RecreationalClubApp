using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Entities;

namespace IServices
{
    public interface IRegistroAccesoService : IBaseService<RegistroAcceso>
    {
        Task<IOperationResult<IEnumerable<RegistroAcceso>>> ConsultarPorClienteIdAsync(int clienteId);
    }
}
