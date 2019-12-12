using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DataAccess.Models;
using DataAccess.Interfaces;
using DataAccess;
using BussinessLogic.Interfaces;
using BussinessLogic;
using Microsoft.AspNetCore.Identity;

namespace IssueTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddMvcCore(options => options.OutputFormatters.Add(new XmlSerializerOutputFormatter()));

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IIssuesLogic, IssuesLogic>();
            services.AddTransient<IIssuesEngine, IssuesEngine>();

            services.AddTransient<IStatusLogic, StatusLogic>();
            services.AddTransient<IStatusEngine, StatusEngine>();

            services.AddTransient<IIssueTypeLogic, IssueTypeLogic>();
            services.AddTransient<IIssueTypeEngine, IssueTypeEngine>();

            services.AddTransient<IRegisterLogic, RegisterLogic>();
            services.AddTransient<IRegisterEngine, RegisterEngine>();

            //difference between transient, singelton, scoped
            //https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences

            services.AddControllers();

            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                //uncomment this to validate automapper
                //mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
        }
    }
}
