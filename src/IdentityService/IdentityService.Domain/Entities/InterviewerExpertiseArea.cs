using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class InterviewerExpertiseArea
    {
        public int InterviewerId { get; set; }
        public Interviewer Interviewer { get; set; }

        public int ExpertiseAreaId { get; set; }
        public Area Area { get; set; }
    }
}
