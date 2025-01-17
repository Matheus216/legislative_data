using bill_project.Domain.Entities;

namespace bill_test.Entities;

public class BillTest
{
    [Fact]
    public void CreateBillShouldBeValid() 
    {
        // Arrange / Act
        var sponsor = new Person(1);
        var bill = new Bill(1, "Test Bill", sponsor.Id, sponsor); 
        
        // Assert
        Assert.Equal(1, bill.Id);
    }

    [Fact]
    public void CreateBillShouldBeInValidTitle() 
    {
        // Arrange / Act
        var sponsor = new Person(1, "Test Sponsor");

        Assert.Throws<ArgumentException>(() => 
        { 
            var response = new Bill(1, "", sponsor.Id, sponsor); 
        });
    }
}