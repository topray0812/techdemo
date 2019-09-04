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
        }
    }
}
