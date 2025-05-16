using InterviewReady.Messaging.Contracts.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Service;

namespace UserProfileService.Infrastructure.Services
{
    public class UserEventPublisher : IUserEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UserEventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishInterviewerCreatedAsync(IInterviewerCreatedEvent @event)
        {
            await _publishEndpoint.Publish<IInterviewerCreatedEvent>(@event);
        }

        //Task IUserEventPublisher.PublishInterviewerCreatedAsync(object value)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
