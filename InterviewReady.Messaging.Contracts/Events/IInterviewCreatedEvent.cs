using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewReady.Messaging.Contracts.Events
{
    public interface IInterviewerCreatedEvent
    {
        Guid UserId { get; } 
        string Email { get; }
        string PhoneNumber { get; }
        string Password { get; }
        Enums.UserType UserType { get; }
    }
}
