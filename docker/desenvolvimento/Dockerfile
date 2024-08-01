# Stage 1: Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Stage 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RelatoriosAPI/RelatoriosAPI.csproj", "RelatoriosAPI/"]
RUN dotnet restore "RelatoriosAPI/RelatoriosAPI.csproj"
COPY . .
WORKDIR "/src/RelatoriosAPI"
RUN dotnet build "RelatoriosAPI.csproj" -c Release -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "RelatoriosAPI.csproj" -c Release -o /app/publish

# Stage 4: Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RelatoriosAPI.dll"]
