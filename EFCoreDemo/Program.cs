// See https://aka.ms/new-console-template for more information

using EFCoreDemo.Data;
using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new EFCoreDemoDbContext())
{
    //context.Users.Add(new User { Name = "Peter Vranow", Password = "1111" });
    //context.Users.Add(new User { Name = "Dana Samsonova", Password = "1111" });
    //context.Users.Add(new User { Name = "Ivan Sviridov", Password = "1111" });
    //context.Users.Add(new User { Name = "Stanislav Vernidub", Password = "1111" });
    //context.SaveChanges();


    //var student = new Student { Name = "Ivan",Surname= "Ivanov" };
    //context.Students.Add(student);
    //context.Students.Add(new Student { Name = "Петро" ,Surname= "Петренко" });
    //context.StudentGroups.Add(new StudentGroup { Name = "Group 1" });
    //var group2 = new StudentGroup { Name = "Group 2" };
    //context.StudentGroups.Add(group2);
    //context.Students.Add(new Student { Name = "Student",StudentGroup = group2,Surname = "Ivanov" });
    //context.SaveChanges();
    ////var pt = context.Students.Include(i=>i.StudentGroup);


    //context.Students.RemoveRange(pt);
    //foreach (var s in pt) context.Students.Remove(s);
    //context.SaveChanges();.Include(i => i.StudentGroup)
    //var students = context.Students.Include(i => i.StudentGroup).ToArray();
    //string none = "None";
    //foreach (var st in students)
    //{
    //    Console.WriteLine($"{st.Id}  {st.Name}  {st.StudentGroup?.Name ?? none}");
    //    //st.Name = st.Name + "$$$";
    //}

    var students = context.Students.Include(i=>i.StudentGroup);

    var groups = context.StudentGroups.Include(i=>i.Students).Where(s=>s.Name.StartsWith("Drt")).OrderBy(o=>o.Name).ToArray();
    foreach (var g in groups)
    {
        Console.WriteLine(g);
        foreach (var st in g.Students)
        {
            Console.WriteLine(st);
            st.Name = st.Name + "$$$";
        }
    }

    context.SaveChanges();

}

Console.WriteLine("Hello, World!");
