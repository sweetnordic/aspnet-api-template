FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["Host/Host.csproj", "./Host/"]
COPY ["Core/Core.csproj", "./Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "./Infrastructure/"]
RUN dotnet restore Host/Host.csproj
COPY . .
WORKDIR /src/Host
RUN dotnet build -c Release -o /app/build

RUN dotnet publish Host.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Company.Application1.Host.dll"]
