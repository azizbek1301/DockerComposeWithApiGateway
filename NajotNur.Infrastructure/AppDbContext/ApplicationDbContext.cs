using Microsoft.EntityFrameworkCore;
using NajotNur.Domain.Models;

namespace NajotNur.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
    }
}
