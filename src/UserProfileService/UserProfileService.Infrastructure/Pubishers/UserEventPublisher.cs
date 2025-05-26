using InterviewReady.Messaging.Contracts.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Events;

namespace UserProfileService.Infrastructure.Pubishers
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
            await _publishEndpoint.Publish(@event);
        }


    }

}
