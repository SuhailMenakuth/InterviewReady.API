using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Commands.EmailVerification
{
    public record SendOtpCommand(string Email) : IRequest<string>;

}
