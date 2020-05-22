using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityStudentTest.Models
{
    public class University
    {
        public long UniversityId { get; set; }
        public string Name { get; set; }
        public long StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student student { get; set; }

    }
}
