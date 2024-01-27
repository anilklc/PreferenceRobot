using MediatR;

namespace PreferenceRobot.Application.Features.Queries.User.GetRolesToUser
{
    public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
    {
        public string UserId { get; set; }

    }
}