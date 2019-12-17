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
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ServiceModel.Type;
using IssueTracker.ApiConfig;

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

            services.AddCustomTransientServices();

            services.Configure<AuthOptions>(Configuration.GetSection("AuthOptions"));

            var authOptions = Configuration.GetSection("AuthOptions").Get<AuthOptions>();

            services.AddCustomAuthentication(authOptions);

            services.AddControllers();

            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCustomSwagger();

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
