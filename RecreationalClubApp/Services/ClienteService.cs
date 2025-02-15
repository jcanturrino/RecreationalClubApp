using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IRepository<Cliente> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {

        }
    }
}