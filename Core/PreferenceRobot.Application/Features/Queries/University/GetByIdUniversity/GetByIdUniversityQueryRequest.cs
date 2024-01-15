using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.University.GetByIdUniversity
{
    public class GetByIdUniversityQueryRequest : IRequest<GetByIdUniversityQueryResponse>
    {
        public string? Id { get; set; }
    }
}
