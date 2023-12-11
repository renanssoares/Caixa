#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Caixa.Api/Caixa.Api.csproj", "Caixa.Api/"]
COPY ["Caixa.Infra/Caixa.Infra.csproj", "Caixa.Infra/"]
COPY ["Caixa.Service/Caixa.Service.csproj", "Caixa.Service/"]
RUN dotnet restore "./Caixa.Api/./Caixa.Api.csproj"
COPY . .
WORKDIR "/src/Caixa.Api"
RUN dotnet build "./Caixa.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Caixa.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Caixa.Api.dll"]