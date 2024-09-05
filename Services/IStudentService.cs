using CrudWithDapper.Models;

namespace CrudWithDapper.Services;

public interface IStudentService
{
    IEnumerable<Student> GetStudents();
    Student? GetStudentById(int id);
    bool CreateStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
}