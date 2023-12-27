using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PreferenceRobot.Application.Bases;
using PreferenceRobot.Application.Exceptions;
using PreferenceRobot.Application.Mapping;
using PreferenceRobot.Application.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidator<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }

    }
}
