﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserProfileService.Application
{
    public static class DependencyInjection
    {
       
       
            public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            {

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
                services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                services.AddAutoMapper(Assembly.GetExecutingAssembly());

                return services;
            }
        
    }
}
