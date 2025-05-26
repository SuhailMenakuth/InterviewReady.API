using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Exceptions;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Candidate.Commands
{
    public class DeleteCandidateSkillByIdCommandHandler : IRequestHandler<DeleteCandidateSkillByIdCommand , string>
    {
        private readonly ICandidateRepository _candidateRepository;
        public DeleteCandidateSkillByIdCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<string> Handle(DeleteCandidateSkillByIdCommand request , CancellationToken cancellationToken)
        {
            var candidateSkill = await _candidateRepository.GetCanidateSkillByIdAsync(request.id) ??
                throw new NotFoundException("candidate skill not found");

            await _candidateRepository.DeleteCanidateSkillByIdAsync(candidateSkill);
            return $"Canidate skill delted id {request.id}";
        }
    }
}
