#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update

RUN apt-get install -y apt-utils

RUN apt-get install -y libgdiplus

RUN apt-get install -y libc6-dev
 
RUN ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockLink.Reports.Api/StockLink.Reports.Api.csproj", "StockLink.Reports.Api/"]
COPY ["StockLink.Reports.Application/StockLink.Reports.Application.csproj", "StockLink.Reports.Application/"]
COPY ["StockLink.Reports.Infrastructure/StockLink.Reports.Infrastructure.csproj", "StockLink.Reports.Infrastructure/"]
COPY ["StockLink.Reports.Utilities/StockLink.Reports.Utilities.csproj", "StockLink.Reports.Utilities/"]
COPY ["StockLink.Shared.Entities/StockLink.Shared.Entities.csproj", "StockLink.Shared.Entities/"]
RUN dotnet restore "./StockLink.Reports.Api/StockLink.Reports.Api.csproj"
COPY . .
WORKDIR "/src/StockLink.Reports.Api"
RUN dotnet build "./StockLink.Reports.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockLink.Reports.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockLink.Reports.Api.dll"]