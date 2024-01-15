using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Exceptions;
using PreferenceRobot.Application.Interfaces.Services;
using PreferenceRobot.Application.Interfaces.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.User> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.User> userManager, SignInManager<Domain.Entities.Identity.User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.User user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundUserException();
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
            if (result.Succeeded) 
            {
                Token token = _tokenService.CreateToken();
                return new LoginUserSuccessCommandResponse()
                {
                    Token=token,
                };

            }

            throw new AuthenticationErrorException();
        }
    }
}

