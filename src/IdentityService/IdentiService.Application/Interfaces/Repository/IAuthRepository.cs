using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Interfaces.Repository
{
    public interface IAuthRepository
    {
        
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetVerifiedUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync();
        Task<bool> IsUserEmailVerifiedAsync(string email);
        Task<bool> IsUserPhoneNumberVerifiedAsync(string phoneNumber);
        Task<bool> IsUserUnverifiedByEmailAsync(string email);
    }   
}   
