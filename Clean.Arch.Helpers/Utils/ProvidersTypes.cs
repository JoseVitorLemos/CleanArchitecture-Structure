using System.Configuration;
using Clean.Arch.Helpers.Enums;
using Clean.Arch.Helpers.Validations;

namespace Clean.Arch.Helpers.Utils;

public class Providers
{
    public ProvidersTypes ProviderName { get; private set; }
    public string ConnectionString { get; private set; }

    public Providers()
    {
        Enum.TryParse(ConfigurationManager.AppSettings["provider"], true, out ProvidersTypes provider);
        ExceptionValidation.When(provider.Equals(ProvidersTypes.Undefined), "ProvaiderName cannot be null");

        ConnectionStringSettings stringSettings = ConfigurationManager.ConnectionStrings[provider.ToString()];
        ExceptionValidation.When(stringSettings.Name != provider.ToString(), "Connection name does not represent Provider Name");
        ExceptionValidation.When(string.IsNullOrEmpty(stringSettings.ConnectionString), "ConnectionString cannot be null");

        ProviderName = provider;
        ConnectionString = stringSettings.ConnectionString;
    }
}
