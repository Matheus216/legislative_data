using bill_project.Application.Services;
using bill_project.Domain.Entities;
using bill_project.Domain.Enum;
using bill_project.infrastructure;
using NuGet.Frameworks;

namespace bill_test.Services;


public class VoteResultServiceTest : BaseTest
{
    private readonly FileRepository _fileRepository;

    public VoteResultServiceTest()
    {
        _fileRepository = new FileRepository();
    }

    [Fact]
    public void CalculateTotalSuportByLegislatorShouldBeValid() 
    {
        // Arrange
        var voteResult = GetVoteResults();

        var voteResultService = new VoteResultService(voteResult);
        
        foreach (var x in PersonList.Where(x => x.Name != "Unknown"))
        {
            // Act
            var supportLegislator = voteResultService.CalculateTotalSuportByLegislator(x.Id);
            var opposeLegislator = voteResultService.CalculateTotalOpposeByLegislator(x.Id);
            
            // Assert
            Assert.Equal(1,supportLegislator);
            Assert.Equal(1,opposeLegislator);
        }
    }

    [Fact]
    public void CalculateTotalSuportByBillShouldBeValid() 
    {
        // Arrange
        var voteResult = GetVoteResults();

        var voteResultService = new VoteResultService(voteResult);
        
        foreach (var x in VoteList)
        {
            // Act
            var supportBill = voteResultService.CalculateTotalLegistatorsSuportByBill(x.Id);
            var opposeBill = voteResultService.CalculateTotalLegistatorOpposeByBill(x.Id);
            
            // Assert
            Assert.Equal(1,supportBill);
            Assert.Equal(1,opposeBill);            
        }
        
        Assert.Equal(4, voteResult.Count());
    }
}