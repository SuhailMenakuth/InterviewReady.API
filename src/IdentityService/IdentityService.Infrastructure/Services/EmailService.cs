using FluentEmail.Core;
using IdentiService.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            await _fluentEmail
                .To(toEmail)
                .Subject(subject)
                .Body(body, isHtml: true)
                .SendAsync();
        }
    }
}
