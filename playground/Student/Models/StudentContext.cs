using Microsoft.EntityFrameworkCore;

namespace Student.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<StudentInfo> StudentInfos {get; set;}
    }
}