using System.Reflection;
using Clean.Arch.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Clean.Arch.Helpers.Utils;

namespace Clean.Arch.DependencyInversion;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraInjection(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options => options.UseSqlServer(InfraHelpers.GetConnectionString(),
                                           x => x.MigrationsAssembly(typeof(DbContext).Assembly.FullName)));

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
}
