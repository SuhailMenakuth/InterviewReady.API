using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Interviewer.Queries
{
    public class GetAllInterviewersByAreaIdQueryHandler : IRequestHandler<GetAllInterviewersByAreaIdQuery, List<InterviewerReadDto>>
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;

        public GetAllInterviewersByAreaIdQueryHandler(IInterviewRepository interviewRepository ,  IMapper mapper)
        {
            _interviewRepository = interviewRepository;
            _mapper = mapper;
        } 

        public async Task<List<InterviewerReadDto>> Handle(GetAllInterviewersByAreaIdQuery request , CancellationToken cancellationToken)
        {
            var result = await _interviewRepository.GetInterviewerByAreaAsync(request.id);
            return _mapper.Map<List<InterviewerReadDto>>(result);


        }
    }
    
}
