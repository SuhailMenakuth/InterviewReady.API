using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Features.Candidate.Dtos
{
    public class CandidateUpdateDto
    {
        public IFormFile photo { get; set; }
        public IFormFile cv { get; set; }
        public string highestEducation { get; set; }
    }
}
