using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PreferenceRobot.Application.Interfaces.Tokens;
using PreferenceRobot.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
      AddJwtBearer("Admin", options =>
      {
          options.TokenValidationParameters = new()
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidAudience = configuration["Token:Audience"],
              ValidIssuer = configuration["Token:Issuer"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Secret"])),
              LifetimeValidator = (notBefore,expires,securityToken,validationParameters)=>expires !=null ? expires>DateTime.Now:false
              
          };


      });
        } 

    }
}
