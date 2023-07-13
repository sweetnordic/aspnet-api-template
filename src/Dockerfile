FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
ARG CONFIGURATION=Release
WORKDIR /code
COPY src.csproj .
RUN dotnet restore src.csproj

COPY . .
RUN dotnet build src.csproj -c $CONFIGURATION --no-restore

RUN dotnet publish src.csproj -c $CONFIGURATION -o /app/publish --no-build

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Company.Application1.dll"]
