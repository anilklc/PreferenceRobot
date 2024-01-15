using Microsoft.AspNetCore.Identity;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Exceptions;
using PreferenceRobot.Application.Interfaces.Services;
using PreferenceRobot.Application.Interfaces.Tokens;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Domain.Entities.Identity;
using PreferenceRobot.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Token> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new NotFoundUserException();
            bool result = await _userManager.CheckPasswordAsync(user,password);
            if (result) 
            {
                Token token = _tokenService.CreateToken();
                string refreshToken = _tokenService.GenerateRefreshToken();
                return token;
            }
            throw new AuthenticationErrorException();
        }
    }
}
