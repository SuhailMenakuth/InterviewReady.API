using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Features.Candidate.Dtos
{
    public class CandidateSkillReadDto
    {
        public Guid id { get; set; }
        public string skillName { get; set; }
    }
}
