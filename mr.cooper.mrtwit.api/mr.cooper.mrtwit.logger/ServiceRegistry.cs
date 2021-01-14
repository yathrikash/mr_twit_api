using Microsoft.Extensions.DependencyInjection;
using mr.cooper.mrtwit.logger.Concrete;
using mr.cooper.mrtwit.logger.Models;
using System.Linq;

namespace mr.cooper.mrtwit.logger
{
   public static class ServiceRegistry
    {

        public static IServiceCollection AddEssentialDependencies(IServiceCollection services)
        {
            if (!services.Any(x => x.ServiceType == typeof(IMrLogger)))
            {
                services.AddSingleton(LogProvider.GetLogger());
            }

            return services;
        }
    }
}
