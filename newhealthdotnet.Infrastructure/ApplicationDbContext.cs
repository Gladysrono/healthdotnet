using Microsoft.EntityFrameworkCore;
using newhealthdotnet.Domain.Entities;

namespace newhealthdotnet.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        // Add other DbSets for your entities here
        // public DbSet<AnotherEntity> AnotherEntities { get; set; }
    }
}
