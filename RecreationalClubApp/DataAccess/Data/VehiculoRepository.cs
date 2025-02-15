using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(DbContext context) : base(context)
        {

        }
    }
}
