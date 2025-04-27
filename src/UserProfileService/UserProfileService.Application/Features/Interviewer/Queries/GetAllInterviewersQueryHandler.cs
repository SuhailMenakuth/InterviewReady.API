using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Interviewer.Queries
{
    public class GetAllInterviewersQueryHandler : IRequestHandler<GetAllInterviewersQuery, List<InterviewerReadDto>>
    {

        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;

        public GetAllInterviewersQueryHandler(IInterviewRepository interviewRepository, IMapper mapper)
        {
            _interviewRepository = interviewRepository;
            _mapper = mapper;
        }
        
        public async Task<List<InterviewerReadDto>> Handle(GetAllInterviewersQuery request , CancellationToken cancellationToken)
        {
            var interviewrs = await _interviewRepository.GetAllInterviewerAsync();
            return _mapper.Map<List<InterviewerReadDto>>(interviewrs);
        }
    }
}
