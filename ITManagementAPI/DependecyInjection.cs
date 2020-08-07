using AutoMapper;
using FluentValidation;
using MediatR;
using MicroservicesTemplate.Common.Behaviour;
using ITManagementAPI.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ITManagementAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IContactService, CosmosContactService>();
            services.AddTransient<IDashboardService,DashboardService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}
