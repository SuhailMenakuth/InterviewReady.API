using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Domain.Entities.Admin
{
    public class Area
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int DepartmentId { get; set; }
        public required Department Department { get; set; }
        public ICollection<InterviewerExpertiseArea> InterviewerExpertiseAreas { get; set; } = new List<InterviewerExpertiseArea>();
    }
}
