using PreferenceRobot.Application.Interfaces.Repositories;
using PreferenceRobot.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Persistence.Repositories
{
    public class EndpointWriteRepository : WriteRepository<Domain.Entities.Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
