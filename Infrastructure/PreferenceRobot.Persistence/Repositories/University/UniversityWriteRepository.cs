using PreferenceRobot.Application.Interfaces.Repositories.University;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Repositories.University
{
    public class UniversityWriteRepository : WriteRepository<UniversityInfo>, IUniversityWriteRepository
    {
        public UniversityWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
