using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class InformacionContactoService : BaseService<InformacionContacto>, IInformacionContactoService
    {
        public InformacionContactoService(IRepository<InformacionContacto> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {

        }
    }
}
