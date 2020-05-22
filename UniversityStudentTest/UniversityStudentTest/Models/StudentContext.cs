
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DbContextOptions<StudentContext>;


namespace UniversityStudentTest.Models
{
    public class StudentContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
