public class University{
    public long Id {get;set;}
    public string Name {get; set;}
    [ForeignKey("StudentID")]
    public virtual Student student {
        get;set;
    }
}