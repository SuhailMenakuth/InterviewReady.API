using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Application.Mappings
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Area, AreaDto>();
            CreateMap<Area, AreaCreateDto>().ReverseMap();
            CreateMap<Area ,AreaUpdateDto>().ReverseMap();
        }
    }
}
