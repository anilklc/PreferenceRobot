using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.UpdateUniversity
{
    public class UpdateUniversityCommandRequest :IRequest<UpdateUniversityCommandResponse>
    {
        public string Id { get; set; }
        public string UniversityName { get; set; }
        public string CityId { get; set; }
        public string Website {  get; set; }

    }
}
