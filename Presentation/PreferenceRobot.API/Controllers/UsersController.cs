using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreferenceRobot.Application.Features.Commands.City.UpdateCity;
using PreferenceRobot.Application.Features.Commands.User.CreateUser;
using PreferenceRobot.Application.Features.Commands.User.LoginUser;

namespace PreferenceRobot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody]UpdateCityCommandRequest updateCityCommandRequest)
        {
            UpdateCityCommandResponse response = await _mediator.Send(updateCityCommandRequest);
            return Ok(response);
        }

    }
}
