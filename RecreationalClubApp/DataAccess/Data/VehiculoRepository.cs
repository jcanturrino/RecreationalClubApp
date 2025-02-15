using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Data
{
    public class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(DbContext context, IServiceScopeFactory serviceScopeFactory) : base(context, serviceScopeFactory)
        {
        }
    }
}
