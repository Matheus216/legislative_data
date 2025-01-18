using System.Text;

namespace bill_project.Application.Helper;

public static class FileHelper
{
    public static string GenerateFile(string content, string reportName)
    {
        string projectDirectory = Path.Combine(
            Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName ?? ""
            ,"generated_reports"
            );

        projectDirectory.CreateDirectory();

        var path = Path.Combine(projectDirectory, reportName);
        using var reader = File.Create(path);

        byte[] data = Encoding.UTF8.GetBytes(content);
        reader.Write(data, 0, data.Length);

        return path;
    }

    public static void CreateDirectory(this string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        if (!di.Exists)
        {
            di.Create();
        }   
    }
}