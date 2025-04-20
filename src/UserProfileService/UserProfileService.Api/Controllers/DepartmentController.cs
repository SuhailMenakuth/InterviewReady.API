using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileService.Application.Features.Department.Commands;
using UserProfileService.Application.Features.Department.Dtos;

namespace UserProfileService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ISender _sender;
        public DepartmentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDto dto)
        {
         

            var command = new DepartmentCreateCommand(dto);
            var result = await _sender.Send(command);

            return Ok(result);
        }
    }
}
