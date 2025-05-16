using IdentiService.Application.Features.Auth.Dtos;
using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Queries
{
    public record GetUserByIdQuery(Guid id) : IRequest<UserReadDto>; 
    
}
