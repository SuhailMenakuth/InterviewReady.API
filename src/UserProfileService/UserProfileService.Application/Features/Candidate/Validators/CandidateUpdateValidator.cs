using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Application.Features.Candidate.Dtos;

namespace UserProfileService.Application.Features.Candidate.Validators
{
    public class CandidateUpdateValidator : AbstractValidator<CandidateUpdateDto>
    {
        public CandidateUpdateValidator()
        {
            RuleFor(x => x.cv)
                .NotEmpty()
                .WithMessage("CV is required.")
                .Must(file => HasValidExtension(file.FileName))
                .WithMessage("Only PDF and DOCX files are allowed.");

            RuleFor(x => x.cv.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024) 
                .WithMessage("CV must be less than 5 MB.");

            RuleFor(x => x.highestEducation)
                .NotEmpty()
                .WithMessage("eduction cannot be null");
            RuleFor(x => x.photo)
                .NotEmpty()
                .WithMessage("photo cannot be empty");
        }

        private bool HasValidExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return false;

            var allowedExtensions = new[] { ".pdf", ".docx" };
            var fileExtension = Path.GetExtension(fileName).ToLower();

            return allowedExtensions.Contains(fileExtension);
        }

    }
}
