#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Hubs.Api/StockLink.Hubs.Api.csproj", "StockLink.Hubs.Api/"]
COPY ["StockLink.Shared.Entities/StockLink.Shared.Entities.csproj", "StockLink.Shared.Entities/"]
RUN dotnet restore "./StockLink.Hubs.Api/./StockLink.Hubs.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Hubs.Api"
RUN dotnet build "./StockLink.Hubs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Hubs.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Hubs.Api.dll"]