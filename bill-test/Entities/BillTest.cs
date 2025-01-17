using bill_project.Domain.Entities;

namespace bill_test.Entities;

public class BillTest : BaseTest
{
    [Fact]
    public void CreateBillShouldBeValid() 
    {
        // Arrange / Act
        var sponsor = new Person(GetRandomNumber());
        var bill = new Bill(GetRandomNumber(), "Test Bill", sponsor.Id, sponsor); 
        
        // Assert
        Assert.True(bill.Id > 0);
    }

    [Fact]
    public void CreateBillShouldBeInValidTitle() 
    {
        // Arrange / Act
        var sponsor = new Person(GetRandomNumber(), "Test Sponsor");

        Assert.Throws<ArgumentException>(() => 
        { 
            var response = new Bill(GetRandomNumber(), "", sponsor.Id, sponsor); 
        });
    }
}