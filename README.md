# CleanArchitecture-Structure

1. Presentation has the reference DependencyInversion and Services 
2. DependencyInversion has the reference Domain, Data, Service and Business
3. Service has the reference Domain and Business
4. Business has the reference Domain
5. Data has the reference domain
6. Domain has no reference 

</br>
</br>

![clean architecture](https://github.com/JoseVitorLemos/CleanArchitecture-Structure/assets/50563095/451aed5d-ec8e-4130-8c92-0cb42e1d875d)
<p>source: Clean Architecture: A Craftsman's Guide to Software Structure and Design</p>

</br>

<h1>Utils</h1>
<h2>Create projects</h2>
<ul>
  <li>dotnet new classlib --name Clean.Arch.Presentation</li>
  <li>dotnet new classlib --name Clean.Arch.Services</li>
  <li>dotnet new classlib --name Clean.Arch.Domain</li>
  <li>dotnet new classlib --name Clean.Arch.DependencyInversion</li>
  <li>dotnet new classlib --name Clean.Arch.Data</li>
  <li>dotnet new xunit --name Clean.Arch.Tests</li>
  <li>dotnet new classlib --name Clean.Arch.Helpers</li>
  <li>dotnet new classlib --name Clean.Arch.Business</li>
</ul>

<h2>Create global solution</h2>
<ul>
  <li>dotnet new sln --name CleanArchitecture</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Presentation/Clean.Arch.Presentation.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Services/Clean.Arch.Services.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Domain/Clean.Arch.Domain.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Data/Clean.Arch.Data.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Tests/Clean.Arch.Tests.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Helpers/Clean.Arch.Helpers.csproj</li>
  <li>dotnet sln CleanArchitecture.sln add Clean.Arch.Business/Clean.Arch.Business.csproj</li>
</ul>

<h2>Structure references</h2>

<h3>Presentation</h3>
<ul>
  <li>dotnet add Clean.Arch.Presentation/Clean.Arch.Presentation.csproj reference Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj</li>
  <li>dotnet add Clean.Arch.Presentation/Clean.Arch.Presentation.csproj reference Clean.Arch.Services/Clean.Arch.Services.csproj</li>
</ul>

<h3>Infra Dependency Inversion</h3>
<ul>
  <li>dotnet add Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj reference Clean.Arch.Domain/Clean.Arch.Domain.csproj</li>
  <li>dotnet add Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj reference Clean.Arch.Data/Clean.Arch.Data.csproj</li>
  <li>dotnet add Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj reference Clean.Arch.Services/Clean.Arch.Services.csproj</li>
  <li>dotnet add Clean.Arch.DependencyInversion/Clean.Arch.DependencyInversion.csproj reference Clean.Arch.Business/Clean.Arch.Business.csproj</li>
</ul>

<h3>Services</h3>
<ul>
  <li>dotnet add Clean.Arch.Services/Clean.Arch.Services.csproj reference Clean.Arch.Business/Clean.Arch.Business.csproj</li>
  <li>dotnet add Clean.Arch.Services/Clean.Arch.Services.csproj reference Clean.Arch.Domain/Clean.Arch.Domain.csproj</li>
</ul>

<h3>Business</h3>
<ul>
  <li>dotnet add Clean.Arch.Business/Clean.Arch.Business.csproj reference Clean.Arch.Domain/Clean.Arch.Domain.csproj</li>
</ul>

<h3>Data</h3>
<ul>
  <li>dotnet add Clean.Arch.Data/Clean.Arch.Data.csproj reference Clean.Arch.Domain/Clean.Arch.Domain.csproj</li>
</ul>

<h2>Create migrations, update and remove</h2>
<ul>
  <li>dotnet ef migrations add MIGRATION_NAME --project Clean.Arch.Data -s Clean.Arch.Presentation -c DataContext --verbose</li>
  <li>dotnet ef migrations remove --project Clean.Arch.Data -s Clean.Arch.Presentation -c DataContext --verbose</li>
  <li>dotnet ef database update --project Clean.Arch.Data -s Clean.Arch.Presentation -c DataContext --verbose</li>
</ul>
