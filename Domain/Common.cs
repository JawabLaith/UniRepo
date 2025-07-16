namespace UniversityAPI;

public abstract class Common
{
    protected string Name{get; set;}
    protected string Email{get; set;}
    public DateOnly DateOfBirth {get; set; }
    
    public Common() { }

    public Common(string name, string email,DateOnly dateOfBirth)
    {
        Name = name;
        Email = email;
    }
    public abstract void Print();
}