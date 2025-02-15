using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;

namespace Services
{
    public class MarcaService : BaseService<Marca>, IMarcaService
    {
        public MarcaService(IRepository<Marca> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {

        }
    }
}
