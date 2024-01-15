using Azure.Core;
using Microsoft.AspNetCore.Identity;
using PreferenceRobot.Application.DTOs.User;
using PreferenceRobot.Application.Features.Commands.User.CreateUser;
using PreferenceRobot.Application.Interfaces.Services;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser user)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                UserName = user.Username,
                Email = user.Email,
                NameSurname = user.FirstName,
                
            }, user.Password);
            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";
            return response;
        }
    }
}
