﻿using InterviewReady.Messaging.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Interfaces.Events
{
    public interface IUserEventPublisher
    {
        Task PublishInterviewerCreatedAsync(IInterviewerCreatedEvent @event);

    }
}
