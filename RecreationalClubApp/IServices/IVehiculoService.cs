using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Entities;

namespace IServices
{
    public interface IVehiculoService : IBaseService<Vehiculo>
    {
        Task<IOperationResult<IEnumerable<Vehiculo>>> ConsultarPorClienteIdAsync(int clienteId);
    }
}
