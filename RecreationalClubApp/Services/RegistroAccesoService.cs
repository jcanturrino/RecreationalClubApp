using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class RegistroAccesoService : BaseService<RegistroAcceso>, IRegistroAccesoService
    {
        public RegistroAccesoService(IRepository<RegistroAcceso> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {
        }

        public async Task<IOperationResult<IEnumerable<RegistroAcceso>>> ConsultarPorClienteIdAsync(int clienteId)
        {
            return await _repository.FindAsync(r => r.ClienteId == clienteId);
        }
    }
}
