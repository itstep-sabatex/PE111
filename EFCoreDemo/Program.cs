// See https://aka.ms/new-console-template for more information

using EFCoreDemo.Data;
using EFCoreDemo.Models;

using (var context = new EFCoreDemoDbContext())
{
    //var student = new Student { Name = "Ivan Ivanov" };
    //context.Students.Add(student);
    //context.Students.Add(new Student { Name = "Петро Петренко" });
    //context.SaveChanges();
    var pt = context.Students.Where(s => s.Name.StartsWith("Петро")).ToArray();
    //context.Students.RemoveRange(pt);
    //foreach (var s in pt) context.Students.Remove(s);
    //context.SaveChanges();
    var students = context.Students.ToArray();
    foreach (var st in students)
    {
        Console.WriteLine($"{st.Id}  {st.Name}");
        st.Name = st.Name + "$$$";
    }
    context.SaveChanges();

}

Console.WriteLine("Hello, World!");
