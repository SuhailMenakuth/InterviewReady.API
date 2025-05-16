using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Features.Interviewer.Dtos
{
    public class InterviewerReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
        public string Photo { get; set; }
        public string workingat { get; set; }
        public List<ExpertiseAreaDto> ExpertiseAreas { get; set; }
    }
}
