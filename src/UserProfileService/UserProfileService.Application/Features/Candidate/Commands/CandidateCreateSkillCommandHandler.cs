using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Exceptions;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Application.Features.Candidate.Commands
{
    public class CandidateCreateSkillCommandHandler : IRequestHandler<CandidateCreateSkillCommand , object>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateCreateSkillCommandHandler(ICandidateRepository candidateRepository , IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;

        }
        public async Task<object> Handle(CandidateCreateSkillCommand request , CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetCandidateWithSkillsAsync(request.candidateId)
                ?? throw new NotFoundException("Candidate cannot be found ");

            if(candidate.Skills.Any(s => s.SkillName.ToLower() == request.skillName.ToLower()))
            {
                throw new Exception("skill already exist ");
            }

             var skill = _mapper.Map<CandidateSkill>(request);
             var result =  await _candidateRepository.AddAsync(skill);
            return  result ;


        }
    }
}
