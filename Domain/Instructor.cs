namespace UniversityAPI;
using System.ComponentModel.DataAnnotations;

    public enum Position
    {
        Professor,
        AssociateProfessor,
        Lecturer
    }

public class Instructor : Common
{
    [Key]
    public int InstructorId { get; set; } // Primary key
    public Position Position {get; set;}
    public float Salary {get; set;}
    public string Department {get; set;}
    public const int AllowedLeaves = 4;
    public int InstructorLeaves = 0;

    public Instructor() { }
    
    public Instructor(string name, Position position ,string department, float salary, string email, DateOnly dateOfBirth) : base(name, email, dateOfBirth)
    {
        Salary = salary;
        Department = department;
        Position = position;
    }

    public void CalculateLeaves()
    {
        while (InstructorLeaves < AllowedLeaves)
        {
            Console.Write("Do want to leave or Attend: ");
            string leave = Console.ReadLine().ToLower();

            if (leave == "leave")
            {
                InstructorLeaves++;
                Console.WriteLine("You have " + (AllowedLeaves - (InstructorLeaves)) + " leaves left\n");
            }
            else if (leave == "attend")
            {
                Console.WriteLine("You have " + (AllowedLeaves - (InstructorLeaves)) + " leaves left\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, enter leave or attend.\n");
            }

            if (InstructorLeaves == AllowedLeaves)
            {
                Console.WriteLine("You Have Used All of Your Allowed Leaves, You Are Suspended!");
            }
        }
    }

    public override void Print()
    {
        Console.WriteLine($"Instructor's Name: {Name}, Position: {Position}, Department: {Department}, Email: {Email}, Salary: {Salary}\n");
    }
}
