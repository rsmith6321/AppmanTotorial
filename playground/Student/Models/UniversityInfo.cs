using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
using Student.Models;
public class UniversityInfo{
    public long Id {get;set;}
    public string Name{get;set;}
    public string Subject{get; set;}

    // [ForeignKey("StudentID")]
    // public virtual StudentInfo Student{
    //     get; set;
    // }

//    public List<string> Student{get;set;}

    // public async System.Threading.Tasks.Task<List<StudentInfo>> StudentConnectorAsync(long UniversityId){
    //     // get;
    //     // set;
    //     private readonly UniversityContext _context;

    //     var studentInfo = await _context.StudentInfos.FindAsync(UniversityId);
    //     return  ;

    // }


}