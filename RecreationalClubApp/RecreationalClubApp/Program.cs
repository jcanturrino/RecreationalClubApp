using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.DependencyInjection;
using Configurations.JWT.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace RecreationalClubApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            var builder = WebApplication.CreateBuilder(args);

            // Registrar servicios
            builder.Services.AddApplicationServices(
                Assembly.GetExecutingAssembly(),
                Assembly.Load("Services"),
                Assembly.Load("DataAccess"));

            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<RecreationalClubContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            builder.Services.AddScoped<DbContext, RecreationalClubContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddJwtAuthentication(configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureAppConfiguration((context, config) =>
          {
              config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
          });
    }
}
