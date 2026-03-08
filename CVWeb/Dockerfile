FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY CVWeb/CVSystem.csproj CVWeb/
RUN dotnet restore CVWeb/CVSystem.csproj

COPY CVWeb/. ./CVWeb/
WORKDIR /src/CVWeb

RUN dotnet publish CVSystem.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CVSystem.dll"]