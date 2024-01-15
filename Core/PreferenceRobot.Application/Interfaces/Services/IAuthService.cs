using PreferenceRobot.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Token> LoginAsync(string email,string password);
    }
}
