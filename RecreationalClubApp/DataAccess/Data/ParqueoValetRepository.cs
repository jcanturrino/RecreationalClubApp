using Configurations.BaseLogic;
using Entities;
using IDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Data
{
    public class ParqueoValetRepository : Repository<ParqueoValet>, IParqueoValetRepository
    {
        public ParqueoValetRepository(DbContext context, IServiceScopeFactory serviceScopeFactory) : base(context, serviceScopeFactory)
        {
        }
    }
}
