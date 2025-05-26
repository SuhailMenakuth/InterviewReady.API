using InterviewReady.Messaging.Contracts.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Events;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Application.Interfaces.Service;
using UserProfileService.Infrastructure.Consumers;
using UserProfileService.Infrastructure.Persistance;
using UserProfileService.Infrastructure.Pubishers;
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

            //services.AddMassTransit(x =>
            //{
            //x.AddConsumer<CandidateCreatedConsumer>();
            //x.SetKebabCaseEndpointNameFormatter();

            //x.UsingRabbitMq((context, cfg) =>
            //{
            //    cfg.Host(configuration["RABBITMQ-HOST"], h =>
            //    {
            //        h.Username(configuration["RABBITMQ-USERNAME"]);
            //        h.Password(configuration["RABBITMQ-PASSWORD"]);
            //    });
            //});


            //});

            services.AddMassTransit(x =>
            {
               
                x.AddConsumer<CandidateCreatedConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RABBITMQ-HOST"], h =>
                    {
                        h.Username(configuration["RABBITMQ-USERNAME"]);
                        h.Password(configuration["RABBITMQ-PASSWORD"]);
                    });
                    cfg.ReceiveEndpoint("candidate-created-event-queue", e =>
                    {
                        e.ConfigureConsumer<CandidateCreatedConsumer>(context);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });





            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IInterviewRepository , InterviewRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IUserEventPublisher, UserEventPublisher>();

            return services;
        }
    }
}
    