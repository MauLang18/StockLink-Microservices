#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Softland.Api/StockLink.Softland.Api.csproj", "StockLink.Softland.Api/"]
COPY ["StockLink.Shared.JWT/StockLink.Shared.JWT.csproj", "StockLink.Shared.JWT/"]
COPY ["StockLink.Softland.Application.UseCase/StockLink.Softland.Application.UseCase.csproj", "StockLink.Softland.Application.UseCase/"]
COPY ["StockLink.Softland.Application.Dto/StockLink.Softland.Application.Dto.csproj", "StockLink.Softland.Application.Dto/"]
COPY ["StockLink.Softland.Application.Interface/StockLink.Softland.Application.Interface.csproj", "StockLink.Softland.Application.Interface/"]
COPY ["StockLink.Softland.Domain/StockLink.Softland.Domain.csproj", "StockLink.Softland.Domain/"]
COPY ["StockLink.Softland.Utilities/StockLink.Softland.Utilities.csproj", "StockLink.Softland.Utilities/"]
COPY ["StockLink.Softland.Persistence/StockLink.Softland.Persistence.csproj", "StockLink.Softland.Persistence/"]
RUN dotnet restore "./StockLink.Softland.Api/./StockLink.Softland.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Softland.Api"
RUN dotnet build "./StockLink.Softland.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Softland.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Softland.Api.dll"]