using Domain.Models;
using Infrastracture.Services;


var cs = new CourseService();
var gs = new GroupService();
var ss = new StudentService();

while (true)
{
    Console.WriteLine("as - add student ");
    Console.WriteLine("ac - add course");
    Console.WriteLine("ag - add group");
    Console.WriteLine("sig - studentsn in group");
    Console.WriteLine("gs - get all groups and students");
    Console.WriteLine("cg - get all course and groups");
    Console.WriteLine("sg - students with groups");
    Console.WriteLine("ids - delete student with all info");
    
    string command = Console.ReadLine();
    if (command.ToLower() == "as")
    {
        var st = new Students();
        Console.WriteLine("Enter FullName of student:");
        st.FullName = Console.ReadLine();
        Console.WriteLine("Enter age of student:");
        st.Age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a id of gruop:");
        st.GroupId = int.Parse(Console.ReadLine());
        ss.AddStudents(st);
        Console.WriteLine("Student added successfully!!!!");
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command.ToLower() == "ac")
    {
        var c = new Course();
        Console.WriteLine("Emter course name:");
        c.CourseName = Console.ReadLine();
        Console.WriteLine("Enter time of course (from , to");
        c.TimeFrom = int.Parse(Console.ReadLine());
        c.TimeTo = int.Parse(Console.ReadLine());
        cs.AddCourse(c);
        Console.WriteLine("Course added successfully!!!!");
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command.ToLower() == "ag")
    {
        var gr = new Groups();
        Console.WriteLine("Enter a group name:");
        gr.GroupNAME = Console.ReadLine();
        Console.WriteLine("Enter a students count");
        gr.StudentsCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter course id of group:");
        gr.CourseId = int.Parse(Console.ReadLine());
        gs.AddGroups(gr);
        Console.WriteLine("Group added successfully!!!!");
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command.ToLower() == "sid")
    {
        Console.WriteLine("Enter id of group:");
        int id = int.Parse(Console.ReadLine());
        foreach (var s in gs.GetStudentsInGroup(id))
        {
            Console.WriteLine($"Name : {s.FullName} \nAge{s.Age}");
            Console.WriteLine("-----------------------------------");
        }
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command == "gs")
    {
        foreach (var sg in gs.GetAllGroupsStudents())
        {
            Console.WriteLine($"Group: {sg.GroupName}\nStudent: {sg.FullName}");
            Console.WriteLine("-----------------------------------");
        }
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command == "cg")
    {
        foreach (var c in cs.GetCourseGroups())
        {
            Console.WriteLine($"Course: {c.Course}\nGroup: {c.Group}");
            Console.WriteLine("-----------------------------------");
        }
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command == "sg")
    {
        foreach (var s in gs.GetAllGroupsStudents())
        {
            Console.WriteLine($"Student: {s.FullName}\nGroup: {s.GroupName}");
            Console.WriteLine("-----------------------------------");
        }
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
    }
    else if (command.ToLower() == "dsi")
    {
        Console.WriteLine("Enter id of student");
        int id = int.Parse(Console.ReadLine());
        ss.DeleteStudents(id);
        Console.WriteLine("Student deleted successfully");
        Console.WriteLine("Press any key to go menu");
        Console.ReadKey();
        
    }
    
}