using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class InformacionContactoService : BaseService<InformacionContacto>, IInformacionContactoService
    {
        public InformacionContactoService(IRepository<InformacionContacto> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {

        }
    }
}
