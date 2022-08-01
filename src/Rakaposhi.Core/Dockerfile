#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Rakaposhi.API.Core/Rakaposhi.API.COPY.csproj", "Rakaposhi.API.COPY.csproj/"]
COPY ["Rakaposhi.Business.Core/Rakaposhi.Business.Core.csproj", "Rakaposhi.Business.Core.csproj/"]
COPY ["Rakaposhi.Data/Rakaposhi.Data.csproj", "Rakaposhi.Data.csproj/"]
RUN dotnet restore "Rakaposhi.API.Core/Rakaposhi.API.COPY.csproj"
COPY . .
WORKDIR "/src/Rakaposhi.API.Core"
RUN dotnet build "Rakaposhi.API.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rakaposhi.API.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rakaposhi.API.Core.dll"]