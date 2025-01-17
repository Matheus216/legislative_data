using bill_project.Application.Helper;
using bill_project.Domain.Entities;
using System.Text;

namespace bill_project.Application.Services;

public class BillGeneratorService
{
    private readonly IEnumerable<Vote> Votes;
    private readonly IEnumerable<VoteResult> VoteResult;

    public BillGeneratorService(IEnumerable<Vote> votes, IEnumerable<VoteResult> voteResult)
    {
        Votes = votes;
        VoteResult = voteResult;
    }

    public string Execute()
    {
        var serviceVoteResult = new VoteResultService(VoteResult);

        var sb = new StringBuilder();

        sb.AppendLine("Id;Title;Supporter_Count;Opposer_Count;Primary_Sponsor");

        foreach(var vote in Votes)
        {
            var suport = serviceVoteResult.CalculateTotalLegistatorsSuportByBill(vote.Id);
            var oppose = serviceVoteResult.CalculateTotalLegistatorOpposeByBill(vote.Id);

            sb.AppendLine($"{vote?.Bill?.Id};{vote?.Bill?.Title};{suport};{oppose};{vote?.Bill?.Person.Name}");
        }

        return FileHelper.GenerateFile(sb.ToString(), "bills.csv");;
    }  
}