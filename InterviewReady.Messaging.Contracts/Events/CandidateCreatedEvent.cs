﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewReady.Messaging.Contracts.Events
{
    public class CandidateCreatedEvent : ICandidateCreatedEvent
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
