using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class TipoClienteService : BaseService<TipoCliente>, ITipoClienteService
    {
        public TipoClienteService(IRepository<TipoCliente> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {
        }
    }
}
