using IdentiService.Application.Interfaces.Repository;
using IdentiService.Application.Interfaces.Services;
using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Commands.EmailVerification
{
    public class SendOtpCommandHandler : IRequestHandler<SendOtpCommand, string>
    {
        private readonly IEmailService _emailService;
        private readonly IEmailVerificationRepository _otpRepo;
        private readonly IAuthRepository _authRepo;

        public SendOtpCommandHandler(IEmailService emailService, IEmailVerificationRepository otpRepo , IAuthRepository authRepo)
        {
            _emailService = emailService;
            _otpRepo = otpRepo;
            _authRepo = authRepo;
        }

        public async Task<string> Handle(SendOtpCommand request, CancellationToken cancellationToken)
        {
            var record = await _otpRepo.GetByEmailAsync(request.Email);

            if (record != null) 
                await _otpRepo.DeleteAsync(record);
            if (!await _authRepo.IsUserUnverifiedByEmailAsync(request.Email))
                throw new ApplicationException("email not found");

            var otp = new Random().Next(1000, 9999).ToString();

            var entity = new IdentityService.Domain.Entities.EmailVerification
            
            {
                Email = request.Email,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(2)   
            };

            await _otpRepo.AddAsync(entity);

            var subject = "Your OTP Code";
            var body = $"Your OTP code is: {otp}";
            await _emailService.SendEmailAsync(request.Email, subject, body);

            return "OTP sent successfully.";
        }
    }
}
