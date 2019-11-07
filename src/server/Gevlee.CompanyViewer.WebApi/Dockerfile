FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Gevlee.CompanyViewer.WebApi/Gevlee.CompanyViewer.WebApi.csproj", "Gevlee.CompanyViewer.WebApi/"]
COPY ["Gevlee.CompanyViewer.Core/Gevlee.CompanyViewer.Core.csproj", "Gevlee.CompanyViewer.Core/"]
RUN dotnet restore "Gevlee.CompanyViewer.WebApi/Gevlee.CompanyViewer.WebApi.csproj"
COPY . .
WORKDIR "/src/Gevlee.CompanyViewer.WebApi"
RUN dotnet build "Gevlee.CompanyViewer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gevlee.CompanyViewer.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
VOLUME /logs
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gevlee.CompanyViewer.WebApi.dll"]