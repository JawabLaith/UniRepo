namespace UniversityAPI;

using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int CourseId { get; set; } // Primary key
    public string Name { get; set; }
    public int CreditHour { get; set; }
    public const int StudentCapacity = 15;
    public int currentCapacity = 0;
    
    public Course() { }
    
    public Course(string courseName, int courseId, int creditHour)
    {
        Name = courseName;
        CourseId = courseId;
        CreditHour = creditHour;
    }
    
    public void RegisterStudents()
    {
        while (currentCapacity < StudentCapacity)
        {
            Console.Write("Register a new student? (yes/no): ");
            string input = Console.ReadLine().ToLower();

            if (input == "yes")
            {
                currentCapacity++;
                Console.WriteLine($"Student registered! Current capacity: {currentCapacity}/{StudentCapacity}");
            }
            else if (input == "no")
            {
                Console.WriteLine("User Stopped Registration");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, type 'yes' or 'no'.");
            }
        }

        if (currentCapacity == StudentCapacity)
        {
            Console.WriteLine("Course is full you can't register.");
        }
    }
    
    public void PrintDetails()
    {
        Console.WriteLine($"Course Name: {Name}, Course ID: {CourseId}, CreditHour: {CreditHour}, Capacity: {StudentCapacity}\n");
    }
}