#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Auth.Api/StockLink.Auth.Api.csproj", "StockLink.Auth.Api/"]
COPY ["StockLink.Auth.Application/StockLink.Auth.Application.csproj", "StockLink.Auth.Application/"]
COPY ["StockLink.Auth.Domain/StockLink.Auth.Domain.csproj", "StockLink.Auth.Domain/"]
COPY ["StockLink.Auth.Infrastructure/StockLink.Auth.Infrastructure.csproj", "StockLink.Auth.Infrastructure/"]
COPY ["StockLink.Auth.Utilities/StockLink.Auth.Utilities.csproj", "StockLink.Auth.Utilities/"]
COPY ["StockLink.Shared.JWT/StockLink.Shared.JWT.csproj", "StockLink.Shared.JWT/"]
RUN dotnet restore "./StockLink.Auth.Api/./StockLink.Auth.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Auth.Api"
RUN dotnet build "./StockLink.Auth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Auth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Auth.Api.dll"]