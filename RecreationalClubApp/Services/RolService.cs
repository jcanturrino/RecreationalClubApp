using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class RolService : BaseService<Rol>, IRolService
    {
        public RolService(IRepository<Rol> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {

        }
    }
}
