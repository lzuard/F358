FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["F358.Api/F358.Api.csproj", "F358.Api/"]
COPY ["F358.Shared/F358.Shared.csproj", "F358.Shared/"]
COPY ["F358.Api/.env", "F358.Api/"]
RUN dotnet restore "F358.Api/F358.Api.csproj"
COPY . .
WORKDIR "/src/F358.Api"
RUN dotnet build "./F358.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./F358.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "F358.Api.dll"]
