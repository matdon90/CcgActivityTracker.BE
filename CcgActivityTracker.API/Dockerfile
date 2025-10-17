# Etap build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Skopiuj pliki solution i przywróć paczki
COPY ["CcgActivityTracker.API/CcgActivityTracker.API.csproj", "CcgActivityTracker.API/"]
COPY ["CcgActivityTracker.Infrastructure/CcgActivityTracker.Infrastructure.csproj", "CcgActivityTracker.Infrastructure/"]
COPY ["CcgActivityTracker.Application/CcgActivityTracker.Application.csproj", "CcgActivityTracker.Application/"]
COPY ["CcgActivityTracker.Domain/CcgActivityTracker.Domain.csproj", "CcgActivityTracker.Domain/"]

RUN dotnet restore "CcgActivityTracker.API/CcgActivityTracker.API.csproj"

# Skopiuj resztę kodu i zbuduj
COPY . .
WORKDIR "/src/CcgActivityTracker.API"
RUN dotnet publish -c Release -o /app/publish

# Etap runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CcgActivityTracker.API.dll"]
