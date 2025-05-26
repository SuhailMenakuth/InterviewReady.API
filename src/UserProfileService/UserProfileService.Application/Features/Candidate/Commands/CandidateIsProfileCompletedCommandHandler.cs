using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Candidate.Commands
{
    public class CandidateIsProfileCompletedCommandHandler : IRequestHandler<CandidateIsProfileCompletedCommand ,bool>
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateIsProfileCompletedCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<bool> Handle(CandidateIsProfileCompletedCommand request , CancellationToken cancellationToken) 
        {
          var candidate = await _candidateRepository.GetByIdAsync(request.id);
            return  !string.IsNullOrWhiteSpace(candidate.PhotoUrl)
                    && !string.IsNullOrWhiteSpace(candidate.CvUrl)
                    && !string.IsNullOrWhiteSpace(candidate.HighestEducation);
        }
    }
}
