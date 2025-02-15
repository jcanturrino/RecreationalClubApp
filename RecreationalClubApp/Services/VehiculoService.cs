using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.BaseReturn.Interface;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class VehiculoService : BaseService<Vehiculo>, IVehiculoService
    {
        public VehiculoService(IRepository<Vehiculo> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {
        }

        public async Task<IOperationResult<IEnumerable<Vehiculo>>> ConsultarPorClienteIdAsync(int clienteId)
        {
            return await _repository.FindAsync(v => v.ClienteId == clienteId);
        }
    }
}
