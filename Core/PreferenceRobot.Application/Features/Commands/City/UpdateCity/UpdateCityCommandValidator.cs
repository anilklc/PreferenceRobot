using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommandRequest>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(c => c.CityName).NotNull().NotEmpty().MinimumLength(5).WithName("City");
        }
    }
}
