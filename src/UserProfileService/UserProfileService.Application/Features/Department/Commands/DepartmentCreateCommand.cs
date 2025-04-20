using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Department.Dtos;

namespace UserProfileService.Application.Features.Department.Commands
{
    public record DepartmentCreateCommand(DepartmentCreateDto dto ) : IRequest<string> ;
    
}
