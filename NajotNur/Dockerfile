#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NajotNur/NajotNur.csproj", "NajotNur/"]
COPY ["NajotNur.Application/NajotNur.Application.csproj", "NajotNur.Application/"]
COPY ["NajotNur.Domain/NajotNur.Domain.csproj", "NajotNur.Domain/"]
COPY ["NajotNur.Infrastructure/NajotNur.Infrastructure.csproj", "NajotNur.Infrastructure/"]
RUN dotnet restore "./NajotNur/./NajotNur.csproj"
COPY . .
WORKDIR "/src/NajotNur"
RUN dotnet build "./NajotNur.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NajotNur.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NajotNur.dll"]