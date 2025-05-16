using AutoMapper;
using IdentiService.Application.Features.Auth.Dtos;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User , UserReadDto>();
        }
    }
}
