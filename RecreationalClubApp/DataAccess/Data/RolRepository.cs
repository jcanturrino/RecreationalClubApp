using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(DbContext context) : base(context)
        {

        }
    }
}