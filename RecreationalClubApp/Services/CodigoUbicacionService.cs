using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class CodigoUbicacionService : BaseService<CodigoUbicacion>, ICodigoUbicacionService
    {
        public CodigoUbicacionService(IRepository<CodigoUbicacion> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {

        }
    }
}
