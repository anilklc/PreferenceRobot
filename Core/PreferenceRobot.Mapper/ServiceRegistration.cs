using Microsoft.Extensions.DependencyInjection;
using PreferenceRobot.Application.Interfaces.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
