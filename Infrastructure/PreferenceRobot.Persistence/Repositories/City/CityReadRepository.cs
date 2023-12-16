using PreferenceRobot.Application.Interfaces;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Repositories.City
{
    public class CityReadRepository : ReadRepository<PreferenceRobot.Domain.Entities.City>, ICityReadRepository
    {
        public CityReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
