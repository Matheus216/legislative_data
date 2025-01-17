using bill_project.Domain.Entities;

namespace bill_test.Entities;

public class PersonTest : BaseTest
{
    [Fact]
    public void CreatePersonShouldBeValid() 
    {
        // Arrange / Act
        var person = new Person(GetRandomNumber(), "Test Person"); 
        
        // Assert
        Assert.True(person.Id > 0);
    }

    [Fact]
    public void CreatePersonShouldBeInValidId() 
    {
        // Arrange / Act
        Assert.Throws<ArgumentException>(() => 
        { 
            var response = new Person(0, "Test Person"); 
        });
    }
}