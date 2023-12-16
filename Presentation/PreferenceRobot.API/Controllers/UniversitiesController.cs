using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreferenceRobot.Application.Features.Queries.University.GetAllUniversity;
using PreferenceRobot.Application.Features.Queries.University.GetByIdUniversity;

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
    }
}
