using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserProfileService.Application.Features.Candidate.Commands;
using UserProfileService.Application.Features.Candidate.Dtos;
using UserProfileService.Application.Features.Candidate.Queries;
using UserProfileService.Domain.Entities.Candidate;

namespace UserProfileService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ISender _sender;
        public CandidateController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPatch("update-profile")]
        public async Task<ActionResult<Guid>> CandidateUpdate([FromForm] CandidateUpdateDto dto)
        {
            var userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var command = new CandidateUpdateCommand
            {
                dto = dto,
                id = userId
            };
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpGet("isprofile-completed")]
        public async Task<ActionResult<bool>> IsProfileCompleted()
        {
            var userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var command = new CandidateIsProfileCompletedCommand(userId);
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpPost("skill")]
        public async Task<IActionResult> AddSkill(string skill)
        {
            if (string.IsNullOrWhiteSpace(skill))
                throw new ArgumentNullException(nameof(skill));
            var userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var command = new CandidateCreateSkillCommand
            {
                candidateId = userId,
                skillName = skill
            };
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpGet("skill/getAll")]
        public async Task<IActionResult> GetAllCandidateSkill()
        {
            var userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var query = new GetAllCandidateSkillQuery(userId);
            var result = await _sender.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateSkillById(Guid id)
        {
            var userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var command = new DeleteCandidateSkillByIdCommand(id);
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpGet("my-details")]
        public async Task<ActionResult<CandidateDetailsReadDto>> GetCandidateDetailsById()
        {
            var userId = Guid.Parse(HttpContext.Items["UserId"].ToString());
            var query = new GetCandidateDetailsQuery(userId);
            var result = await _sender.Send(query);
            return Ok(result);
        }
    }
}
