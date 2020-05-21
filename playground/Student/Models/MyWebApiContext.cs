using Microsoft.EntityFrameworkCore;

namespace Student.Models
{
    public class MyWebApiContext : DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options)
        {

        }

        public DbSet<StudentInfo> StudentInfos {get; set;}
        public DbSet<UniversityInfo> UniversityInfos {get; set;}
    }
}