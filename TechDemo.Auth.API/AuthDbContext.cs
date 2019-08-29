using Microsoft.EntityFrameworkCore;
using TechDemo.Auth.API.Entities;

namespace TechDemo.Auth.API
{
    public class AuthDbContext : DbContext
    {
        #region DB sets
        public DbSet<User> Users { get; set; }
        #endregion

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(new User { Id = 1, Username = "techdemo", Password = "12345" });
        }
    }
}
