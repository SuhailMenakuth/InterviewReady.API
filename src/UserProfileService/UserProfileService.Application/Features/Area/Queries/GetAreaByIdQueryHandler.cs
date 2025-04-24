using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Area.Queries
{
    public class GetAreaByIdQueryHandler : IRequestHandler<GetAreaByIdQuery , AreaDto>
    {
        private readonly IAreaRepository _areaRepository;

        private readonly IMapper _mapper;
        public GetAreaByIdQueryHandler(IAreaRepository areaRepository , IMapper mapper) 
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        public async Task<AreaDto> Handle(GetAreaByIdQuery request , CancellationToken cancellationToken)
        {
          
            var area = await _areaRepository.GetByIdAsync(request.id) ?? throw new ApplicationException("Area not found");
            return _mapper.Map<AreaDto>(area);
        }
    }
}
