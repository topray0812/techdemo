using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TechDemo.Todo.API.Test
{
    public class WebAppFactory : WebApplicationFactory<Startup>
    {
        private readonly Action<IServiceCollection> _configureTestServices;

        public WebAppFactory(Action<IServiceCollection> configureTestServices)
        {
            _configureTestServices = configureTestServices;
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseContentRoot(".");
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(collection =>
            {
                _configureTestServices?.Invoke(collection);
            });
        }
    }
}
