using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class TipoClienteService : BaseService<TipoCliente>, ITipoClienteService
    {
        public TipoClienteService(IRepository<TipoCliente> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {
        }
    }
}
