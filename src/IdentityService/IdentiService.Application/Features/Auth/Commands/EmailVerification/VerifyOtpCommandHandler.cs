using IdentiService.Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Commands.EmailVerification
{
    public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, string>
    {
        private readonly IEmailVerificationRepository _otpRepo;
        private readonly IAuthRepository _authRepo;

        public VerifyOtpCommandHandler(IEmailVerificationRepository otpRepo , IAuthRepository authRepo)
        {
            _otpRepo = otpRepo;
            _authRepo = authRepo;
        }

        public async Task<string> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            var user = await _authRepo.GetUserByEmailAsync(request.Email) ?? throw new Exception("user not found");

            var record = await _otpRepo.GetByEmailAsync(request.Email) ?? throw new ApplicationException("No OTP found for this email.");

            if (record.ExpiryTime < DateTime.UtcNow)
                throw new ApplicationException("OTP expired.");


            if (record.Otp != request.Otp)
                throw new ApplicationException("Invalid OTP.");

            user.IsVerified = true;

            await _authRepo.UpdateUserAsync();

            await _otpRepo.DeleteAsync(record);



            return "OTP verified successfully.";
        }
    }

}
