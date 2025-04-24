using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Area.Dtos;

namespace UserProfileService.Application.Features.Area.Validators
{
    public class CreateAreaValidator : AbstractValidator<AreaCreateDto>
    {
        public CreateAreaValidator() {
            RuleFor(x => x.departmentId)
                .NotEmpty().WithMessage("Department Id cannot be null");

            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Area Cannot be null");
        
        }
    }
}
