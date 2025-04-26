using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;
using UserProfileService.Domain.Entities.Interviewer;

namespace UserProfileService.Application.Mappings
{
    public class InterviewerProfile : Profile
    {
        public InterviewerProfile() 
        {
            CreateMap<InterviewerCreateDto, Interviewer>()
                   .ForMember(dest => dest.InterviewerExpertiseAreas, opt => opt.Ignore()).ReverseMap();
        }
    }
}
