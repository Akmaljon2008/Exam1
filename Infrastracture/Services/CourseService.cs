namespace Infrastracture.Services;
using Dapper;
using Domain.Models;
using Infrastracture.Datacontext;


public class CourseService
{
    private readonly DapperContext _db;

    public CourseService()
    {
        _db = new DapperContext();
    }

    public List<Course> GetCourses()
    {
        var sql = "select * from Course";
        return _db.Connection().Query<Course>(sql).ToList();
    }

    public void AddCourse(Course course)
    {
        var sql = "insert into Course(CourseName,TimeForm,TimeTo)values (@CourseName,@TimeFrom,@TimeTo)";
        _db.Connection().Execute(sql, course);
    }

    public void UpdateCourse(Course course)
    {
        var sql = "update Course set CourseName = @coursename,TimeForm = @timeform,timeto = @timeto where id = @id";
        _db.Connection().Execute(sql, course);
    }

    public void DeleteCourse(int id)
    {
        var sql = "delete from Course where id = @id";
        _db.Connection().Execute(sql, new { Id = id });
    }

    public List<Course> CourseAndGroups(int id)
    {
        var sql = @"select c.CourseName,g.GroupoName as Groups from Course as c" +
                  "join Groups as g on g.Courseid = c.Id";
        return _db.Connection().Query<Course>(sql, new { Id = id }).ToList();
    }

    public List<CourseGroups> GetCourseGroups()
    {
        var sql = "select c.CourseName,g.GroupName from Groups as g join Course c on c.Id = g.CourseId";
        return _db.Connection().Query<CourseGroups>(sql).ToList();
    }
}