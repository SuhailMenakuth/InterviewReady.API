using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Interfaces.Repository
{
    public interface IEmailVerificationRepository
    {
        Task AddAsync(EmailVerification otp);
        Task<EmailVerification?> GetByEmailAsync(string email);
        Task UpdateAsync(EmailVerification otp);
        Task DeleteAsync(EmailVerification otp);
    }
}
