using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.DependencyInjection;
using Configurations.JWT.Configuration;
using DataAccess.Data;
using IDataAccess;
using IServices;
using Microsoft.EntityFrameworkCore;
using Services;
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

            // Registrar DbContext
            builder.Services.AddDbContext<RecreationalClubContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Registrar el contexto de DbContext
            builder.Services.AddScoped<DbContext, RecreationalClubContext>();

            // Registrar repositorios genéricos y concretos
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Registrar servicios genéricos
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            // Configurar autenticación JWT utilizando el proyecto Configuration
            builder.Services.AddJwtAuthentication(configuration);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
