using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;

namespace UserProfileService.Application.Features.Interviewer.Commands
{
    public class InterviewerCreateCommand : IRequest<Guid>
    {
        public InterviewerCreateDto Dto { get; set; }  
        public InterviewerCreateCommand(InterviewerCreateDto dto) 
        { 
          Dto = dto;
        }
    }
}
