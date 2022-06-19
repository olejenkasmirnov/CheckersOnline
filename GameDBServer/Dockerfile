FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GameDBServer/GameDBServer.csproj", "GameDBServer/"]
RUN dotnet restore "GameDBServer/GameDBServer.csproj"
COPY . .
WORKDIR "/src/GameDBServer"
RUN dotnet build "GameDBServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameDBServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameDBServer.dll"]
