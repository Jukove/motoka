# Use a imagem oficial do SDK do .NET 8.0 como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos do projeto e restaure as depend�ncias
COPY ["Motoka/Motoka.csproj", "Motoka/"]
COPY ["Motoka.BackgroundTask/Motoka.BackgroundTask.csproj", "Motoka.BackgroundTask/"]
COPY ["Motoka.Contracts/Motoka.Contracts.csproj", "Motoka.Contracts/"]
COPY ["Motoka.Postgres/Motoka.Postgres.csproj", "Motoka.Postgres/"]
COPY ["Motoka.RabbitMq/Motoka.RabbitMq.csproj", "Motoka.RabbitMq/"]
COPY ["Motoka.Domain/Motoka.Domain.csproj", "Motoka.Domain/"]
COPY ["Motoka.Service/Motoka.Service.csproj", "Motoka.Service/"]
RUN dotnet restore "./Motoka/Motoka.csproj"

# Copie o restante dos arquivos do projeto
COPY . .

# Construa a aplica��o
RUN dotnet build "Motoka/Motoka.csproj" -c Release -o /app/build

# Publicar a aplica��o
FROM build AS publish
RUN dotnet publish "./Motoka.csproj" -c Release -o /app/publish

# Use a imagem oficial do ASP.NET Core 8.0 como base para a aplica��o final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copie os arquivos publicados para a imagem final
COPY --from=publish /app/publish .

# Exponha as portas necess�rias
EXPOSE 8080
EXPOSE 8081

# Defina o comando de entrada para iniciar a aplica��o quando o cont�iner for iniciado
ENTRYPOINT ["dotnet", "Motoka.dll"]
