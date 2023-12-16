﻿using PreferenceRobot.Application.Interfaces.Repositories;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Interfaces
{
    public interface ICityReadRepository :IReadRepository<City>
    {
    }
}
