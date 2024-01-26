using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreferenceRobot.Application.Consts;
using PreferenceRobot.Application.CustomAttributes;
using PreferenceRobot.Application.Enums;
using PreferenceRobot.Application.Features.Commands.City.CreateCity;
using PreferenceRobot.Application.Features.Commands.City.RemoveCity;
using PreferenceRobot.Application.Features.Commands.City.UpdateCity;
using PreferenceRobot.Application.Features.Queries.City.GetAllCity;
using PreferenceRobot.Application.Features.Queries.City.GetByIdCity;
using System.Net;

namespace PreferenceRobot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCityQueryResponse response = await _mediator.Send(new GetAllCityQueryRequest());
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get([FromQuery] GetByIdCityQueryRequest getByIdCityQueryRequest)
        {
            GetByIdCityQueryResponse response = await _mediator.Send(getByIdCityQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Cities, ActionType = ActionType.Writing, Definition = "Add City")]

        public async Task<IActionResult> Add([FromQuery] CreateCityCommandRequest createCityCommandRequest)
        {
            CreateCityCommandResponse createCityCommandResponse = await _mediator.Send(createCityCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Cities, ActionType = ActionType.Deleting, Definition = "Remove City")]
        public async Task<IActionResult> Remove([FromRoute] RemoveCityCommandRequest removeCityCommandRequest)
        {
            RemoveCityCommandResponse removeCityCommandResponse = await _mediator.Send(removeCityCommandRequest);
            return Ok();
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Cities, ActionType = ActionType.Updating, Definition = "Update City")]
        public async Task<IActionResult> Update([FromQuery] UpdateCityCommandRequest updateCityCommandRequest)
        {
            UpdateCityCommandResponse updateCityCommandResponse = await _mediator.Send(updateCityCommandRequest);
            return Ok();
        }
    }
}
