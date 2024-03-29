﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Domain.Entities.Identity
{
    public class Role : IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
