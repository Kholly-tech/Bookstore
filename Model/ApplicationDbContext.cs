using Microsoft.EntityFrameworkCore;

namespace Bookstore.Model
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<myBooks> myBooks { get; set; }
        public DbSet<Users> Users { get; set; }
    }

}
