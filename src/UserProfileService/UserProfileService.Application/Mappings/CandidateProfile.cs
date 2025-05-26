using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Candidate.Commands;
using UserProfileService.Application.Features.Candidate.Dtos;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Application.Mappings
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
            
        {
            CreateMap<CandidateUpdateDto, Candidate>();
            CreateMap<CandidateCreateSkillCommand, CandidateSkill>();
            CreateMap<CandidateSkillReadDto, CandidateSkill>().ReverseMap();
            CreateMap<Candidate, CandidateDetailsReadDto>();
        }
    }
}
