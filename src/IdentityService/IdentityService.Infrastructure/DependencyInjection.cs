using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using IdentityService.Infrastructure.Persistance;
using IdentityService.Infrastructure.Persistance.Configurations;
using IdentityService.Infrastructure.Repositories;
using IdentityService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
             ?? configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                ));
            var emailConfig = configuration.GetSection("EmailSettings").Get<EmailSettings>();
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services
                .AddFluentEmail(emailConfig.SenderEmail, emailConfig.SenderName)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(emailConfig.SmtpHost)
                {
                    Port = emailConfig.SmtpPort,
                    Credentials = new NetworkCredential(emailConfig.SmtpUser, emailConfig.SmtpPass),
                    EnableSsl = true,
                });
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAccessTokenGenerator, AccessTokenGenerator>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailVerificationRepository, EmailVerificationRepository>();


            return services;
        }
    }
}
