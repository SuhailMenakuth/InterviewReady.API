using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UserProfileService.Application.Features.Interviewer.Commands;
using UserProfileService.Application.Features.Interviewer.Dtos;
using UserProfileService.Application.Features.Interviewer.Queries;

namespace UserProfileService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly ISender _sender;

        public InterviewerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add(InterviewerCreateDto interviewerCreateDto)
        {
            var command = new InterviewerCreateCommand(interviewerCreateDto);
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<InterviewerReadDto>>> Interviewers()
        {
            var query = new GetAllInterviewersQuery();
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewerReadDto>> Interviewer(Guid id)
        {
            var query = new GetInterviewerByIdQuery(id);
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpGet("area{id}")]
        public async Task<ActionResult<List<InterviewerReadDto>>> InterviewersByAreaId(int id)
        {
            var query = new GetAllInterviewersByAreaIdQuery(id);
            var result = await _sender.Send(query);
            return Ok(result);
        }
    }
}
