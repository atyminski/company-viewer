```
dotnet ef migrations add Initial -o Infrastructure\Persistence\Migrations --startup-project ..\Gevlee.CompanyViewer.WebApi\Gevlee.CompanyViewer.WebApi.csproj --context Gevlee.CompanyViewer.Core.Infrastructure.Persistence.PostgresCompaniesDbContext
dotnet ef migrations remove --startup-project ..\Gevlee.CompanyViewer.WebApi\Gevlee.CompanyViewer.WebApi.csproj --context Gevlee.CompanyViewer.Core.Infrastructure.Persistence.PostgresCompaniesDbContext
dotnet ef database update --startup-project ..\Gevlee.CompanyViewer.WebApi\Gevlee.CompanyViewer.WebApi.csproj --context Gevlee.CompanyViewer.Core.Infrastructure.Persistence.PostgresCompaniesDbContext
```