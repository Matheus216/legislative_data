using bill_project.Domain.Entities;

namespace bill_test.Entities;
public class VoteTest : BaseTest
{
    [Fact]
    public void CreateVoteShouldBeValid() 
    {
        // Arrange / Act
        var sponsor = new Person(GetRandomNumber());
        var bill = new Bill(GetRandomNumber(), GetRandomName() , sponsor.Id, sponsor); 
        var vote = new Vote(GetRandomNumber(), bill.Id, bill); 
        
        // Assert
        Assert.True(vote.Id > 0);
    }

    [Fact]
    public void CreateVoteShouldBeInValidBillId() 
    {
        // Assert
        Assert.Throws<ArgumentException>(() => 
        { 
            var response = new Vote(1, 0, null); 
        });
    }
}