using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Dtos
{
    public record VerifyOtpRequestDto(string Email, string Otp);
}
