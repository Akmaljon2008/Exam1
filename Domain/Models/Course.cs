namespace Domain.Models;

public class Course
{
    public int  Id { get; set; }
    public string CourseName { get; set; }
    public int TimeFrom { get; set; }
    public int TimeTo { get; set; }
}