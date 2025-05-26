using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Candidate.Dtos;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Application.Features.Candidate.Queries
{
    public  record GetCandidateSkillByIdQuery(Guid id) : IRequest<CandidateSkillReadDto>;
}
