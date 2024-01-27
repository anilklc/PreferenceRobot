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
    public class EndpointReadRepository : ReadRepository<Domain.Entities.Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
