using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Interviewer.Dtos;

namespace UserProfileService.Application.Features.Interviewer.Validators
{
    public class CreateInterviewerValidator : AbstractValidator<InterviewerCreateDto>
    {
        public CreateInterviewerValidator() 
        {
            RuleFor(x => x.name)
                   .NotEmpty().WithMessage("Name cannot be empty ");
            RuleFor(x => x.photo)
                .NotNull().WithMessage("Photo Cannot be empty ");
            RuleFor(x => x.expertiseAreaIds)
                .NotEmpty().WithMessage("atleast some area of expertise is required");
                

        }
    }
}
