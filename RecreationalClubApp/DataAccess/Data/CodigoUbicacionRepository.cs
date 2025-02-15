using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{

    public class CodigoUbicacionRepository : Repository<CodigoUbicacion>, ICodigoUbicacionRepository
    {
        public CodigoUbicacionRepository(DbContext context) : base(context)
        {
        }
    }
}
