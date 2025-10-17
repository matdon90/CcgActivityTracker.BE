# Etap build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Skopiuj pliki csproj
COPY ["CcgActivityTracker.BE/CcgActivityTracker.API/CcgActivityTracker.API.csproj", "CcgActivityTracker.API/"]
COPY ["CcgActivityTracker.BE/CcgActivityTracker.Application/CcgActivityTracker.Application.csproj", "CcgActivityTracker.Application/"]
COPY ["CcgActivityTracker.BE/CcgActivityTracker.Domain/CcgActivityTracker.Domain.csproj", "CcgActivityTracker.Domain/"]
COPY ["CcgActivityTracker.BE/CcgActivityTracker.Infrastructure/CcgActivityTracker.Infrastructure.csproj", "CcgActivityTracker.Infrastructure/"]

# Przywróć paczki
RUN dotnet restore "CcgActivityTracker.API/CcgActivityTracker.API.csproj"

# Skopiuj resztę kodu
COPY CcgActivityTracker.BE/ .
WORKDIR "/src/CcgActivityTracker.API"
RUN dotnet publish -c Release -o /app/publish

# Etap runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CcgActivityTracker.API.dll"]
