# Usando a imagem base do ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Usando a imagem do SDK do .NET para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RelatoriosAPI/RelatoriosAPI.csproj", "RelatoriosAPI/"]
RUN dotnet restore "RelatoriosAPI/RelatoriosAPI.csproj"
COPY . .
WORKDIR "/src/RelatoriosAPI"
RUN dotnet build "RelatoriosAPI.csproj" -c Release -o /app/build

# Publicar a aplicação
FROM build AS publish
RUN dotnet publish "RelatoriosAPI.csproj" -c Release -o /app/publish

# Configurar a imagem final com as dependências e a aplicação
FROM base AS final
WORKDIR /app

# Instalar dependências necessárias para libwkhtmltox.so
RUN apt-get update && apt-get install -y --no-install-recommends libgdiplus || exit 1
RUN apt-get install -y --no-install-recommends libc6-dev || exit 1
RUN apt-get install -y --no-install-recommends libx11-dev || exit 1
RUN apt-get install -y --no-install-recommends libxext-dev || exit 1
RUN apt-get install -y --no-install-recommends libxrender-dev || exit 1
RUN apt-get install -y --no-install-recommends libxtst-dev || exit 1
RUN apt-get install -y --no-install-recommends libfontconfig1 || exit 1
RUN apt-get install -y --no-install-recommends libx11-6 || exit 1
RUN apt-get install -y --no-install-recommends libxext6 || exit 1
RUN apt-get install -y --no-install-recommends libxrender1 || exit 1
RUN apt-get install -y --no-install-recommends libssl-dev || exit 1
RUN apt-get install -y --no-install-recommends xfonts-75dpi || exit 1
RUN apt-get install -y --no-install-recommends xfonts-base || exit 1
RUN rm -rf /var/lib/apt/lists/*

# Copiar a publicação e a biblioteca nativa
COPY --from=publish /app/publish .
COPY ["RelatoriosAPI/lib", "./lib"]

ENTRYPOINT ["dotnet", "RelatoriosAPI.dll"]
