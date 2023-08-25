DBase - first database  for personal (DBF file) 
	1978 - for CP/M
	1980 - MS-DOS
	2017 - Windows
FoxPro,Clipper - (DBF) database language
Paradox - (Borland)
Interbase - 

Open Database Connectivity (ODBC) - (1970) 

DAO - data access object (Java, JDBC)

ADO - ActiveX Data Objects technology

ADO.NET is sometimes considered an evolution of ActiveX Data Objects (ADO) technology, but was changed so extensively that it can be considered an entirely new product.



System.Data.OleDb ( MSSQL  OLE)





#IDbConnection - ³ ()
    "PostgresConnection": "Server=172.19.0.2;Port=5432;DataBase=Demo;Uid=postgres;Pwd=mysecretpassword",
    "SqliteConnection": "FileName='C:\\DataBases\\Demo.db';Cache=Shared",
    "MSSQLConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo"

	var connection = new Microsoft.Data.Sqlite.SqliteConnection("FileName=Demo.db"));
	or
	var connection = new Npgsql.NpgsqlConnection("Server=172.19.0.2;Port=5432;DataBase=Demo;Uid=postgres;Pwd=mysecretpassword")

#IDbCommand - 
	


IDataReader, IDataRecord; - 
IDataParameter, IDbDataParameter - 


IDbTransaction - . 

IDataAdapter,IDbDataAdapter - Allows an object to implement a DataAdapter, and represents a set of methods and mapping action-related properties that are used to fill and update a DataSet and update a data source.

