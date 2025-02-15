using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.BaseReturn.Interface;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class RegistroAccesoService : BaseService<RegistroAcceso>, IRegistroAccesoService
    {
        public RegistroAccesoService(IRepository<RegistroAcceso> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {
        }

        public async Task<IOperationResult<IEnumerable<RegistroAcceso>>> ConsultarPorClienteIdAsync(int clienteId)
        {
            return await _repository.FindAsync(r => r.ClienteId == clienteId);
        }
    }
}
