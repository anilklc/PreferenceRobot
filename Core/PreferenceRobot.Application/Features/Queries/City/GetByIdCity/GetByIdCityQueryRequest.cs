using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.City.GetByIdCity
{
    public class GetByIdCityQueryRequest : IRequest<GetByIdCityQueryResponse>
    {
        public string Id { get; set; }
    }
}
