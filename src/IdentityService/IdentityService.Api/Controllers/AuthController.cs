using IdentiService.Application.Features.Auth.Commands.EmailVerification;
using IdentiService.Application.Features.Auth.Commands.LoginUser;
using IdentiService.Application.Features.Auth.Commands.RegisterUser;
using IdentiService.Application.Features.Auth.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto dto, CancellationToken cancellationToken)
        {
            var command = new RegisterUserCommand(
                dto.fullName,
                dto.email,
                dto.phoneNumber,
                dto.password
            );

            var result = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto , CancellationToken cancellationToken)
        {
            var command = new LoginUserCommand(userLoginDto);
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(new { message = "login successfull" , token = result});
        }
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpRequestDto dto , CancellationToken cancellationToken)
        {
            var command = new SendOtpCommand(dto.email);
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(new { Message = result });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDto dto ,CancellationToken cancellationToken)
        {
            var command = new VerifyOtpCommand(dto.Email, dto.Otp);
            var result = await _mediator.Send(command,cancellationToken);
            return Ok(new { Message = result });
        }
    }
} 