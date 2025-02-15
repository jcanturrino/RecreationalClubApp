using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class CodigoUbicacionService : BaseService<CodigoUbicacion>, ICodigoUbicacionService
    {
        public CodigoUbicacionService(IRepository<CodigoUbicacion> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {

        }
    }
}
