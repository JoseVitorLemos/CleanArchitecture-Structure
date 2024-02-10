using System.Reflection;

namespace Clean.Arch.Helpers.Utils;

public static class AssemblyHelpers
{
    public static string? AssemblyDirectory
    {
        get
        {
            string codeBase = Assembly.GetExecutingAssembly().Location ?? string.Empty;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
