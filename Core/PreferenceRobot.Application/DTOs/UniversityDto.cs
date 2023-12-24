using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.DTOs
{
    public class UniversityDto
    {
        public string UniversityName { get; set; }
        public Guid CityId { get; set; }
        public string Website { get; set; }
        public string CityName { get; set; }
    }
}
