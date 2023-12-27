using PreferenceRobot.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.Exceptions
{
    public class CityTitleMustNotBeSameException : BaseExceptions
    {
        public CityTitleMustNotBeSameException() : base("Bu şehir daha önce eklenmiş.") { }
    }
}
