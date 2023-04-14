FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
ARG CONFIGURATION=Release
WORKDIR /code
COPY src/Infrastructure/Infrastructure.csproj src/Infrastructure/
COPY src/Host/Host.csproj src/Host/
COPY src/Core/Core.csproj src/Core/
RUN dotnet restore src/Host/Host.csproj

COPY . .
RUN dotnet build src/Host/Host.csproj -c $CONFIGURATION --no-restore

RUN dotnet publish src/Host/Host.csproj -c $CONFIGURATION -o /app/publish --no-build

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Company.Application1.Host.dll"]
