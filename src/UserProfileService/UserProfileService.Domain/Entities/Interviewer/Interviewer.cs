using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Domain.Entities.Interviewer
{
    public class Interviewer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string WorkingAt { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<InterviewerExpertiseArea> InterviewerExpertiseAreas { get; set; }
    }
}
