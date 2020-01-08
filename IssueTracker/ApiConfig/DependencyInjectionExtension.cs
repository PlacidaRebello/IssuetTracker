using BussinessLogic;
using BussinessLogic.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker.ApiConfig
{
    public static class DependencyInjectionExtension
    {
        public static void AddCustomTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IIssuesLogic, IssuesLogic>();
            services.AddTransient<IIssuesPersistence, IssuesEngine>();

            services.AddTransient<IStatusLogic, StatusLogic>();
            services.AddTransient<IStatusPersistence, StatusEngine>();

            services.AddTransient<IIssueTypeLogic, IssueTypeLogic>();
            services.AddTransient<IIssueTypePersistence, IssueTypeEngine>();

            services.AddTransient<IRegisterLogic, RegisterLogic>();

            services.AddTransient<ISprintLogic, SprintLogic>();
            services.AddTransient<ISprintPersistence, SprintEngine>();

            services.AddTransient<IReleaseLogic, ReleaseLogic>();
            services.AddTransient<IReleasePersistence, ReleaseEngine>();
        }
    }
}
