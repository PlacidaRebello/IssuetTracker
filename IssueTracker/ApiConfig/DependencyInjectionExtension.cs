using BussinessLogic;
using BussinessLogic.Interfaces;
using BussinessLogic.Logic;
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

            services.AddTransient<IDragDropLogic, DragDropLogic>();

            services.AddTransient<IIssueStatusLogic, IssueStatusLogic>();
            services.AddTransient<IIssueStatusEngine, IssueStatusEngine>();

            services.AddTransient<IIssueTypeLogic, IssueTypeLogic>();
            services.AddTransient<IIssueTypeEngine, IssueTypeEngine>();

            services.AddTransient<IRegisterLogic, RegisterLogic>();
            services.AddTransient<IUsersLogic, UsersLogic>();
            services.AddTransient<IUsersEngine, UsersEngine>();

            services.AddTransient<ISprintLogic, SprintLogic>();
            services.AddTransient<ISprintEngine, SprintEngine>();

            services.AddTransient<IReleaseLogic, ReleaseLogic>();
            services.AddTransient<IReleaseEngine, ReleaseEngine>();
        }
    }
}
