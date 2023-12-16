using PreferenceRobot.Application.Interfaces;
using PreferenceRobot.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Repositories.City
{
    public class CityWriteRepository : WriteRepository<PreferenceRobot.Domain.Entities.City>, ICityWriteRepository
    {
        public CityWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
