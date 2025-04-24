using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileService.Application.Features.Area.Commands;
using UserProfileService.Application.Features.Area.Dtos;
using UserProfileService.Application.Features.Area.Queries;

namespace UserProfileService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly ISender _sernder;
        public AreaController(ISender sender)
        {
            _sernder = sender;
        }

        [HttpPost  ]
        public async Task<IActionResult> Create([FromBody] AreaCreateDto areaCreateDto)
        {
            var command = new AreaCreateCommand(areaCreateDto);
            var result = await _sernder.Send(command);
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AreaUpdateDto areaUpdateDto)
        {
            var command = new AreaUpdateCommand(areaUpdateDto);
            var result = await _sernder.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new AreaDeleteCommand(id);
            var result = await _sernder.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<AreaDto>>> AllAreas()
        {
            var query = new GetAllAreaQuery();
            var result = await _sernder.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaDto>> AreaById( int id)
        {
            var query = new GetAreaByIdQuery(id);
            var result = await _sernder.Send(query);
            return Ok(result);

        }
    }
}
