using IdentiService.Application.Exceptions;
using IdentiService.Application.Features.Auth.Dtos;
using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        public LoginUserHandler(IAuthRepository authRepository , IPasswordHasher passwordHasher , IAccessTokenGenerator accessTokenGenerator)
        {
            _authRepository = authRepository;
            _passwordHasher = passwordHasher;
            _accessTokenGenerator = accessTokenGenerator;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authRepository.GetVerifiedUserByEmailAsync(request.userLoginDto.email) ?? throw new NotFoundException("user not found");
            if ( !_passwordHasher.VerifyPassword(request.userLoginDto.password, user.Password))
            {
                throw new ApplicationException("Invalid username or password");
            }

            return _accessTokenGenerator.GenerateToken(user);
        }

    }
}
