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

namespace UserProfileService.Application.Features.Candidate.Queries
{
    public class GetCandidateSkillByIdQueryHandler : IRequestHandler<GetCandidateSkillByIdQuery, CandidateSkillReadDto>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidateSkillByIdQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<CandidateSkillReadDto> Handle(GetCandidateSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _candidateRepository.GetCanidateSkillByIdAsync(request.id)
                ?? throw new NotFoundException("Candidate skill not found.");

            return _mapper.Map<CandidateSkillReadDto>(skill);
        }
    }
}
