using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Exceptions;
using PreferenceRobot.Application.Features.Commands.User.LoginUser;
using PreferenceRobot.Application.Interfaces.Mail;
using PreferenceRobot.Application.Interfaces.Services;
using PreferenceRobot.Application.Interfaces.Tokens;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Domain.Entities.Identity;
using PreferenceRobot.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public AuthService(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager, IUserService userService = null, IMailService mailService = null)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }

        public async Task<Token> LoginAsync(string email, string password)
        {
           User? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundUserException();
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,password,false);
            if (result.Succeeded)
            {
                Token token = _tokenService.CreateToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken,user,token.Expiration,15);
                return token;

            }

            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            User? user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndTime > DateTime.UtcNow)
            {
                Token token = _tokenService.CreateToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            else
            {
                throw new NotFoundUserException();
            }
        }

        public async Task PasswordResetAsync(string email)
        {
            User? user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                resetToken=WebEncoders.Base64UrlEncode(tokenBytes);
                await _mailService.SendPasswordResetMailAsync(email,user.Id,resetToken);
            }
        }

        //UI TARAFINDAN TETİKLENİCEK  
        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null) 
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken=Encoding.UTF8.GetString(tokenBytes);
                return await _userManager.VerifyUserTokenAsync(user,
                    _userManager.Options.Tokens.PasswordResetTokenProvider,"ResetToken",resetToken);
            }
            return false;
        }
    }
}
