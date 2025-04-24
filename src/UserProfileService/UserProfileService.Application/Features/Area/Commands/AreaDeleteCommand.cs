using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileService.Application.Features.Area.Commands
{
    public record AreaDeleteCommand(int id) : IRequest<string>;
    
}
