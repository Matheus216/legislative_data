using bill_project.Domain.Entities;
using bill_project.Domain.Enum;

namespace bill_project.Application.Services;
public class VoteResultService
{
    private IEnumerable<VoteResult> VoteResult; 

    public VoteResultService(IEnumerable<VoteResult> voteResult)
    {
        VoteResult = voteResult;
    }

    public int CalculateTotalSuportByLegislator(long personId) =>
       VoteResult.Count(x => x.PersonId == personId && x.VoteType == VoteTypeEnum.Yea);
    
    public int CalculateTotalOpposeByLegislator(long personId) =>
        VoteResult.Count(x => x.PersonId == personId && x.VoteType == VoteTypeEnum.Nay);

    public int CalculateTotalLegistatorsSuportByBill(long voteId) =>
       VoteResult.Count(x => x.VoteId == voteId && x.VoteType == VoteTypeEnum.Yea);

    public int CalculateTotalLegistatorOpposeByBill(long voteId) =>
         VoteResult.Count(x => x.VoteId == voteId && x.VoteType == VoteTypeEnum.Nay);
}