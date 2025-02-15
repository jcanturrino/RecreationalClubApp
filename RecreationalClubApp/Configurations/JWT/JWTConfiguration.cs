using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Configurations.JWT
{

    namespace Configuration
    {
        public static class JwtConfiguration
        {
            public static string JwtSecret { get; set; }
            public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
            {
                JwtSecret = configuration["JwtSecret"];
                var key = Encoding.ASCII.GetBytes(JwtSecret);

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

                return services;
            }
        }
    }

}
