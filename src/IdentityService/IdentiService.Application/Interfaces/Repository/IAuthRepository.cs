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
        Task AddUserAsync(User cstmr);
        Task<bool> UserExistsByEmailAsync(string email);
        Task<bool> UserExistsByPhoneAsync(string phoneNumber);
    }   
}   
