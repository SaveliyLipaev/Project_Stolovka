using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using StolovkaWebAPI.Cache;
using StolovkaWebAPI.Services;

namespace StolovkaWebAPI.Installers
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();

            // Define the context for setup of a specific service using reflection.
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddSingleton<IConnectionMultiplexer>(_ =>
                ConnectionMultiplexer.Connect(redisCacheSettings.ConnectionString));
            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}