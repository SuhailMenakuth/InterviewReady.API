using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using IdentityService.Domain.Entities;
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

        public RegisterUserHandler(IAuthRepository authRepository , IPasswordHasher passwordHasher)
        {
           _authRepository = authRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _authRepository.UserExistsByEmailAsync(request.Email))
            {
                throw new ApplicationException("User already exists with this email.");
            }

            if (await _authRepository.UserExistsByPhoneAsync(request.PhoneNumber))
            {
                throw new ApplicationException("User already exists with this phone.");
            }

            var password = _passwordHasher.HashPassword(request.Password);

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = password,
            };

            await _authRepository.AddUserAsync(user);
            return "Registration successful";
        }
    }
}
