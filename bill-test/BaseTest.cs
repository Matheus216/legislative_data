using Bogus;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
    
    public long GetRandomNumber() =>
        Faker?.Random.Number(1, 1000) ?? 0;

    public string GetRandomName() =>
        Faker?.Name.FirstName() ?? "";    
}