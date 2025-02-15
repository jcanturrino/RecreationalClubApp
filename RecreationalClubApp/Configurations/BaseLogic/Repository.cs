using Configurations.BaseInterface;
using Microsoft.EntityFrameworkCore;

namespace Configurations.BaseLogic
{
    public class Repository<TEntity> : BaseRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public Repository(DbContext context) : base(context) { }
    }

}