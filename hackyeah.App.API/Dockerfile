#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["hackyeah.App.API/hackyeah.App.API.csproj", "hackyeah.App.API/"]
COPY ["hackyeah.App.Application/hackyeah.App.Application.csproj", "hackyeah.App.Application/"]
COPY ["hackyeah.App.Domain/hackyeah.App.Domain.csproj", "hackyeah.App.Domain/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["hackyeah.App.Infrastructure/hackyeah.App.Infrastructure.csproj", "hackyeah.App.Infrastructure/"]
RUN dotnet restore "hackyeah.App.API/hackyeah.App.API.csproj"
COPY . .
WORKDIR "/src/hackyeah.App.API"
RUN dotnet build "hackyeah.App.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hackyeah.App.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hackyeah.App.API.dll"]