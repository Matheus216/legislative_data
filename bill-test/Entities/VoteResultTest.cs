using bill_project.Domain.Entities;
using bill_project.Domain.Enum;

namespace bill_test.Entities;

public class VoteResultTest : BaseTest
{
    [Fact]
    public void CreateVoteResultShouldBeValid() 
    {
        // Arrange / Act
        var legislator = new Person(GetRandomNumber());
        var bill = new Bill(GetRandomNumber(), GetRandomName() , legislator.Id, legislator); 
        var vote = new Vote(1, bill.Id, bill); 
        var voteResult = new VoteResult
        (
            1, 
            legislator.Id, 
            vote.Id, 
            legislator, 
            vote, 
            Faker.Random.Enum<VoteTypeEnum>(VoteTypeEnum.None)
        ); 
        
        // Assert
        Assert.True(voteResult.Id > 0);
    }

    [Fact]
    public void CreateVoteResultShouldBeInValidVoteId() 
    {
        // Assert
        Assert.Throws<ArgumentException>(() => 
        { 
            var voteResult = new VoteResult
            (
                1, 
                0, 
                0, 
                null, 
                null, 
                Faker.Random.Enum<VoteTypeEnum>(VoteTypeEnum.None)
            );  
        });
    }
}