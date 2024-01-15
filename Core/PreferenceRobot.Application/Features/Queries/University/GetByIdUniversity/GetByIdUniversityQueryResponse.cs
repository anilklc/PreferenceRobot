using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.University.GetByIdUniversity
{
    public class GetByIdUniversityQueryResponse
    {
        public string? UniversityName { get; set; }
        public Guid CityId { get; set; }
        public string? Website { get; set; }
    }
}
