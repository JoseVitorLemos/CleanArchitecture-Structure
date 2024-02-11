# CleanArchitecture-Structure

1. Domain has no reference
2. Service has the reference domain
3. Data has the reference domain
4. DIP has the reference domain, application and data
5. Presentation has the reference DIP
</br>
</br>

![clean architecture](https://github.com/JoseVitorLemos/CleanArchitecture-Structure/assets/50563095/451aed5d-ec8e-4130-8c92-0cb42e1d875d)
<p>source: Clean Architecture: A Craftsman's Guide to Software Structure and Design</p>

</br>

<h1>Utils</h1>
<h3>Create projects</h3>

1. dotnet new classlib --name Clean.Arch.Presentatiom
2. dotnet new classlib --name Clean.Arch.Services
3. dotnet new classlib --name Clean.Arch.Domaim
4. dotnet new classlib --name Clean.Arch.DependencyInversion
5. dotnet new classlib --name Clean.Arch.Data
6. dotnet new xunit --name Clean.Arch.Tests
7. dotnet new classlib --name Clean.Arch.Helpers

<h3>Create global solution</h3>

1. dotnet new sln --name CleanArchitecture 
2. dotnet sln CleanArchitecture.sln add Clean.Arch.Presentation/Clean.Arch.Presentation.csproj
3. dotnet sln CleanArchitecture.sln add Clean.Arch.Services/Clean.Arch.Services.csproj
4. dotnet sln CleanArchitecture.sln add Clean.Arch.Domain/Clean.Arch.Domain.csproj
5. dotnet sln CleanArchitecture.sln add Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj
6. dotnet sln CleanArchitecture.sln add Clean.Arch.Data/Clean.Arch.Data.csproj
7. dotnet sln CleanArchitecture.sln add Clean.Arch.Tests/Clean.Arch.Tests.csproj
8. dotnet sln CleanArchitecture.sln add Clean.Arch.Helpers/Clean.Arch.Helpers.csproj

<h3>Create migrations and remove</h3>
dotnet ef migrations add MIGRATION_NAME --project Clean.Arch.Data -s Clean.Arch.Presentation -c DataContext --verbose
dotnet ef migrations remove --project Clean.Arch.Data -s Clean.Arch.Presentation -c DataContext --verbose

