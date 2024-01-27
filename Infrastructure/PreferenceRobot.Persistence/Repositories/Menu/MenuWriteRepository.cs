using PreferenceRobot.Application.Interfaces.Repositories;
using PreferenceRobot.Domain.Entities;
using PreferenceRobot.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Repositories
{
    public class MenuWriteRepository : WriteRepository<Domain.Entities.Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
