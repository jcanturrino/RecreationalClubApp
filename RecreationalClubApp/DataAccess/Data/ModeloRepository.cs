using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Data
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(DbContext context, IServiceScopeFactory serviceScopeFactory) : base(context, serviceScopeFactory)
        {
        }
    }
}
