using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Exceptions;
using UserProfileService.Application.Features.Candidate.Dtos;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Application.Features.Candidate.Queries
{
    public class GetAllCandidateSkillQueryHandler : IRequestHandler<GetAllCandidateSkillQuery ,List<CandidateSkillReadDto>>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetAllCandidateSkillQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<List<CandidateSkillReadDto>> Handle(GetAllCandidateSkillQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetCandidateWithSkillsAsync(request.userId)
                ?? throw new NotFoundException("User not found");

            return _mapper.Map<List<CandidateSkillReadDto>>(candidate.Skills);
        }

    }
}
