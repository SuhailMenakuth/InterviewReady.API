using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Domain.Entities.Candidate
{
    public class Candidate
    {
        public Guid Id { get; set; } 
        public string FullName { get; set; }
        public string PhotoUrl { get; set; }
        public string CvUrl { get; set; }
        public string HighestEducation { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public ICollection<CandidateSkill> Skills { get; set; } = new List<CandidateSkill>();
    }
}
