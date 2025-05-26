using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Domain.Entities.Candidate
{
    public class CandidateSkill
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public string SkillName { get; set; }
      
    }
}
