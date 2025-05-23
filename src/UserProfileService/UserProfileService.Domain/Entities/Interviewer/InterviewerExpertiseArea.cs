﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Domain.Entities.Interviewer
{
    public class InterviewerExpertiseArea
    {
        public Guid InterviewerId { get; set; }
        public  Interviewer Interviewer { get; set; }
        public int ExpertiseAreaId { get; set; }
        public  Area Area { get; set; }
    }
}
