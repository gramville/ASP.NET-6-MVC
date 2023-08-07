using Microsoft.EntityFrameworkCore;

namespace TRYING.Models
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> persons { get; set; }
    }
}
