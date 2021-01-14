using Microsoft.Extensions.DependencyInjection;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository.mongodb.Interface.Concrete;

namespace mr.cooper.mrtwit.repository.mongo
{
    public static class ServiceRegistry
    {

        public static IServiceCollection AddEssentialDependencies(IServiceCollection services)
        {
            services.AddSingleton<IDbContext<User>, UserDBContext>();
            services.AddSingleton<IDbContext<Profile>, ProfileDBContext>();
            services.AddSingleton<IDbContext<Tweet>, TweetDBContext>();
            services.AddSingleton<IDbContext<Feed>, FeedDBContext>();
            services.AddSingleton<IDbContext<Session>, SessionDBContext>();



            return services;
        }
    }
}
