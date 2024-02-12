using System.Reflection;
using Clean.Arch.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Clean.Arch.Helpers.Utils;
using Clean.Arch.Helpers.Enums;

namespace Clean.Arch.DependencyInversion;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraInjection(this IServiceCollection services)
    {
        RegisterConstext(services);

        var classes = Assembly.Load("Clean.Arch.Data")
            .GetTypes().Where(c => c.IsClass && !c.IsAbstract && !c.IsGenericType && c.IsPublic);

        foreach (var classType in classes)
        {
            var interfaces = Assembly.Load("Clean.Arch.Domain")
                .GetTypes().Where(i => i.IsInterface && i.IsAssignableFrom(classType));

            foreach (var interfaceType in interfaces)
                services.AddScoped(interfaceType, classType);
        }

        return services;
    }

    private static void RegisterConstext(IServiceCollection services)
    {
        switch (InfraHelpers.GetConnectionString().ProviderName)
        {
            case ProvidersTypes.SqlServer:
                services.AddDbContext<DataContext>(options => options.UseSqlServer(InfraHelpers.GetConnectionString().ConnectionString,
                                                   x => x.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));
                break;

            default:
                throw new Exception("Provider not implemented");
        }
    }
}
