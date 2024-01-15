using MediatR;
using Microsoft.AspNetCore.Identity;
using PreferenceRobot.Application.DTOs.User;
using PreferenceRobot.Application.Exceptions;
using PreferenceRobot.Application.Interfaces.Services;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.User> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result= await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                NameSurname=request.NameSurname,
                Email=request.Email,
                UserName=request.Username,
            },request.Password);

            CreateUserCommandResponse response= new() { Succeeded=result.Succeeded};

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı Oluşturuldu.";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }
            return response;
        }
    }
}
