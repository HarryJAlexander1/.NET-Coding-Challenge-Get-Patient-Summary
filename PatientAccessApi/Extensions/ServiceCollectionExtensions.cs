using PatientAccessApi.Endpoints;
using PatientAccessApi.Log;
using PatientAccessApi.Services;

namespace PatientAccessApi.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection RegisterServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .Configure<Config>(configuration.GetSection("PatientAccessAPI"))
                .AddSingleton<StorageHandler>()
                .AddSingleton<PatientAccessEndpoints>()
                .AddSingleton<LogHandler>()
                .AddSingleton<Server>()
                .AddEndpointsApiExplorer();

            return serviceCollection;
        }
    }
}
