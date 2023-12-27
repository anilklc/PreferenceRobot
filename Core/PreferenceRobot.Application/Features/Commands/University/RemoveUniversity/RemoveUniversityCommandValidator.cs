using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.RemoveUniversity
{
    public class RemoveUniversityCommandValidator : AbstractValidator<RemoveUniversityCommandRequest>
    {
        public RemoveUniversityCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty().NotNull().WithName("Id");
        }
    }
}
