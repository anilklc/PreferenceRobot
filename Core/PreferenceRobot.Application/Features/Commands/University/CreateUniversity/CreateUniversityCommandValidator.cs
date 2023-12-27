using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.CreateUniversity
{
    public class CreateUniversityCommandValidator :AbstractValidator<CreateUniversityCommandRequest>
    {
        public CreateUniversityCommandValidator() 
        {
            RuleFor(u => u.UniversityName).NotNull().NotEmpty().MinimumLength(5).WithName("Üniversite");
            RuleFor(u => u.CityId).NotEmpty().NotNull();
        }
    }
}
