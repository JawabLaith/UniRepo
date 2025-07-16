using University;

namespace UniversityAPI;
using System.ComponentModel.DataAnnotations;

public class Student : Common
{
    [Key]
    public int StudentId { get; set; }
    public Major Major { get; set; }
    public float StudentMark { get; set; }
    public const float four = 4, hndrd = 100;
    public float Gpa { get; set; }
    
    public float Grade()
    {
        if (StudentMark < 0 || StudentMark > 100)
        {
            Console.WriteLine("Invalid mark! Program will exit.");
            Environment.Exit(0);
        }
        Gpa = (four * StudentMark) / hndrd;
        return (float)Math.Round(Gpa, 2);
    }

    public void StudState()
    {
        if (Gpa < 2)
        {
           Console.WriteLine("The Student Has Failed His Course!\n"); 
        }
        if (Gpa >= 2 && Gpa < 4)
        {
            Console.WriteLine("The Student Has Passed His Course!\n");
        }

        if (Gpa == 4)
        {
            Console.WriteLine("The Student is Distinct!\n");
        }
    }
    
    public Student() { }

    public Student(string name, string email, Major major, DateOnly dateOfBirth, int idNum) : base(name, email, dateOfBirth)
    {
        Major = major;
        StudentId = idNum;
    }

    public override void Print()
    {
        Console.WriteLine($"Student's Name: {Name}, Date of Birth: {DateOfBirth.ToShortDateString()}, ID Number: {StudentId}, Major: {Major}, Email: {Email}\n");
    }
}