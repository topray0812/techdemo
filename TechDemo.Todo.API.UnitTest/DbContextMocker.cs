using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TechDemo.Todo.API.UnitTest
{
    public static class DbContextMocker
    {
        public static TodoDbContext GetTodoDbContext()
        {
            IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                                      .Build();

            var conStr = _configuration.GetSection("ConnectionStrings").GetValue<string>("TechDemoConn");

            var options = new DbContextOptionsBuilder<TodoDbContext>().UseNpgsql(conStr).Options;

            var dbContext = new TodoDbContext(options);

            dbContext.Database.Migrate();

            return dbContext;
        }
    }
}
