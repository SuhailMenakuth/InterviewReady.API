using InterviewReady.Messaging.Contracts.Enums;
using InterviewReady.Messaging.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Infrastructure.Messaging.Events
{
    public class InterviewerCreatedEvent : IInterviewerCreatedEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

       
    }
}
