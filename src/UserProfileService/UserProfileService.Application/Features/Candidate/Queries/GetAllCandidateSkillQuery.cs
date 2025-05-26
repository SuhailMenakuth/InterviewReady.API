using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Candidate.Dtos;


namespace UserProfileService.Application.Features.Candidate.Queries
{
    public record GetAllCandidateSkillQuery(Guid userId) : IRequest<List<CandidateSkillReadDto>>;

}
