using Dapper;

namespace Infrastracture.Services;
using Infrastracture.Datacontext;
using Domain.Models;
public class StudentService
{
    private readonly DapperContext _db;

    public StudentService()
    {
        _db = new DapperContext();
    }

    public List<Students> GetStudentss()
    {
        var sql = "select * from Students";
        return _db.Connection().Query<Students>(sql).ToList();
    }

    public void AddStudents(Students student)
    {
        var sql = "insert into Students(StudentsName,TimeForm,TimeTo)values (@StudentsName,@TimeFrom,@TimeTo)";
        _db.Connection().Execute(sql, student);
    }

    public void UpdateStudents(Students student)
    {
        var sql = "update Students set StudentsName = @Studentsname,TimeForm = @timeform,timeto = @timeto where id = @id";
        _db.Connection().Execute(sql, student);
    }

    public void DeleteStudents(int id)
    {
        var sql = "delete from Students where id = @id";
        _db.Connection().Execute(sql, new { Id = id });
    }
    
}