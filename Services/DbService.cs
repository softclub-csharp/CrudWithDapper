using Dapper;
using Npgsql;

namespace CrudWithDapper.Services;

public static class DbService
{
    public static void CreateDatabase()
    {
        using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.DefaultConnectionString))
        {
          connection.Open();
          connection.Execute(SqlCommands.CreateDatabase);
        }
    }

    public static void DropDatabase()
    {
        using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.DefaultConnectionString))
        {
            connection.Open();
            connection.Execute(SqlCommands.DropDatabase);
        }
    }

    public static void CreateTable()
    {
        using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
        {
            connection.Open();
            connection.Execute(SqlCommands.CreateTable);
        }
    }

    public static void DropTable()
    {
        using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
        {
            connection.Open();
            connection.Execute(SqlCommands.DropTable);
        }
    }

    
    
}

file static class SqlCommands
{
    public const string DefaultConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456;";
    public const string ConnectionString = @"Host=localhost;Port=5432;Database=student_db;Username=postgres;Password=123456;";
    public const string CreateDatabase = @"CREATE DATABASE  student_db";
    public const string DropDatabase = @"DROP DATABASE student_db with (force)";

    public const string CreateTable = @"CREATE TABLE if not exists students(
                                        Id SERIAL PRIMARY KEY,
                                        Name VARCHAR(50) NOT NULL,
                                        Age INT NOT NULL,
                                         Email VARCHAR(50) NOT NULL,
                                          Address VARCHAR(50) NOT NULL,
                                          Phone VARCHAR(50) NOT NULL)";
    public const string DropTable = @"DROP TABLE if exists Students";
}