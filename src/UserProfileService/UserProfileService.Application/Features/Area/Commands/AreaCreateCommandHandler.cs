using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Area.Commands
{
    public class AreaCreateCommandHandler : IRequestHandler<AreaCreateCommand , string>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaCreateCommandHandler(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(AreaCreateCommand request, CancellationToken cancellationToken)
        {
            if (await _areaRepository.IsAreaAlreadyExist(request.createAreaDto.departmentId, request.createAreaDto.name))
                throw new ApplicationException("Area already exists under this department.");

            var area = _mapper.Map<UserProfileService.Domain.Entities.Admin.Area>(request.createAreaDto);
            await _areaRepository.AddAsync(area);
            return "Area created successfully.";
        }
    }
}
