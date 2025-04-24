using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Area.Commands
{
    public class AreaUpdateCommandHandler : IRequestHandler<AreaUpdateCommand , string>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        public AreaUpdateCommandHandler(IAreaRepository areaRepository , IMapper mapper) 
        { 
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        //public Task<string> Handle(AreaUpdateCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<string> Handle(AreaUpdateCommand request , CancellationToken cancellationToken)
        {
            var existing = await _areaRepository.GetByIdAsync(request.areaUpdateDto.Id) ?? throw new ApplicationException("Area not found.");
            

            if (await _areaRepository.IsAreaAlreadyExist(request.areaUpdateDto.DepartmentId, request.areaUpdateDto.Name)
                && !string.Equals(existing.Name, request.areaUpdateDto.Name, StringComparison.OrdinalIgnoreCase))
            {
                throw new ApplicationException("Another area with the same name exists in this department.");
            }

            _mapper.Map(request.areaUpdateDto, existing);
            await _areaRepository.UpdateAsync(existing);
            return "Area updated successfully.";
        }
    }
}
