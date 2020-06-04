using AutoMapper;
using ServiceModel.Models;
using IssueTracker.ApiConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceModel.Type;

namespace IssueTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(c=>
            //{
            //    c.AddPolicy("Allow Origin", options => options.AllowAnyOrigin());
            //});
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "http://www.abcd.com")
                                        .AllowAnyHeader()
                                        .AllowAnyOrigin()
                                        //.AllowAnyMethod()
                                        .WithMethods("GET","PUT","POST","DELETE");
                });
            });

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
            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
            }

            // app.UseCors(options => options.AllowAnyOrigin());
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseCustomSwagger();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
