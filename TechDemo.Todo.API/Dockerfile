FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY TechDemo.Todo.API/TechDemo.Todo.API.csproj TechDemo.Todo.API/
RUN dotnet restore "TechDemo.Todo.API/TechDemo.Todo.API.csproj"
COPY . .
WORKDIR "/src/TechDemo.Todo.API"
RUN dotnet build "TechDemo.Todo.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TechDemo.Todo.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TechDemo.Todo.API.dll"]
