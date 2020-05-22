using Microsoft.EntityFrameworkCore;

namespace StudentUniversityTest.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public DbSet<University> Universities { get; set; }
    }
}