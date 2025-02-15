using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.JWT;
using Entities;
using IServices;


namespace Services
{
    public class ParqueoValetService : BaseService<ParqueoValet>, IParqueoValetService
    {
        public ParqueoValetService(IRepository<ParqueoValet> repository, ServiceConfiguration serviceConfiguration)
        : base(repository, serviceConfiguration)
        {

        }
    }
}
