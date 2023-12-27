using PreferenceRobot.Application.Bases;
using PreferenceRobot.Application.Features.Commands.City.Exceptions;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.Rules
{
    public class CityRules : BaseRules
    {
        public Task CityTitleMustNotBeSame(IList<Domain.Entities.City> cities,string requestName)
        {
            if (cities.Any(c => c.CityName == requestName)) throw new CityTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
