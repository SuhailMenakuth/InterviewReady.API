using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;

namespace UserProfileService.Application.Features.Area.Queries
{
    public class GetAllAreaQuery() : IRequest<List<AreaDto>>;
    
}
