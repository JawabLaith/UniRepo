namespace UniversityAPI;

using System.ComponentModel.DataAnnotations;

public class University : Location
{
    [Key]
    public int UniversityId { get; set; } // Primary key
    public string Name { get; set; }
    public string Type {get; set; }

    public void UniDetails()
    {
        Console.Write("University Name: ");
        Name = Console.ReadLine();

        Console.Write("University Country: ");
        Country = Console.ReadLine();

        Console.Write("University City: ");
        City = Console.ReadLine();

        Console.Write("University Street: ");
        Street = Console.ReadLine();

        Console.Write("University Type(Public/Private): ");
        Type = Console.ReadLine();
    }
}