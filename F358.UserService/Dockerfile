FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["F358.UserService/F358.UserService.csproj", "F358.UserService/"]
COPY ["F358.Shared/F358.Shared.csproj", "F358.Shared/"]
COPY ["F358.UserService/.env", "F358.UserService/"]
RUN dotnet restore "F358.UserService/F358.UserService.csproj"
COPY . .
WORKDIR "/src/F358.UserService"
RUN dotnet build "./F358.UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./F358.UserService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "F358.UserService.dll"]
