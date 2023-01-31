// See https://aka.ms/new-console-template for more information
using System.Data;

Console.WriteLine("Hello, World!");

string connectionString = "FileName=Demo.db";

var connection = (new Microsoft.Data.Sqlite.SqliteConnection(connectionString)) as IDbConnection; 
IDataAdapter adapter = null;

//connection.Database.
try
{
    connection.Open();
    var cmd = connection.CreateCommand();
    //cmd.CommandText = $"create table student (id int,name varchar(100))";
    //cmd.ExecuteNonQuery();
    cmd = connection.CreateCommand();
    cmd.CommandText = $"insert into student (id,name) values (2,'Петро Скунць')";
    cmd.ExecuteNonQuery();
    cmd = connection.CreateCommand();
    cmd.CommandText = $"select * from student";
    var items = cmd.ExecuteReader();
    while (items.Read())
    {
        var id = items["id"];
        var name = items["name"];
        Console.WriteLine($"{id} {name}");

    }


    connection.Close();
}
catch (Exception ex)
{

}