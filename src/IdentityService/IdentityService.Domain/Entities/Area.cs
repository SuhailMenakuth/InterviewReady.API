using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key to Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<InterviewerExpertiseArea> InterviewerExpertiseAreas { get; set; } = new List<InterviewerExpertiseArea>();
    }
}
