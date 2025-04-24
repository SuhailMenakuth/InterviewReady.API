using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Area.Commands
{
    public class AreaDeleteCommandHandler : IRequestHandler<AreaDeleteCommand , string>
    {
        private readonly IAreaRepository _areaRepository;
        public AreaDeleteCommandHandler(IAreaRepository areaRepository) 
        {
            _areaRepository = areaRepository;
        }

        public async Task<string> Handle(AreaDeleteCommand request , CancellationToken cancellationToken)
        {
            var existing = await _areaRepository.GetByIdAsync(request.id) ?? throw new ApplicationException("Area Not found");
            await _areaRepository.DeleteAsync(existing);
            return "Area Deleted Successfully";
        }
    }
}
