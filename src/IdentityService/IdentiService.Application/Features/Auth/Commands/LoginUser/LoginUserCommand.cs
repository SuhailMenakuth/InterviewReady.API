using IdentiService.Application.Features.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentiService.Application.Features.Auth.Commands.LoginUser
{
    public record LoginUserCommand(UserLoginDto userLoginDto) : IRequest<string>;
}
