using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Application.Interfaces.Service;
using UserProfileService.Infrastructure.Persistance;
using UserProfileService.Infrastructure.Repositories;
using UserProfileService.Infrastructure.Services;

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

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IInterviewRepository , InterviewRepository>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            return services;
        }
    }
}
    