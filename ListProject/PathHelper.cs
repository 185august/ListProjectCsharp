namespace ListProject;

public static class PathHelper
{
    public static string? GetProjectPath() => 
        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;

    public static string GetDataPath() => 
        Path.Combine(GetProjectPath(), @"Data\");
    
    public static string GetFilePath(string fileName) => 
        Path.Combine(GetDataPath(), $"{fileName}");
}