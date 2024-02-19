#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Cotizacion.Api/StockLink.Cotizacion.Api.csproj", "StockLink.Cotizacion.Api/"]
COPY ["StockLink.Cotizacion.Application/StockLink.Cotizacion.Application.csproj", "StockLink.Cotizacion.Application/"]
COPY ["StockLink.Cotizacion.Domain/StockLink.Cotizacion.Domain.csproj", "StockLink.Cotizacion.Domain/"]
COPY ["StockLink.Cotizacion.Infrastructure/StockLink.Cotizacion.Infrastructure.csproj", "StockLink.Cotizacion.Infrastructure/"]
COPY ["StockLink.Cotizacion.Utilities/StockLink.Cotizacion.Utilities.csproj", "StockLink.Cotizacion.Utilities/"]
COPY ["StockLink.Shared.Entities/StockLink.Shared.Entities.csproj", "StockLink.Shared.Entities/"]
RUN dotnet restore "./StockLink.Cotizacion.Api/./StockLink.Cotizacion.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Cotizacion.Api"
RUN dotnet build "./StockLink.Cotizacion.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Cotizacion.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Cotizacion.Api.dll"]