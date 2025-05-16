using IdentityService.Domain.Entities;

namespace IdentiService.Application.Interfaces.Repository
{
    public interface IAuthRepository
    {
        
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetVerifiedUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync();
        Task<bool> IsUserEmailVerifiedAsync(string email);
        Task<bool> IsUserPhoneNumberVerifiedAsync(string phoneNumber);
        Task<bool> IsUserUnverifiedByEmailAsync(string email);
    }   
}   
