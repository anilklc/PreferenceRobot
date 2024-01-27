using MediatR;

namespace PreferenceRobot.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandRequest :IRequest<DeleteRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}