﻿using Microsoft.Extensions.DependencyInjection;
using mr.cooper.mrtwit.services.Interface;
using mr.cooper.mrtwit.services.Interface.Concrete;

namespace mr.cooper.mrtwit.services
{
   public static class ServiceRegistry
    {

        public static IServiceCollection AddEssentialDependencies(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            mr.cooper.mrtwit.repository.mongo.ServiceRegistry.AddEssentialDependencies(services);

           
            return services;
        }
    }
}
