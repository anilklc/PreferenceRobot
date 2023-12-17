using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.RemoveUniversity
{
    public class RemoveUniversityCommandRequest : IRequest<RemoveUniversityCommandResponse>
    {
        public string Id {  get; set; }
    }
}
