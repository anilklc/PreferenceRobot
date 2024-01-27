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
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        public MenuReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
