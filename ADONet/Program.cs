// See https://aka.ms/new-console-template for more information
using System.Data;

string connectionString = "FileName=Demo.db";
try
{
    IDbConnection connection = (new Microsoft.Data.Sqlite.SqliteConnection(connectionString)) as IDbConnection;
    connection.Open();
    IDbCommand cmd = connection.CreateCommand();
     //cmd.CommandText = $"create table student (id int,name varchar(100))";
    //cmd.CommandText = $"insert into student (id,name) values (3,'Іван Мазепа')";
    //cmd.ExecuteNonQuery();
    
    cmd.CommandText = $"select * from student";
    var records = cmd.ExecuteReader();
    while (records.Read())
    {
         var id = records["id"];
         var name = records["name"];
         Console.WriteLine($"{id} {name}");

    }
        connection.Close();
    //connection.Database.



    //cmd.CommandText = $"create table student (id int,name varchar(100))";
    //cmd.ExecuteNonQuery();
    //cmd = connection.CreateCommand();
    //cmd.CommandText = $"insert into student (id,name) values (2,'Петро Скунць')";
    //cmd.ExecuteNonQuery();
    //cmd = connection.CreateCommand();
    //cmd.CommandText = $"select * from student";
    //var items = cmd.ExecuteReader();
    //while (items.Read())
    //{
    //    var id = items["id"];
    //    var name = items["name"];
    //    Console.WriteLine($"{id} {name}");

    //}


    //connection.Close();
}
catch (Exception ex)
{

}