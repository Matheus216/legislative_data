namespace bill_project.Domain.Entities;

public class Bill
{
    public long Id { get; private init; }
    public string Title { get; private init; }
    public long SponsorId { get; private init; }
    public Person? Person { get; private init; }
    
    public Bill(long id, string title, long sponsorId, Person? person) 
    {
        Id = id;
        Title = title;
        SponsorId = sponsorId;
        Person = person;

        Validate();     
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Title))
        {
            throw new ArgumentException("Title cannot be null or empty");
        }
        if (SponsorId == 0)
        {
            throw new ArgumentException("SponsorId cannot be zero");
        }
        if (Person is null)
        {
            throw new ArgumentException("Sponsor cannot be null");
        }
    }
}


