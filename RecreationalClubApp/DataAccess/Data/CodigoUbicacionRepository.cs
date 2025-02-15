using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Data
{

    public class CodigoUbicacionRepository : Repository<CodigoUbicacion>, ICodigoUbicacionRepository
    {
        public CodigoUbicacionRepository(DbContext context, IServiceScopeFactory serviceScopeFactory) : base(context, serviceScopeFactory)
        {
        }
    }
}
