using Microsoft.EntityFrameworkCore;
using UdemyWeb.Model;

namespace UdemyWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
    }
}
