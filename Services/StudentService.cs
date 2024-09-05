using CrudWithDapper.Models;
using Dapper;
using Npgsql;

namespace CrudWithDapper.Services;

public class StudentService : IStudentService
{
    public IEnumerable<Student> GetStudents()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Query<Student>(SqlCommands.SelectStudents);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    
    public Student? GetStudentById(int id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();

                return  connection.QueryFirstOrDefault<Student>(SqlCommands.SelectStudentById,id);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool CreateStudent(Student student)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.InsertStudent, student) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdateStudent(Student student)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommands.UpdateStudent, student) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeleteStudent(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString)) 
            {
                connection.Open();
                return connection.Execute(SqlCommands.DeleteStudent, new{Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file static class SqlCommands
{
    public const string ConnectionString =
        @"Host=localhost;Port=5432;Database=student_db;Username=postgres;Password=123456;";

    public const string InsertStudent =
        @"INSERT INTO Students(Name, Age, Email, Address, Phone) VALUES(@Name, @Age, @Email, @Address, @Phone)";

    public const string SelectStudents = @"SELECT * FROM Students";
    public const string SelectStudentById = @"SELECT * FROM Students WHERE Id = @Id";

    public const string UpdateStudent =
        @"UPDATE Students SET Name = @Name, Age = @Age, Email = @Email, Address = @Address, Phone = @Phone WHERE Id = @Id";

    public const string DeleteStudent = @"DELETE FROM Students WHERE Id = @Id";
}
