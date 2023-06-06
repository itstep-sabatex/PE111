using Microsoft.EntityFrameworkCore;

namespace WebApplicationApiDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Models.Student> Students { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
    }
}
