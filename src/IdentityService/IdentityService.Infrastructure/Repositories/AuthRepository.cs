using IdentiService.Application.Interfaces.Repository;
using IdentityService.Domain.Entities;
using IdentityService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddUserAsync(User usr)
        {
            try
            {

                await _context.Users.AddAsync(usr);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.AnyAsync(c => c.Email == email);
            } catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UserExistsByPhoneAsync(string phoneNumber)
        {
            try
            {
                return await _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);

            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
