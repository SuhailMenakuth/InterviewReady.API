using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Application.Features.Interviewer.Dtos
{
    public class InterviewerCreateDto
    {

        public string name { get; set; }
        public IFormFile photo { get; set; }
        public List<int> expertiseAreaIds { get; set; } = new();

    }
}
