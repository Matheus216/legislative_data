
namespace bill_project.Domain.Entities;

public class Vote
{
    public long Id { get; private init; }
    public long BillId { get; private init; }
    public Bill? Bill { get; private init; }

    public Vote(long id, long billId, Bill? bill) 
    {
        Id = id;
        BillId = billId;
        Bill = bill;
        Validate();          
    }

    private void Validate()
    {
        if (Id == 0)
        {
            throw new ArgumentException("Id cannot be zero");
        }
        if (BillId == 0)
        {
            throw new ArgumentException("BillId cannot be zero");
        }
        if (Bill is null)
        {
            throw new ArgumentException("Bill cannot be null");
        }
    }    
}