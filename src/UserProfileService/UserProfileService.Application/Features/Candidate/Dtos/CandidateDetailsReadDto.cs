using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Application.Features.Candidate.Dtos
{
    public  class CandidateDetailsReadDto
    {
        public Guid id { get; set; }
        public string fullName { get; set; }
        public string photoUrl { get; set; }
        public string cvUrl { get; set; }
        public string highestEducation { get; set; }
        public List<CandidateSkillReadDto> skills { get; set; } = new List<CandidateSkillReadDto>();
    }
}
