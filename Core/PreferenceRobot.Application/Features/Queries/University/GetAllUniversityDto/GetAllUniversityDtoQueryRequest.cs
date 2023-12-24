using MediatR;
using PreferenceRobot.Application.DTOs;

namespace PreferenceRobot.Application.Features.Queries.University.GetAllUniversityDto
{
    public class GetAllUniversityDtoQueryRequest :IRequest<GetAllUniversityDtoQueryResponse>
    {
    }
}
