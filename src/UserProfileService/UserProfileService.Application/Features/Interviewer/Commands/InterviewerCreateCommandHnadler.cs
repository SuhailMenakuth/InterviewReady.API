using AutoMapper;
using InterviewReady.Messaging.Contracts.Enums;
using MediatR;
using UserProfileService.Application.Interfaces.Events;
using UserProfileService.Application.Interfaces.Repository;
using UserProfileService.Application.Interfaces.Service;
using UserProfileService.Domain.Entities.Interviewer;
using UserProfileService.Infrastructure.Messaging.Events;

namespace UserProfileService.Application.Features.Interviewer.Commands
{
    public class InterviewerCreateCommandHandler : IRequestHandler<InterviewerCreateCommand, Guid>
{
    private readonly IAreaRepository _areaRepository;
    private readonly IInterviewRepository _interviewerRepository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IUserEventPublisher _userEventPublisher;

    public InterviewerCreateCommandHandler(
        IAreaRepository areaRepository,
        IInterviewRepository interviewerRepository,
        IMapper mapper,
        ICloudinaryService cloudinaryService,
        IUserEventPublisher userEventPublisher)
    {
        _areaRepository = areaRepository;
        _interviewerRepository = interviewerRepository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
        _userEventPublisher = userEventPublisher;
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

            await _userEventPublisher.PublishInterviewerCreatedAsync(new InterviewerCreatedEvent
            {
                UserId = id,
                Email = request.Dto.email,
                PhoneNumber = request.Dto.phone,
                Password = dto.password,
                UserType = UserType.Interviewer
            });

           


            return id;
        }
    }
}
