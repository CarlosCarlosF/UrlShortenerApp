using Infrastracture;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Configuration;

namespace UrlShortenerApplication
{
    public class ContainerRegistrations
    {
        public static void Register(IServiceCollection serviceCollection, IAppSettings appSettings)
        {
            serviceCollection.AddSingleton<ICachingService, CachingService>();
        }
    }
}
