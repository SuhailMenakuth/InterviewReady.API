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

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email );
           
        }

       public async Task<User?> GetVerifiedUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsVerified == true);
        }

        public async Task AddUserAsync(User usr)
        {
           
                await _context.Users.AddAsync(usr);
                await _context.SaveChangesAsync();
        }
        
        public async Task UpdateUserAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUserEmailVerifiedAsync(string email)
        {
           
                return await _context.Users.AnyAsync(c => c.Email == email && c.IsVerified == true);
           
        }
        public async Task<bool> IsUserPhoneNumberVerifiedAsync(string phoneNumber)
        {
           
                return await _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber && u.IsVerified == true);
  
        }

        public async Task<bool> IsUserUnverifiedByEmailAsync(string email)
        {

            return await _context.Users.AnyAsync(u => u.Email == email && u.IsVerified == false);


        }

    }
}
