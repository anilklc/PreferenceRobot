using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Token CreateToken();
        string GenerateRefreshToken();
    }
}
