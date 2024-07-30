# Etapa base: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build: SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


COPY src/TechChallenge.Api/TechChallenge.Api.csproj src/TechChallenge.Api/
COPY src/TechChallenge.Business/TechChallenge.Business.csproj src/TechChallenge.Business/
COPY src/TechChallenge.Data/TechChallenge.Data.csproj src/TechChallenge.Data/


RUN dotnet restore src/TechChallenge.Api/TechChallenge.Api.csproj

COPY . .
WORKDIR /src/src/TechChallenge.Api
RUN dotnet build TechChallenge.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish TechChallenge.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final: runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallenge.Api.dll"]
