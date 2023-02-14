// See https://aka.ms/new-console-template for more information
using System.Data;

void AddStudent(IDbConnection connection, int id,string name)
{

}


try
{
    var rnd = new Random();
    rnd.Next(1,3);

   //  "Server=172.19.0.2;Port=5432;DataBase=Demo;Uid=postgres;Pwd=mysecretpassword"
    using (var connection = new Microsoft.Data.Sqlite.SqliteConnection("FileName='Demo.db'"))
    {
       connection.Open();
       var tr = connection.BeginTransaction();
       // tr.Commit(); // підтвердтти транзакцію 
       // tr.Rollback(); // відмінити транзакцію
       var cmd = connection.CreateCommand();
       cmd.Transaction= tr;
       cmd.CommandText = $"insert into student (id,name) values (@id,@nameStudent)"; 
      
        var pId = cmd.CreateParameter();
        pId.ParameterName= "id" ;
        pId.Value = 2;
        cmd.Parameters.Add(pId);
        var pnameStudent = cmd.CreateParameter();
        pnameStudent.ParameterName = "nameStudent";
        pnameStudent.Value = "Петренко Іван";
        cmd.Parameters.Add(pnameStudent);
        cmd.Parameters["nameStudent"].Value = "ffdgd ddfdf";
        cmd.ExecuteNonQuery();

        tr.Rollback(); //tr.Commit();
        
        
        
        
        //cmd.CommandText = "create table student (id int,name varchar(100))";
 


        // select * from student
        // insert into student (id,name) value (10,'Bill Will')
        // delete from student where id<5
        // update student set name = 'ffff' where id = 10
        // створити базу студентыв, записати 5 студентыв (Ід - 1..5) змінити назву 3, 5: видалтти 1.
        // Пысля кожноъ операцыъ виводити список студентыв
        // вивід в окремому методі.
        //cmd.CommandText = $"create table student (id int,name varchar(100))";
        //cmd.CommandText = $"insert into student (id,name) values (3,'Іван Мазепа')";

       
    
    cmd.CommandText = $"select * from student";
    var records = cmd.ExecuteReader();


    while (records.Read())
    {
         var id = records["id"];
         var name = records["name"];
         Console.WriteLine($"{id} {name}");

    }
        connection.Close();
   


       connection.Close();
    }

     
     
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