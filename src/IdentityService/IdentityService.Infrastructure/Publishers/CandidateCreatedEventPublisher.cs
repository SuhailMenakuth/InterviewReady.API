using IdentiService.Application.Interfaces.Events;
using InterviewReady.Messaging.Contracts.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Publishers
{

    public class CandidateCreatedEventPublisher : ICandidateCreatedEventPublisher
    {
       private readonly IPublishEndpoint _publishEndpoint;

       public CandidateCreatedEventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
       public async Task PublishCandidateCreatedAsync(ICandidateCreatedEvent @event)
        {
            await _publishEndpoint.Publish(@event);
        }

    }
}
