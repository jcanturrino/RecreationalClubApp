using Configurations.BaseInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Configurations.BaseLogic
{
    public class Repository<TEntity> : BaseRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public Repository(DbContext context, IServiceScopeFactory serviceScopeFactory) : base(context, serviceScopeFactory)
        {
        }
    }

}