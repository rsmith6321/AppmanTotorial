 using System.ComponentModel.DataAnnotations.Schema;
public class University
{
    public long UniversityId {get;set;}
    public string Name {get; set;}
    public long StudentID {get;set;}
     [ForeignKey("StudentID")]
     public virtual Student Student{get;set;}
}