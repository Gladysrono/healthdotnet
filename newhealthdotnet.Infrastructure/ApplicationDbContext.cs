using Microsoft.EntityFrameworkCore;
using newhealthdotnet.Domain.Entities;

namespace newhealthdotnet.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations for the User entity
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
