using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileService.Application.Features.Department.Commands;
using UserProfileService.Application.Features.Department.Dtos;
using UserProfileService.Application.Features.Department.Queries;

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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartmentUpdateDto dto)
        {
          

            var command = new DepartmentUpdateCommand(dto);
            var result = await _sender.Send(command);
            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DepartmentDeleteCommand(id);
            var result = await _sender.Send(command);
            return Ok(result);
        }

      
        [HttpGet]   
        public async Task<ActionResult<List<DepartmentDto>>> GetAll()
        {
            var query = new GetAllDepartmentsQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            var query = new GetDepartmentByIdQuery(id);
            var result = await _sender.Send(query);
            return Ok(result);
        }
    }
}
