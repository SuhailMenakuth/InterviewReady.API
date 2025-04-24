using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Features.Department.Commands
{
    public record DepartmentDeleteCommand(int Id) : IRequest<string>;
}