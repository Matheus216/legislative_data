using bill_project.Application.Helper;
using bill_project.Domain.Entities;
using System.Text;

namespace bill_project.Application.Services;

public class LegislatorGeneratorService
{
    private readonly IEnumerable<Person> PersonList;
    private readonly IEnumerable<VoteResult> VoteResult;

    public LegislatorGeneratorService(IEnumerable<Person> personList, IEnumerable<VoteResult> voteResult)
    {
        PersonList = personList;
        VoteResult = voteResult;
    }

    public string Execute()
    {
        var serviceVoteResult = new VoteResultService(VoteResult);

        var sb = new StringBuilder();

        sb.AppendLine("Id;Name;Num_Supported_Bills;Num_Opposed_Bills");

        foreach(var person in PersonList)
        {
            var suport = serviceVoteResult.CalculateTotalSuportByLegislator(person.Id);
            var oppose = serviceVoteResult.CalculateTotalOpposeByLegislator(person.Id);

            sb.AppendLine($"{person.Id};{person.Name};{suport};{oppose}");
        }

        return FileHelper.GenerateFile(sb.ToString(), "legislators-support-oppose-count.csv");
    }   
}