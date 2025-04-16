using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Infrastructure.Persistance;

namespace UserProfileService.Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services , IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
             ?? configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbcontext>(options =>
                options.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                ));

            return services;
        }
    }
}
    