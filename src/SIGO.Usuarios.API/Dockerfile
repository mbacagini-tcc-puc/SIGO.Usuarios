#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SIGO.Usuarios.API/SIGO.Usuarios.API.csproj", "src/SIGO.Usuarios.API/"]
RUN dotnet restore "src/SIGO.Usuarios.API/SIGO.Usuarios.API.csproj"
COPY . .
WORKDIR "/src/src/SIGO.Usuarios.API"
RUN dotnet build "SIGO.Usuarios.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SIGO.Usuarios.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIGO.Usuarios.API.dll"]