using PreferenceRobot.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Domain.Entities
{
    public class UniversityInfo : BaseEntity
    {
        public string UniversityName { get; set; }
        public Guid City { get; set; }
    }
}
