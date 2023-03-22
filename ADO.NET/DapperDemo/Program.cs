using Dapper;
using EFCoreDemo.Models;
using Microsoft.Data.Sqlite;


var a = 10;
var b = 20;
var c = a+b;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using (var context = new SqliteConnection("Data Source=C:\\Users\\serhi\\source\\repos\\itstep-sabatex\\ПВ111\\ADONet\\DataBases\\EFCoreDemo.db"))
{
    var query = "select * from students";
    var students = context.Query<Student>(query);

    foreach (var student in students) { Console.WriteLine(student); }

    query = "insert into students (name) values (@name) ";

    var result = context.Execute(query, new {name="dsgdfg xfdfdf"});

}
