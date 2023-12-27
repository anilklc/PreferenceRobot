using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommandRequest>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(c => c.CityName).NotNull().NotEmpty().MinimumLength(5).WithName("City");
        }
    }
}
