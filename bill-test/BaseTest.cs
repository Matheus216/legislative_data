using bill_project.Domain.Entities;
using bill_project.Domain.Enum;
using Bogus;
using PersonEntity = bill_project.Domain.Entities.Person;

namespace bill_test;

public class BaseTest
{
    private Faker? _faker;
    public Faker Faker
    {
        get { 
            if (_faker is null)
            {
                _faker = new Faker("pt_BR");
            }
            return _faker; 
        }
    }
    
    public IEnumerable<PersonEntity> PersonList { get; private set; } = Enumerable.Empty<PersonEntity>();
    private List<Bill>? _billList;
    public List<Bill> BillList
    {
        get { 
            if (_billList is null || _billList.Count == 0)
            {
                _billList = GetBillList();
            }
            return _billList; 
        }
    }
    private List<Vote>? _voteList;
    public List<Vote> VoteList
    {
        get { 
            if (_voteList is null || _voteList.Count == 0)
            {
                _voteList = GetVoteList();
            }
            return _voteList; 
        }
    }
    
    public long GetRandomNumber() =>
        Faker?.Random.Number(1, 1000) ?? 0;

    public string GetRandomName() =>
        Faker?.Name.FirstName() ?? "";    


    public void SetPersonList(int quantity)
    {
        PersonList = GetPersonList(quantity).ToList();
    }

    public IEnumerable<PersonEntity> GetPersonList(int quantity)
    {
        var personList = Enumerable.Range(0,quantity)
            .Select(x => new PersonEntity(GetRandomNumber(), GetRandomName()))
            .ToList();
        
        personList
            .Add(new PersonEntity(GetRandomNumber()));
        
        return personList;
    }
    public List<Bill> GetBillList() 
    {
        var unknown = PersonList.FirstOrDefault(x => x.Name == "Unknown") ?? null;
        var another = PersonList.FirstOrDefault(x => x.Name != "Unknown") ?? null;
        var billsList = new List<Bill> 
        {
            new Bill(GetRandomNumber(), GetRandomName(), another?.Id ?? 0, another),
            new Bill(GetRandomNumber(), GetRandomName(), unknown?.Id ?? 0, unknown)
        };
        return billsList;
    }

    public List<Vote> GetVoteList()
    {
        var voteList = new List<Vote> 
        {
            new Vote(GetRandomNumber(), BillList[0].Id, BillList[0]),
            new Vote(GetRandomNumber(), BillList[1].Id, BillList[1])
        };
        return voteList;
    }

    public IEnumerable<VoteResult> GetVoteResults()
    {
        var voteResult = new List<VoteResult>();
        var type = VoteTypeEnum.Yea;

        foreach (var x in PersonList.Where(x => x.Name != "Unknown"))
        {
            type = type == VoteTypeEnum.Yea ? VoteTypeEnum.Nay : VoteTypeEnum.Yea;
            foreach (var y in VoteList)
            {
                type = type == VoteTypeEnum.Yea ? VoteTypeEnum.Nay : VoteTypeEnum.Yea;
                
                voteResult.Add(new VoteResult
                (
                    GetRandomNumber(), 
                    x.Id,
                    y.Id,
                    x,
                    y,
                    type
                ));
            }
        }

        return voteResult;
    }
}