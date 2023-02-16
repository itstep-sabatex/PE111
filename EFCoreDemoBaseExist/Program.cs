// See https://aka.ms/new-console-template for more information


using EFCoreDemo.Models;
using EFCoreDemoBaseExist.Data;

using (var context = new EFCoreDemoDbContext())
{
    var student = new Student { Name = "Ivan", Surname = "Petrov" };
    context.Students.Add(student);
    context.SaveChanges();

    foreach (var item in context.Students)
    {
        item.Surname = "New name";
        Console.WriteLine(item);
    }
    context.SaveChanges();
}
