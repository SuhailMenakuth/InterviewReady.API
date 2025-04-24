using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Area.Queries
{
    public class GetAllAreaQueryHandler : IRequestHandler<GetAllAreaQuery, List<AreaDto>>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        public  GetAllAreaQueryHandler( IAreaRepository areaRepository ,IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }
        public async Task<List<AreaDto>> Handle(GetAllAreaQuery request, CancellationToken cancellationToken)
        {
           var areas =  await _areaRepository.GetAllAsync();
           return  _mapper.Map<List<AreaDto>>(areas);
                     
        }
    }
}
