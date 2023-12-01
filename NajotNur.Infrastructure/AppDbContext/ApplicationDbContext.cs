using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NajotNur.Domain.Models;

namespace NajotNur.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

            //Database.Migrate();
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            try
            {
                if (databaseCreator is null)
                {
                    throw new Exception();
                }

                if (!databaseCreator.CanConnect())
                    databaseCreator.CreateAsync();
                    if (!databaseCreator.HasTables())
                    databaseCreator.CreateTablesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
