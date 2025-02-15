using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ModeloRepository : Repository<Modelo>, IModeloRepository
    {
        public ModeloRepository(DbContext context) : base(context)
        {

        }
    }
}
