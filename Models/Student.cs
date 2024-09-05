namespace CrudWithDapper.Models;

public class Student
{
    public int  Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; }= null!;
    public string Address { get; set; }= null!;
    public string Phone { get; set; }= null!;
}