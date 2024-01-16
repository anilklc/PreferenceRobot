using Azure.Core;
using Microsoft.AspNetCore.Identity;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Exceptions;
using PreferenceRobot.Application.Features.Commands.User.LoginUser;
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
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<Token> LoginAsync(string email, string password)
        {
           User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundUserException();
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,password,false);
            if (result.Succeeded)
            {
                Token token = _tokenService.CreateToken();
                return token;

            }

            throw new AuthenticationErrorException();
        }
    }
}
