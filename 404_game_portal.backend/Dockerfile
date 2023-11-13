FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["404_game_portal.backend/404_game_portal.backend.csproj", "404_game_portal.backend/"]
RUN dotnet restore "404_game_portal.backend/404_game_portal.backend.csproj"
COPY . .
WORKDIR "/src/404_game_portal.backend"
RUN dotnet build "404_game_portal.backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "404_game_portal.backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "404_game_portal.backend.dll"]
