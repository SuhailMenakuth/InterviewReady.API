using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Application.Interfaces.Service;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Application.Features.Interviewer.Commands
{
    public class InterviewerCreateCommandHnadler : IRequestHandler<InterviewerCreateCommand, Guid>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IInterviewRepository _interviewerRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        public InterviewerCreateCommandHnadler( IAreaRepository areaRepository , IInterviewRepository interviewRepository , IMapper mapper , ICloudinaryService cloudinaryService) 
        {
            _areaRepository = areaRepository;    
            _interviewerRepository = interviewRepository; 
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Guid> Handle(InterviewerCreateCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var interviewer = _mapper.Map<Domain.Entities.Interviewer.Interviewer>(dto);
            interviewer.Id = Guid.NewGuid();
            interviewer.Photo =    await _cloudinaryService.UploadImageAsync(request.Dto.photo);

            var areas = await _areaRepository.GetAreasByIdsAsync(dto.expertiseAreaIds, cancellationToken);
                
            interviewer.InterviewerExpertiseAreas = areas.Select(area => new InterviewerExpertiseArea
            {
                InterviewerId = interviewer.Id,
                ExpertiseAreaId = area.Id
            }).ToList();


            var id = await _interviewerRepository.AddInterviewerAsync(interviewer);
            return id;
        }
    }
}
