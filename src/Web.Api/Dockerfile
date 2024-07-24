FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

# Copy everything
COPY ["Directory.Build.props", "."]
COPY ["src/Web.Api/Web.Api.csproj", "app/Web.Api/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "app/Infrastructure/"]
COPY ["src/Application/Application.csproj", "app/Application/"]
COPY ["src/Domain/Domain.csproj", "app/Domain/"]
COPY ["src/SharedKernel/SharedKernel.csproj", "app/SharedKernel/"]

# Restore as distinct layers
RUN dotnet restore "./app/Web.Api/Web.Api.csproj"
COPY . .

# Build a release
WORKDIR "/app/src/Web.Api"
RUN dotnet build "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publish a release
RUN dotnet publish "./Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Api.dll"]