using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;

namespace UserProfileService.Application.Features.Interviewer.Queries
{
    public record GetAllInterviewersQuery() : IRequest<List<InterviewerReadDto>>;
    
}
