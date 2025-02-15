using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(DbContext context) : base(context)
        {

        }
    }
}
