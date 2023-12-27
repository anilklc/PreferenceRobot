using PreferenceRobot.Application.Bases;
using PreferenceRobot.Application.Features.Commands.University.Exceptions;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.Rules
{
    public class UniversityRules : BaseRules
    {
        public Task UniversityTitleMustNotBeSame(IList<UniversityInfo> universities,string requestName) 
        {
            if (universities.Any(u => u.UniversityName == requestName)) throw new UniversityTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
