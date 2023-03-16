using Microsoft.EntityFrameworkCore;
using UserProfileAPIs.Database.Models;

namespace UserProfileAPIs.Database
{
    public class UserProfileContext : DbContext
    {
        public UserProfileContext(DbContextOptions<UserProfileContext> options) : base(options)
        {
        }

        public DbSet<UserData> UserData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().ToTable("UserData");
        }
    }
}
