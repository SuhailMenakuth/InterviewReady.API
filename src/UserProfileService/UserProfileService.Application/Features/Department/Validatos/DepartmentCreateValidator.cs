using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Department.Dtos;

namespace UserProfileService.Application.Features.Department.Validatos
{
    public class DepartmentCreateValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Department cannot be empty");
        }
    }
}
