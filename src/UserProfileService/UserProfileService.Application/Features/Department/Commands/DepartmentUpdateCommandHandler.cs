using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Exceptions;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Department.Commands
{
    public class DepartmentUpdateCommandHandler : IRequestHandler<DepartmentUpdateCommand, string>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentUpdateCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Dto.Id) ?? throw new NotFoundException("Department not found.");
            //if (department == null)
            //{
            //    throw new ApplicationException("Department not found.");
            //}

            if (await _departmentRepository.IsDepartmentAlreadyExist(request.Dto.Name) && department.Name != request.Dto.Name)
            {
                throw new ApplicationException("Department already exists with this name.");
            }

            department.Name = request.Dto.Name;
            await _departmentRepository.UpdateAsync(department);

            return "Department updated successfully.";
        }
    }

}
