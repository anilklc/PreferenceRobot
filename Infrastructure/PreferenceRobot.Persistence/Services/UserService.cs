using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using PreferenceRobot.Application.DTOs.User;
using PreferenceRobot.Application.Exceptions;
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
                NameSurname = user.NameSurname,
                
            }, user.Password);
            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";
            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken,User user,DateTime tokenDate,int refreshTokenTime) 
        {

            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndTime = tokenDate.AddMinutes(15);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserException();
            }
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            User? user= await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);
                IdentityResult result= await _userManager.ResetPasswordAsync(user,resetToken,newPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                }
                else
                {
                    throw new PasswordChangeException();
                }
            }
        }
    }
}
