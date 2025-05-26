using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using IdentityService.Domain.Entities;
using InterviewReady.Messaging.Contracts.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Consumers
{
    public class InterviewerCreatedEventConsumer : IConsumer<IInterviewerCreatedEvent>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher _passwordHasher;

        public InterviewerCreatedEventConsumer(IAuthRepository authRepository , IPasswordHasher passwordHasher)
        {
            _authRepository = authRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task Consume(ConsumeContext<IInterviewerCreatedEvent> context)
        {
            var message = context.Message;
            var password = _passwordHasher.HashPassword(context.Message.Password);


            var newUser = new User
            {
                Id = message.UserId,
                Email = message.Email,
                PhoneNumber = message.PhoneNumber,  
                Password = password,
                UserType = (Domain.Enums.UserType)message.UserType,
                IsVerified = true 
            };

            await _authRepository.AddUserAsync(newUser);
        }
    }
}
