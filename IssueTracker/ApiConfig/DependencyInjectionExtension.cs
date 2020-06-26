using BussinessLogic;
using BussinessLogic.Interfaces;
using BussinessLogic.Logic;
using DataAccess;
using DataAccess.Interfaces;
using FluentValidation;
using IssueTracker.Validators;
using Microsoft.Extensions.DependencyInjection;
using ServiceModel.Dto;
using ServiceModel.Type;

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

            services.AddTransient<IIssuePriorityLogic, IssuePriorityLogic>();
            services.AddTransient<IIssuePriorityEngine, IssuePriorityEngine>();

            services.AddTransient<IRegisterLogic, RegisterLogic>();
            services.AddTransient<IUsersLogic, UsersLogic>();
            services.AddTransient<IUsersEngine, UsersEngine>();

            services.AddTransient<ISprintLogic, SprintLogic>();
            services.AddTransient<ISprintEngine, SprintEngine>();

            services.AddTransient<IReleaseLogic, ReleaseLogic>();
            services.AddTransient<IReleaseEngine, ReleaseEngine>();

            services.AddSingleton<IValidator<CreateReleaseRequest>,CreateReleaseRequestValidator>();
            services.AddSingleton<IValidator<EditReleaseRequest>, EditReleaseRequestValidator>();
            services.AddSingleton<IValidator<CreateSprintRequest>, CreateSprintRequestValidator>();
            services.AddSingleton<IValidator<EditSprintRequest>, EditSprintRequestValidator>();
            services.AddSingleton<IValidator<CreateIssueRequest>, CreateIssueRequestValidator>();
            services.AddSingleton<IValidator<EditIssueRequest>, EditIssueRequestValidator>();
            services.AddSingleton<IValidator<CreateSignInUserRequest>, CreateSignInUserRequestValidator>();
            services.AddSingleton<IValidator<RegisterUserRequest>, RegisterUserRequestValidator>();
        }
    }
}
