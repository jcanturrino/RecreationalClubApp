using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IRepository<Cliente> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {

        }
    }
}