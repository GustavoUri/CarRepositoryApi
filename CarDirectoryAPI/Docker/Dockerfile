FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarDirectoryAPI/CarDirectoryAPI.csproj", "CarDirectoryAPI/"]
RUN dotnet restore "CarDirectoryAPI/CarDirectoryAPI.csproj"
COPY . .
WORKDIR "/src/CarDirectoryAPI"
RUN dotnet build "CarDirectoryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarDirectoryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarDirectoryAPI.dll"]
