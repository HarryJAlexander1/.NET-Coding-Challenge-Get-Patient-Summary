using PatientAccessApi.Data;
using PatientAccessApi.Endpoints;
using PatientAccessApi.Log;
using PatientAccessApi.Services;

namespace PatientAccessApi.Extensions
{
    /// <summary>
    /// Provides extension methods for registering application services with the dependency injection container.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all application services required by PatientAccessApi.
        /// </summary>
        /// <param name="serviceCollection">The service collection to register services into.</param>
        /// <param name="configuration">The application configuration used to bind settings.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection RegisterServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .Configure<Config>(configuration.GetSection("PatientAccessAPI"))
                .AddSingleton<LogHandler>()
                .AddSingleton<MockData>()
                .AddSingleton<StorageHandler>()
                .AddSingleton<Server>()
                .AddSingleton<PatientAccessEndpoints>()
                .AddEndpointsApiExplorer();

            return serviceCollection;
        }
    }
}
