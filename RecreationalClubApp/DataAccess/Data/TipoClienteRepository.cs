using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class TipoClienteRepository : Repository<TipoCliente>, ITipoClienteRepository
    {
        public TipoClienteRepository(DbContext context) : base(context)
        {

        }
    }
}
