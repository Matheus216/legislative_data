using System.Text;

namespace bill_project.Application.Helper;

public static class FileHelper
{
    public static string GenerateFile(string content, string reportName)
    {
        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        var path = Path.Combine(projectDirectory, "generated_reports", reportName);
        using var reader = File.Create(path);

        byte[] data = Encoding.UTF8.GetBytes(content);
        reader.Write(data, 0, data.Length);

        return path;
    }
}