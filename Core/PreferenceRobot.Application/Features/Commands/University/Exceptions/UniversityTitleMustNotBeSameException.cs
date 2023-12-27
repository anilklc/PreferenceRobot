using PreferenceRobot.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.Exceptions
{
    public class UniversityTitleMustNotBeSameException : BaseExceptions
    {
        public UniversityTitleMustNotBeSameException() : base("Üniversite daha önceden eklenmiş.")
        {
            
        }
    }
}
