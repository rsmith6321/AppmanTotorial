using Microsoft.EntityFrameworkCore;

namespace Student.Models{
    public class UniversityContext : DbContext{
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }
        public DbSet<UniversityInfo> UniversityInfos {get;set;}
    }
}