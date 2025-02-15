using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ParqueoValetRepository : Repository<ParqueoValet>, IParqueoValetRepository
    {
        public ParqueoValetRepository(DbContext context) : base(context)
        {

        }
    }
}
