//Basic configuration for Entity framework.
//Db context class is the root class for Entity framework core, using this we will be accessing Entity framework.


using bookapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookapp.DataAccess.Data
{


    public class ApplicationDbContext : DbContext
    {
        //passing the connection string.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        //Seeding data using Entity framework.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Display0rder = 1 },
                new Category { Id = 2, Name = "SciFi", Display0rder = 2 },
                new Category { Id = 3, Name = "History", Display0rder = 3 }

                );
        }


    }
}
