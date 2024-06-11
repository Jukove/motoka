#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Motoka/Motoka.csproj", "Motoka/"]
COPY ["Motoka.BackgroundTask/Motoka.BackgroundTask.csproj", "Motoka.BackgroundTask/"]
COPY ["Motoka.Contracts/Motoka.Contracts.csproj", "Motoka.Contracts/"]
COPY ["Motoka.Postgres/Motoka.Postgres.csproj", "Motoka.Postgres/"]
COPY ["Motoka.RabbitMq/Motoka.RabbitMq.csproj", "Motoka.RabbitMq/"]
COPY ["Motoka.Domain/Motoka.Domain.csproj", "Motoka.Domain/"]
COPY ["Motoka.Service/Motoka.Service.csproj", "Motoka.Service/"]
RUN dotnet restore "./Motoka/Motoka.csproj"
COPY . .
WORKDIR "/src/Motoka"
RUN apt-get update && \
    apt-get install -y wget && \
    wget https://download.visualstudio.microsoft.com/download/pr/b4b8e2f2-1d96-4214-bbb7-10703d43d0c4/ffb0f5cd01afc015db3d618503b77c32/dotnet-framework-4.8-dev-pack.exe && \
    wine dotnet-framework-4.8-dev-pack.exe /quiet && \
    rm dotnet-framework-4.8-dev-pack.exe
# Instale o .NET SDK 6.0
RUN wget -q https://download.visualstudio.microsoft.com/download/pr/fb0e5271-22ae-4763-89a1-ef7fd3b9e1d2/24247061e3709c8390bb61da93d518e4/dotnet-sdk-6.0.100-win-x64.exe -O dotnet-sdk-6.0.exe && \
    wine dotnet-sdk-6.0.exe /quiet /norestart && \
    rm dotnet-sdk-6.0.exe

# Instale o .NET SDK 9.0
RUN wget -q https://download.visualstudio.microsoft.com/download/pr/f9e6e014-bb25-4f6c-b3d2-6c0d77d5b3d5/e03c4411c5bc7e20b1c79dc56e4a3b9a/dotnet-sdk-9.0.100-win-x64.exe -O dotnet-sdk-9.0.exe && \
    wine dotnet-sdk-9.0.exe /quiet /norestart && \
    rm dotnet-sdk-9.0.exe

# Instale o .NET Framework 4.7.2
RUN wget -q https://download.visualstudio.microsoft.com/download/pr/b4b8e2f2-1d96-4214-bbb7-10703d43d0c4/ffb0f5cd01afc015db3d618503b77c32/dotnet-framework-4.8-dev-pack.exe -O dotnet-framework-4.8-dev-pack.exe && \
    wine dotnet-framework-4.8-dev-pack.exe /quiet /norestart && \
    rm dotnet-framework-4.8-dev-pack.exe

# Instale o .NET Framework 4.7.1
RUN wget -q https://download.visualstudio.microsoft.com/download/pr/86e8ad4f-2299-4723-b887-06b72dfddb94/62fbcfd20fd3d03447307b8f16ccf226/dotnet-framework-4.7.1-dev-pack.exe -O dotnet-framework-4.7.1-dev-pack.exe && \
    wine dotnet-framework-4.7.1-dev-pack.exe /quiet /norestart && \
    rm dotnet-framework-4.7.1-dev-pack.exe
RUN dotnet build "./Motoka.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Motoka.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Motoka.dll"]