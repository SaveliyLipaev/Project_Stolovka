using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StolovkaWebAPI.Data;
using StolovkaWebAPI.HealthChecks;

namespace StolovkaWebAPI.Installers
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<StolovkaDbContext>()
                .AddCheck<RedisHealthCheck>("Redis");
        }
    }
}
