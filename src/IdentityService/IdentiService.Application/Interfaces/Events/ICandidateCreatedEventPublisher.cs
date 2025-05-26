using InterviewReady.Messaging.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Interfaces.Events
{
    public interface ICandidateCreatedEventPublisher
    {
        Task PublishCandidateCreatedAsync(ICandidateCreatedEvent @event);
        
    }
}
