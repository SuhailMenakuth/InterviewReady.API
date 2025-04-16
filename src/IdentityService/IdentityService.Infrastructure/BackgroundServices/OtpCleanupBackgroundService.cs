using IdentityService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.BackgroundServices
{
    public class OtpCleanupBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<OtpCleanupBackgroundService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(10); 

        public OtpCleanupBackgroundService(IServiceProvider serviceProvider, ILogger<OtpCleanupBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OTP Cleanup Service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await CleanupExpiredOtpsAsync();
                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("OTP Cleanup Service is stopping.");
        }

        private async Task CleanupExpiredOtpsAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var expiredOtps = await dbContext.EmailVerifications
                    .Where(ev => ev.ExpiryTime < DateTime.UtcNow)
                    .ToListAsync();

                if (expiredOtps.Any())
                {
                    dbContext.EmailVerifications.RemoveRange(expiredOtps);
                    await dbContext.SaveChangesAsync();

                    _logger.LogInformation($"Cleaned up {expiredOtps.Count} expired OTP entries.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while cleaning up expired OTPs.");
            }
        }
    }
}
