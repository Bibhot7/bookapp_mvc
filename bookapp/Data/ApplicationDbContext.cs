//Basic configuration for Entity framework.
//Db context class is the root class for Entity framework core, using this we will be accessing Entity framework.


using bookapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookapp.Data
{
    

    public class ApplicationDbContext : DbContext
    {
        //passing the connection string.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }


    }
}
