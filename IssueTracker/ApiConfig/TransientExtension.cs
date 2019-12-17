using BussinessLogic;
using BussinessLogic.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.ApiConfig
{
    public static class TransientExtension
    {
        public static void AddCustomTransientServices(this IServiceCollection services) 
        {
            services.AddTransient<IIssuesLogic, IssuesLogic>();
            services.AddTransient<IIssuesEngine, IssuesEngine>();

            services.AddTransient<IStatusLogic, StatusLogic>();
            services.AddTransient<IStatusEngine, StatusEngine>();

            services.AddTransient<IIssueTypeLogic, IssueTypeLogic>();
            services.AddTransient<IIssueTypeEngine, IssueTypeEngine>();

            services.AddTransient<IRegisterLogic, RegisterLogic>();
        }
    }
}
