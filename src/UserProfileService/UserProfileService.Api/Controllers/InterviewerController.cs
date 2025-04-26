using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfileService.Application.Features.Interviewer.Commands;
using UserProfileService.Application.Features.Interviewer.Dtos;

namespace UserProfileService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly ISender _sender;

        public InterviewerController( ISender sender)
        { 
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add(InterviewerCreateDto interviewerCreateDto)
        {
            var command = new InterviewerCreateCommand(interviewerCreateDto);
            var result  = await _sender.Send(command);
            return Ok(result);
        } 
    }
}
