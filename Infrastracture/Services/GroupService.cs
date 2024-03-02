using Dapper;

namespace Infrastracture.Services;
using Infrastracture.Datacontext;
using Domain.Models;
public class GroupService
{
    private readonly DapperContext _db;

    public GroupService()
    {
        _db = new DapperContext();
    }
    
    public List<Groups> GetGroups()
    {
        var sql = "select * from Groups";
        return _db.Connection().Query<Groups>(sql).ToList();
    }

    public void AddGroups(Groups groups)
    {
        var sql = "insert into Groups(GroupsName,TimeForm,TimeTo)values (@GroupsName,@TimeFrom,@TimeTo)";
        _db.Connection().Execute(sql, groups);
    }

    public void UpdateGroups(Groups groups)
    {
        var sql = "update Groups set GroupsName = @Groupsname,TimeForm = @timeform,timeto = @timeto where id = @id";
        _db.Connection().Execute(sql, groups);
    }

    public void DeleteGroups(int id)
    {
        var sql = "delete from Groups where id = @id";
        _db.Connection().Execute(sql, new { Id = id });
    }

    public List<Students> GetStudentsInGroup(int id)
    {
        var sql = "select s.FullName from Students as s where GroupId = @id";
        return _db.Connection().Query<Students>(sql, new { Id = id }).ToList();
    }

    public List<GroupStudents> GetAllGroupsStudents()
    {
        var sql = "select s.FullName,g.GroupName from Students as s join Groups G on s.GroupId = G.Id";
        return _db.Connection().Query<GroupStudents>(sql).ToList();
    }
    public void DeleteGroup(int id)
    {
        var sql = "delete from Groups where id = @id";
        _db.Connection().Execute(sql, new { Id = id });
    }
}