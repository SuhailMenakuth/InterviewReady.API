using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class Interviewer : User
    {
        public string Department { get; set; }
        public string Photo { get; set; }
        public List<string> ExpertiseAreas { get; set; }
        public int InterviewingExperience { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<InterviewerExpertiseArea> InterviewerExpertiseAreas { get; set; }
    }
}
