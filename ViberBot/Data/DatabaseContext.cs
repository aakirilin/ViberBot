using Microsoft.EntityFrameworkCore;
using ViberBot.Models;
using ViberBot.Viber;

namespace ViberBot.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User(1, BotSettings.AdminLogin, BotSettings.AdminPassword, UserRole.admin)
                );
        }

        public DbSet<Log> logs { get; set; }
        public DbSet<User> users { get; set; }
    }
}
