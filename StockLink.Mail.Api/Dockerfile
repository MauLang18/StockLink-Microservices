#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Mail.Api/StockLink.Mail.Api.csproj", "StockLink.Mail.Api/"]
COPY ["StockLink.Mail.Application/StockLink.Mail.Application.csproj", "StockLink.Mail.Application/"]
COPY ["StockLink.Shared.Entities/StockLink.Shared.Entities.csproj", "StockLink.Shared.Entities/"]
RUN dotnet restore "./StockLink.Mail.Api/./StockLink.Mail.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Mail.Api"
RUN dotnet build "./StockLink.Mail.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Mail.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Mail.Api.dll"]