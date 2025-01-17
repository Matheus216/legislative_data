using bill_project.Domain.Entities;
using System.Diagnostics;

namespace bill_project.infrastructure;


/// <summary>
/// In here I would make one repository for each entity but to void overengineering 
/// I will make one repository for all files
/// </summary>
public class FileRepository
{
    private readonly string _path;

    public FileRepository()
    {
        _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "infrastructure", "Resources");    
    }

    public async Task<List<string[]>> ReadFile(string fileName)
    {
        var response = new List<string[]>();

        using var reader = new StreamReader(Path.Combine(_path, fileName));

        string? line;
        bool head = true;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (head)
            {
                head = false;
                continue;
            }
            response.Add(line.Split(','));
        }

        return response;

    }
}