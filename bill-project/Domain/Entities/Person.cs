namespace bill_project.Domain.Entities;


public class Person
{
    public long Id { get; private init; }
    public string Name { get; private init; }   

    public Person(long id, string name = "Unknown")
    {
        Id = id;
        Name = name;
        Validate(); 
    }

    private void Validate()
    {
        if (Id == 0)
        {
            throw new ArgumentException("Id cannot be zero");
        }
        if (string.IsNullOrEmpty(Name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }   
    }    
}