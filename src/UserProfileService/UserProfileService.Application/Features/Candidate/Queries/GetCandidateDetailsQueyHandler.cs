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
    public class CandidateDetailsQueyHandler : IRequestHandler<GetCandidateDetailsQuery , CandidateDetailsReadDto>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateDetailsQueyHandler(ICandidateRepository candidateRepository , IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;

        }
        public async Task<CandidateDetailsReadDto> Handle(GetCandidateDetailsQuery request , CancellationToken cancellationToken)
        {
            var candidate =  await _candidateRepository.GetCandidateWithSkillsAsync(request.id) ??
                throw new NotFoundException("Candidiate not found");

           return  _mapper.Map<CandidateDetailsReadDto>(candidate);
        }
    }
}
