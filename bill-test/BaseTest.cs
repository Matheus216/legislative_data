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
    
    private List<PersonEntity>? _personList;
    public List<PersonEntity> PersonList
    {
        get { 
            if (_personList is null || _personList.Count == 0)
            {
                _personList = GetPersonList();
            }
            return _personList; 
        }
    }

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

    public List<PersonEntity> GetPersonList()
    {
        var personList = new List<PersonEntity> 
        {
            new PersonEntity(GetRandomNumber(), GetRandomName()),
            new PersonEntity(GetRandomNumber(), GetRandomName()),
            new PersonEntity(GetRandomNumber())
        };
        return personList;
    }

    public List<Bill> GetBillList() 
    {
        var billsList = new List<Bill> 
        {
            new Bill(GetRandomNumber(), GetRandomName(), PersonList[0].Id, PersonList[0]),
            new Bill(GetRandomNumber(), GetRandomName(), PersonList[1].Id, PersonList[1])
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
        var voteResult = new List<VoteResult> 
        {
            new VoteResult
            (
                GetRandomNumber(), 
                PersonList[0].Id, 
                VoteList[0].Id, 
                PersonList[0], 
                VoteList[0], 
                VoteTypeEnum.Yea
            ),
            new VoteResult
            (
                GetRandomNumber(), 
                PersonList[0].Id, 
                VoteList[1].Id, 
                PersonList[0], 
                VoteList[1], 
                VoteTypeEnum.Nay
            ),
            new VoteResult
            (
                GetRandomNumber(), 
                PersonList[1].Id, 
                VoteList[0].Id, 
                PersonList[1], 
                VoteList[0], 
                VoteTypeEnum.Nay
            ),
            new VoteResult
            (
                GetRandomNumber(), 
                PersonList[1].Id, 
                VoteList[1].Id, 
                PersonList[1], 
                VoteList[1], 
                VoteTypeEnum.Yea
            )
        };

        return voteResult;
    }
}