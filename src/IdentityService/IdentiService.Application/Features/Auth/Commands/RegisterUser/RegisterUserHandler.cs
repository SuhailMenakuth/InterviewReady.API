using IdentiService.Application.Interfaces.Events;
using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Enums;
using InterviewReady.Messaging.Contracts.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentiService.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ICandidateCreatedEventPublisher _candidateCreatedEventPublisher;
        private readonly ILogger<RegisterUserHandler> _logger;

        public RegisterUserHandler(IAuthRepository authRepository, IPasswordHasher passwordHasher , ICandidateCreatedEventPublisher candidateCreatedEventPublisher , ILogger<RegisterUserHandler> logger)
        {
           _authRepository = authRepository;
            _passwordHasher = passwordHasher;
            _candidateCreatedEventPublisher = candidateCreatedEventPublisher;
            _logger = logger;
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

           

            if (await _authRepository.IsUserUnverifiedByEmailAsync(request.Email))
            {
               var user = await _authRepository.GetUserByEmailAsync(request.Email);
                var existingUserPassword = _passwordHasher.HashPassword(request.Password);

                user.PhoneNumber = request.PhoneNumber;
                user.Password = existingUserPassword;
                user.UserType = UserType.Candidate;

                await _authRepository.UpdateUserAsync();
            }
            else
            {
                var password = _passwordHasher.HashPassword(request.Password);
                  
              var  user = new User
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = password,
                    UserType = UserType.Candidate
                };

                await _authRepository.AddUserAsync(user);
            _logger.LogInformation("Publishing CandidateCreatedEvent for User ID: {Id}", user.Id);

            await _candidateCreatedEventPublisher.PublishCandidateCreatedAsync(new CandidateCreatedEvent
            {
                Id = user.Id,
                FullName = request.FullName
            });

            _logger.LogInformation("CandidateCreatedEvent published successfully.");
            }


            return "Registration successful";
        }

    }
}
