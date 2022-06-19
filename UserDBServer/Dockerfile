FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM prom/prometheus  
ADD Prometheus/prometheus.yml /etc/prometheus/ 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserDBServer/UserDBServer.csproj", "UserDBServer/"]
RUN dotnet restore "UserDBServer/UserDBServer.csproj"
COPY . .
WORKDIR "/src/UserDBServer"
RUN dotnet build "UserDBServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserDBServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserDBServer.dll"]
