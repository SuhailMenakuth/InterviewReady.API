using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Department.Dtos;
using UserProfileService.Domain.Entities.Admin;

namespace UserProfileService.Application.Mappings
{
    public class DepartmentProfile : Profile
    {
        DepartmentProfile() {

            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
        
        }
    }
}
