using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PreferenceRobot.Application.Interfaces;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using PreferenceRobot.Persistence.Repositories.City;
using PreferenceRobot.Persistence.Repositories.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreferenceRobot.Persistence.Context;

namespace PreferenceRobot.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.ConfiguraionString));
            services.AddScoped<IUniversityReadRepository,UniversityReadRepository>();
            services.AddScoped<IUniversityWriteRepository,UniversityWriteRepository>();
            services.AddScoped<ICityReadRepository,CityReadRepository>();
            services.AddScoped<ICityWriteRepository,CityWriteRepository>();
        }
    }
}
