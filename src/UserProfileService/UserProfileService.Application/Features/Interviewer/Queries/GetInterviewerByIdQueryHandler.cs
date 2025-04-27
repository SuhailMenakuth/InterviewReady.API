using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;
using UserProfileService.Application.Features.Interviewer.Queries;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Interviewer.Queries
{
    
    public class GetInterviewerByIdQueryHandler : IRequestHandler<GetInterviewerByIdQuery, InterviewerReadDto>
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;
        public GetInterviewerByIdQueryHandler(IInterviewRepository interviewRepository , IMapper mapper)
        {
            _interviewRepository = interviewRepository;
            _mapper = mapper;   
        }
    
        public async Task<InterviewerReadDto> Handle(GetInterviewerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _interviewRepository.GetInterviewerByIdAsync(request.id);
            return _mapper.Map<InterviewerReadDto>(result);
        }
    }
}