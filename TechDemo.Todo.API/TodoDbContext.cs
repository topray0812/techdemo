using Microsoft.EntityFrameworkCore;
using TechDemo.Todo.API.Entities;

namespace TechDemo.Todo.API
{
    public class TodoDbContext : DbContext
    {
        #region DB sets
        public DbSet<TodoItem> TodoItems { get; set; }
        #endregion

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TodoItem>().Property(p => p.Id).ValueGeneratedOnAdd();

            //builder.Entity<TodoItem>().HasData(new TodoItem { Id = -1, Title = "test title", Description = "test desc", Lat = -121.23126, Long = 42.6235675 });
            //builder.Entity<TodoItem>().HasData(new TodoItem { Id = -2, Title = "test title 2", Description = "test desc 2", Lat = -120.13124, Long = 41.1234567 });
            //builder.Entity<TodoItem>().HasData(new TodoItem { Id = -3, Title = "test title 3", Description = "test desc 3", Lat = -198.123321, Long = 39.6815451 });
        }
    }
}
