using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class RegistroAccesoRepository : Repository<RegistroAcceso>, IRegistroAccesoRepository
    {
        public RegistroAccesoRepository(DbContext context) : base(context)
        {

        }
    }
}
