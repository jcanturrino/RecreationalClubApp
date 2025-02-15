using Configurations.BaseInterface;
using Configurations.BaseLogic;
using Configurations.DependencyInjection;
using Configurations.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;


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
            builder.Services.AddScoped(typeof(ITokenRepository), typeof(TokenRepository));
            builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService));


            // Registrar configuración de JWT
            var jwtConfig = configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>();
            builder.Services.AddSingleton(jwtConfig);

            // Registrar ServiceConfiguration
            builder.Services.AddScoped<ServiceConfiguration>(sp => new ServiceConfiguration(
                sp.GetRequiredService<ITokenRepository>(),
                sp.GetRequiredService<JwtConfiguration>()));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtConfiguration:Issuer"],
                    ValidAudience = configuration["JwtConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.JwtSecret))
                };
            });

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
