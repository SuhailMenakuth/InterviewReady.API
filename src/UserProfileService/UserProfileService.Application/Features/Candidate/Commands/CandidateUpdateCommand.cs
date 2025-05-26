using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Candidate.Dtos;

namespace UserProfileService.Application.Features.Candidate.Commands
{
    public class CandidateUpdateCommand : IRequest<Guid>
    {
        public CandidateUpdateDto dto { get; set; }
        public Guid id { get; set; }
    }
}
