using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StolovkaWebAPI.Installers
{
    /// <summary>
    /// Provides a method for clean service registration.
    /// </summary>
    public interface IInstaller
    {
        /// <summary>
        /// Defines configuration of a particular service.
        /// </summary>
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}