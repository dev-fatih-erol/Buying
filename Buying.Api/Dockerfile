#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Buying.Api/Buying.Api.csproj", "Buying.Api/"]
COPY ["Buying.Infrastructure/Buying.Infrastructure.csproj", "Buying.Infrastructure/"]
COPY ["Buying.Application/Buying.Application.csproj", "Buying.Application/"]
RUN dotnet restore "Buying.Api/Buying.Api.csproj"
COPY . .
WORKDIR "/src/Buying.Api"
RUN dotnet build "Buying.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Buying.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Buying.Api.dll"]
