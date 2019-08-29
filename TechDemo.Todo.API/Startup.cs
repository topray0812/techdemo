using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using TechDemo.Todo.API.Helper;
using TechDemo.Todo.API.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace TechDemo.Todo.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            if (Environment.GetEnvironmentVariable("CONTAINER") == "true")
                services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("TechDemoConn"), o => o.UseNetTopologySuite()));
            else
                services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("TechDemoConnLocal"), o => o.UseNetTopologySuite()));

            services.AddScoped<ITodoService, TodoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //app.UseHttpsRedirection();
            }
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
