using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TechDemo.Auth.API.UnitTest
{
    public static class DbContextMocker
    {
        public static AuthDbContext GetAuthDbContext()
        {
            IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                                      .Build();

            var conStr = _configuration.GetSection("ConnectionStrings").GetValue<string>("TechDemoConn");

            var options = new DbContextOptionsBuilder<AuthDbContext>().UseNpgsql(conStr).Options;
                            
            var dbContext = new AuthDbContext(options);

            return dbContext;
        }
    }
}
