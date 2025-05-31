namespace ListProject;

public static class PathHelper
{
    public static string? GetProjectPath()
    {
        try
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        }
        catch(NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public static string GetDataPath() => Path.Combine(GetProjectPath(), @"Data\");

    public static string GetFilePath(string fileName) => Path.Combine(GetDataPath(), $"{fileName}");
}