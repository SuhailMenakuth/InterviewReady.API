using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserHandler(IAuthRepository authRepository, IPasswordHasher passwordHasher)
        {
           _authRepository = authRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _authRepository.IsUserEmailVerifiedAsync(request.Email))
            {
                throw new ApplicationException("User already exists with this email.");
            }

            if (await _authRepository.IsUserPhoneNumberVerifiedAsync(request.PhoneNumber))
            {
                throw new ApplicationException("User already exists with this phone.");
            }
            if(await _authRepository.IsUserUnverifiedByEmailAsync(request.Email))
            {
                var existingUser =  await _authRepository.GetUserByEmailAsync(request.Email);
                var existingUserPassword = _passwordHasher.HashPassword(request.Password);


                //existingUser.FullName = request.FullName;
                existingUser.PhoneNumber = request.PhoneNumber;
                existingUser.Password = existingUserPassword;
                existingUser.UserType = UserType.Candidate;

                await _authRepository.UpdateUserAsync();
                return "Registration successfull";
                    
            }
            else
            {

                var password = _passwordHasher.HashPassword(request.Password);

                var user = new User
                {
                    //FullName = request.FullName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = password,
                    UserType = UserType.Candidate
                };

                await _authRepository.AddUserAsync(user);
                return "Registration successfull";
            }

        }
    }
}
