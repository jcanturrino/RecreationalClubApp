using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class RolPermisoService : BaseService<RolPermiso>, IRolPermisoService
    {
        public RolPermisoService(IRepository<RolPermiso> repository, ServiceConfiguration serviceConfiguration) : base(repository, serviceConfiguration)
        {
        }
    }
}
