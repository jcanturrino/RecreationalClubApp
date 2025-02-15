using Configurations.BaseLogic;
using Entities;
using IDataAccess;

namespace DataAccess.Data
{

    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RecreationalClubContext context) : base(context) { }
    }
}
