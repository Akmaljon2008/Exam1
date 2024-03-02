namespace Domain.Models;

public class Groups
{
    public int Id { get; set; }
    public string GroupNAME { get; set; }
    public int StudentsCount { get; set; }
    public int CourseId { get; set; }
}