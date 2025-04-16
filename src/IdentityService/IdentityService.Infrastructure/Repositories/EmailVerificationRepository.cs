using IdentiService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using IdentityService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace IdentityService.Infrastructure.Repositories
{
    public class EmailVerificationRepository : IEmailVerificationRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailVerificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmailVerification otp)
        {
            await _context.EmailVerifications.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailVerification?> GetByEmailAsync(string email)
        {
            return await _context.EmailVerifications
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task UpdateAsync(EmailVerification otp)
        {
            _context.EmailVerifications.Update(otp);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(EmailVerification otp)
        {
            _context.EmailVerifications.Remove(otp);
            await _context.SaveChangesAsync();
        }
    }
}
//7994755140