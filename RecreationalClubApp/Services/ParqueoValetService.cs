using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Entities;
using IServices;
using Microsoft.Extensions.Configuration;


namespace Services
{
    public class ParqueoValetService : BaseService<ParqueoValet>, IParqueoValetService
    {
        public ParqueoValetService(IRepository<ParqueoValet> repository, IConfiguration configuration)
            : base(repository, configuration["JwtSecret"])
        {

        }
    }
}
