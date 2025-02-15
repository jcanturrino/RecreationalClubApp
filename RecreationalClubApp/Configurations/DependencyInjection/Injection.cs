using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Configurations.DependencyInjection
{
    public static class Injection
    {
        public static void AddApplicationServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var typesWithInterfaces = assembly.GetExportedTypes()
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .Select(t => new
                    {
                        Service = t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"),
                        Implementation = t
                    }).Where(t => t.Service != null);

                foreach (var type in typesWithInterfaces)
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }
        }
    }
}
