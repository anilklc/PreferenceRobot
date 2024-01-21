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
using PreferenceRobot.Domain.Entities;
using Microsoft.Extensions.Configuration;
using PreferenceRobot.Application.Interfaces.Services;
using PreferenceRobot.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PreferenceRobot.Domain.Entities.Identity;
using Microsoft.Extensions.Options;

namespace PreferenceRobot.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            services.AddIdentity<User,Role>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IUniversityReadRepository,UniversityReadRepository>();
            services.AddScoped<IUniversityWriteRepository,UniversityWriteRepository>();
            services.AddScoped<ICityReadRepository,CityReadRepository>();
            services.AddScoped<ICityWriteRepository,CityWriteRepository>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService,AuthService>();
            
            

            
            
        }
    }
}
