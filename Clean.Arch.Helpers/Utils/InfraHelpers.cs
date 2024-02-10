using System.Configuration;

namespace Clean.Arch.Helpers.Utils;

public static class InfraHelpers
{
    public static string? GetConnectionString()
    {
        string? provider = ConfigurationManager.AppSettings["provider"];
        if (string.IsNullOrEmpty(provider))
            throw new NullReferenceException("Invalid provider on app.config");

        string? connectionString = ConfigurationManager.ConnectionStrings[provider]?.ConnectionString;
        if (string.IsNullOrEmpty(connectionString))
            throw new NullReferenceException("Invalid connectionString on app.config");

        return connectionString;
    }
}
