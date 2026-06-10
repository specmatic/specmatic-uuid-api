FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "specmatic-uuid-api/specmatic-uuid-api.csproj"
RUN dotnet build "specmatic-uuid-api/specmatic-uuid-api.csproj" -c Release
RUN dotnet publish "specmatic-uuid-api/specmatic-uuid-api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "specmatic-uuid-api.dll"]