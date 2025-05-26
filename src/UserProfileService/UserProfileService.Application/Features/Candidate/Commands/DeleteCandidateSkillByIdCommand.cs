using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Features.Candidate.Commands
{
    public record DeleteCandidateSkillByIdCommand(Guid id) : IRequest<string>;
    
}
