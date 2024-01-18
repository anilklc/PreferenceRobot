using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreferenceRobot.Application.Features.Commands.University.CreateUniversity;
using PreferenceRobot.Application.Features.Commands.University.RemoveUniversity;
using PreferenceRobot.Application.Features.Commands.University.UpdateUniversity;
using PreferenceRobot.Application.Features.Queries.University.GetAllUniversity;
using PreferenceRobot.Application.Features.Queries.University.GetAllUniversityDto;
using PreferenceRobot.Application.Features.Queries.University.GetByIdUniversity;
using System.Net;

namespace PreferenceRobot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UniversitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            GetAllUniversityQueryResponse response = await _mediator.Send(new GetAllUniversityQueryRequest());
            return Ok(response);
        }

        
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdUniversityQueryRequest getByIdUniversityQueryRequest)
        {
            GetByIdUniversityQueryResponse response = await _mediator.Send(getByIdUniversityQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CreateUniversityCommandRequest createUniversityCommandRequest)
        {
            CreateUniversityCommandResponse createUniversityCommandResponse = await _mediator.Send(createUniversityCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute]RemoveUniversityCommandRequest removeUniversityCommandRequest)
        {
            RemoveUniversityCommandResponse removeUniversityCommandResponse = await _mediator.Send(removeUniversityCommandRequest);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromQuery] UpdateUniversityCommandRequest updateUniversityCommandRequest)
        {
            UpdateUniversityCommandResponse updateUniversityCommandResponse = await _mediator.Send(updateUniversityCommandRequest);
            return Ok();
        }

        [HttpGet("GetAllDto")]
        public async Task<IActionResult> GetAllDto()
        {
            GetAllUniversityDtoQueryResponse response = await _mediator.Send(new GetAllUniversityDtoQueryRequest());
            return Ok(response);
        }
    }
}
