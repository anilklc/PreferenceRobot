using PreferenceRobot.Application.DTOs.User;
using PreferenceRobot.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser user);
        Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime tokenDate, int refreshTokenTime);
        Task UpdatePasswordAsync(string userId,string resetToken,string newPassword);
        Task<List<ListUser>> GetAllUsersAsync();
        int TotalUsersCount { get; }
        Task AssignRoleToUserAsnyc(string userId, string[] roles);
        Task<string[]> GetRolesToUserAsync(string userIdOrName);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
