using bill_project.Domain.Enum;

namespace bill_project.Domain.Entities;

public class VoteResult
{
    public long Id { get; private set; }
    public long PersonId { get; private set; }
    public long VoteId { get; private set; }
    public Person Person { get; private set; }
    public Vote Vote { get; private set; }
    public VoteTypeEnum VoteType { get; private set; }

    public VoteResult(long id, long personId, long voteId, Person person, Vote vote, VoteTypeEnum voteType)
    {
        Id = id;
        PersonId = personId;
        VoteId = voteId;
        Person = person;
        Vote = vote;
        VoteType = voteType;
        Validate();
    }

    private void Validate()
    {
        if (Id == 0)
        {
            throw new ArgumentException("Id cannot be zero");
        }
        if (PersonId == 0)
        {
            throw new ArgumentException("PersonId cannot be zero");
        }
        if (VoteId == 0)
        {
            throw new ArgumentException("VoteId cannot be zero");
        }
        if (Person is null)
        {
            throw new ArgumentException("Person cannot be null");
        }
        if (Vote is null)
        {
            throw new ArgumentException("Vote cannot be null");
        }
        if (VoteType == VoteTypeEnum.None)
        {
            throw new ArgumentException("VoteType cannot be None");
        }
    }

}
