using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class RolService : BaseService<Rol>, IRolService
    {
        public RolService(IRepository<Rol> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {

        }
    }
}
