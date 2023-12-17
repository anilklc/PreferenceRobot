using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.RemoveCity
{
    public class RemoveCityCommandRequest : IRequest<RemoveCityCommandResponse>
    {
        public string Id { get; set; }
    }
}
