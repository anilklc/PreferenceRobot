using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.UpdateUniversity
{
    public class UpdateUniversityCommandValidator :AbstractValidator<UpdateUniversityCommandRequest>
    {
        public UpdateUniversityCommandValidator() 
        {
            RuleFor(u => u.Id).NotNull().NotEmpty().WithName("Id");
            RuleFor(u => u.UniversityName).NotNull().NotEmpty().MinimumLength(5).WithName("Üniversite Adı");
            RuleFor(u => u.CityId).NotNull().NotEmpty().WithName("Şehir");

        }
    }
}
