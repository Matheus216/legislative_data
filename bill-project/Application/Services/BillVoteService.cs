using bill_project.Domain.Entities;
using bill_project.infrastructure;
using bill_project.Domain.Enum;
using System.Text;
using System.Diagnostics;

namespace bill_project.Application.Services;

public class BillVoteService
{
    private readonly FileRepository _repository;

    public BillVoteService()
    {
        _repository = new FileRepository();
    }

    public async Task GenerateResultBillVote()
    {
        Console.WriteLine($"Started process to generate bill and legislator report at {DateTime.Now}");

        var taskPerson = GetPerson();
        var taskBills = GetBills(await taskPerson);
        var taskVote = GetVotes(await taskBills);
        var taskVoteResult = GetVoteResults(await taskPerson, await taskVote);

        var legistatorContent = new LegislatorGeneratorService(await taskPerson, await taskVoteResult);
        var billGenerator = new BillGeneratorService(await taskVote, await taskVoteResult);
    
        Console.WriteLine("Getting data to generate bill and legislator report");

        var pathDestinyBill = billGenerator.Execute();
        var pathDestinyLegislator = legistatorContent.Execute();

        Console.WriteLine($"File generated in {pathDestinyBill}");
        Console.WriteLine($"File generated in {pathDestinyLegislator}");

        Console.WriteLine($"Finished process to generate bill and legislator report at {DateTime.Now}");
    }

    public async Task<IEnumerable<Bill>> GetBills(IEnumerable<Person> personList)
    {
        var readBills = await _repository.ReadFile("bills.csv");
        
        if (readBills is null || readBills.Count == 0)
        {
            throw new Exception("Not found bills to count");
        }

        var bills = readBills.Select(x => 
        {
            var sponsorId = long.Parse(x[2]);
            var sponsor = personList.FirstOrDefault(x => x.Id == sponsorId) ?? new Person(sponsorId);

            var bill = new Bill(long.Parse(x[0]), x[1], sponsor.Id, sponsor);

            return bill;
        }).ToList();

        return bills;
    }

    public async Task<IEnumerable<Person>> GetPerson()
    {
        var readPerson = await _repository.ReadFile("legislators.csv");
        
        if (readPerson is null || readPerson.Count == 0)
        {
            throw new Exception("Not found person to count");
        }

        var persons = readPerson.Select(x => new Person(long.Parse(x[0]), x[1])).ToList();

        return persons;
    }

    public async Task<IEnumerable<Vote>> GetVotes(IEnumerable<Bill> bills)
    {
        var readVotes = await _repository.ReadFile("votes.csv");
        
        if (readVotes is null || readVotes.Count == 0)
        {
            throw new Exception("Not found votes to count");
        }

        var votes = readVotes.Select(x => 
        { 
            var billId = long.Parse(x[1]);
            var bill = bills.FirstOrDefault(x => x.Id  == billId);

            var vote = new Vote(long.Parse(x[0]), bill?.Id ?? 0, bill);

            return vote;
        }).ToList();

        return votes;
    }

    public async Task<IEnumerable<VoteResult>> GetVoteResults(IEnumerable<Person> persons, IEnumerable<Vote> votes)
    {
        var readVoteResults = await _repository.ReadFile("vote_results.csv");
        
        if (readVoteResults is null || readVoteResults.Count == 0)
        {
            throw new Exception("Not found vote results to count");
        }

        var voteResults = readVoteResults.Select(x => 
        {
            var personId = long.Parse(x[1]);
            var person = persons.FirstOrDefault(x => x.Id == personId);

            var voteId = long.Parse(x[2]);
            var vote = votes.FirstOrDefault(x => x.Id == voteId);

            var voteResult = new VoteResult
            (
                long.Parse(x[0]), 
                person?.Id ?? 0 , 
                voteId, 
                person, 
                vote, 
                (VoteTypeEnum)short.Parse(x[3])
            );

            return voteResult;
        }).ToList();

        return voteResults;
    }
}