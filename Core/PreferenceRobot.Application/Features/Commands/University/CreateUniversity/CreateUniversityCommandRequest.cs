using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.CreateUniversity
{
    public class CreateUniversityCommandRequest :IRequest<CreateUniversityCommandResponse>
    {
        public string UniversityName { get; set; }
        public Guid CityId { get; set; }
        public string WebSite {  get; set; }
    }
}
