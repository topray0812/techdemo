FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY TechDemo.Auth.API/TechDemo.Auth.API.csproj TechDemo.Auth.API/
RUN dotnet restore "TechDemo.Auth.API/TechDemo.Auth.API.csproj"
COPY . .
WORKDIR "/src/TechDemo.Auth.API"
RUN dotnet build "TechDemo.Auth.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TechDemo.Auth.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TechDemo.Auth.API.dll"]
