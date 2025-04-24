using FluentValidation;
using IdentiService.Application.Features.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator() {
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("email cannotbe empty")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.password)
                .NotEmpty().WithMessage("password cannot be empty");
        
        }
    }
}
