using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewReady.Messaging.Contracts.Events
{
    public interface ICandidateCreatedEvent
    {
        public Guid Id { get; }
        public string FullName { get; }


    }
}
