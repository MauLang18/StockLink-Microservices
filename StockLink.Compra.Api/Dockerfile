#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Compra.Api/StockLink.Compra.Api.csproj", "StockLink.Compra.Api/"]
COPY ["StockLink.Compra.Application.UseCase/StockLink.Compra.Application.UseCase.csproj", "StockLink.Compra.Application.UseCase/"]
COPY ["StockLink.Compra.Application.Dtos/StockLink.Compra.Application.Dtos.csproj", "StockLink.Compra.Application.Dtos/"]
COPY ["StockLink.Compra.Application.Interface/StockLink.Compra.Application.Interface.csproj", "StockLink.Compra.Application.Interface/"]
COPY ["StockLink.Compra.Domain/StockLink.Compra.Domain.csproj", "StockLink.Compra.Domain/"]
COPY ["StockLink.Compra.Utilities/StockLink.Compra.Utilities.csproj", "StockLink.Compra.Utilities/"]
COPY ["StockLink.Shared.Entities/StockLink.Shared.Entities.csproj", "StockLink.Shared.Entities/"]
COPY ["StockLink.Compra.Persistence/StockLink.Compra.Persistence.csproj", "StockLink.Compra.Persistence/"]
COPY ["StockLink.Shared.JWT/StockLink.Shared.JWT.csproj", "StockLink.Shared.JWT/"]
RUN dotnet restore "./StockLink.Compra.Api/./StockLink.Compra.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Compra.Api"
RUN dotnet build "./StockLink.Compra.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Compra.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Compra.Api.dll"]