using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Interfaces.Repository;

namespace UserProfileService.Application.Features.Department.Commands
{
    public class DepartmentDeleteCommandHandler : IRequestHandler<DepartmentDeleteCommand, string>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentDeleteCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<string> Handle(DepartmentDeleteCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id) ?? throw new Exception("Department not found");
          

            await _departmentRepository.DeleteAsync(department);
            return "Department deleted successfully.";
        }
    }

}
