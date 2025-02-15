using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class InformacionContactoRepository : Repository<InformacionContacto>, IInformacionContactoRepository
    {
        public InformacionContactoRepository(DbContext context) : base(context)
        {

        }
    }
}
