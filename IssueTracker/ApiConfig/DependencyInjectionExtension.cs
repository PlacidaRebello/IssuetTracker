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
            services.AddTransient<IIssuesEngine, IssuesEngine>();

            services.AddTransient<IIssueStatusLogic, IssueStatusLogic>();
            services.AddTransient<IIssueStatusEngine, IssueStatusEngine>();

            services.AddTransient<IIssueTypeLogic, IssueTypeLogic>();
            services.AddTransient<IIssueTypeEngine, IssueTypeEngine>();

            services.AddTransient<IRegisterLogic, RegisterLogic>();

            services.AddTransient<ISprintLogic, SprintLogic>();
            services.AddTransient<ISprintEngine, SprintEngine>();

            services.AddTransient<IReleaseLogic, ReleaseLogic>();
            services.AddTransient<IReleaseEngine, ReleaseEngine>();
        }
    }
}
