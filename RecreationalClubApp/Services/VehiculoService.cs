using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class VehiculoService : BaseService<Vehiculo>, IVehiculoService
    {
        public VehiculoService(IRepository<Vehiculo> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {
        }

        public async Task<IOperationResult<IEnumerable<Vehiculo>>> ConsultarPorClienteIdAsync(int clienteId)
        {
            return await _repository.FindAsync(v => v.ClienteId == clienteId);
        }
    }
}
