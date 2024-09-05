
using CrudWithDapper.Models;
using CrudWithDapper.Services;

DbService.CreateTable(); 


StudentService studentService = new StudentService();

Student row1 = new Student
{
    Name = "John",
    Age = 20,
    Email = "fsdfsfd",
    Address = "fsdfds",
    Phone = "123"
};

Student row2 = new Student
{
    Name = "Komron",
    Age = 30,
    Email = "fsdfsfd",
    Address = "fsdfds",
    Phone = "123"
};


Student row3 = new Student
{
    
    Id = 3,
    Name = "Sardor",
    Age = 40,
    Email = "fsdfsfd",
    Address = "fsdfds",
    Phone = "123"
};

IEnumerable<Student> students = studentService.GetStudents();

foreach (var s in students)
{
    Console.WriteLine(s.Name);
}


