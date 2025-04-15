# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo de uma vez (sln, pastas, csproj)
COPY . . 

# Restaura dependências
RUN dotnet restore Reservas.sln

# Publica o projeto principal
WORKDIR /app/Reservas.API
RUN dotnet publish -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Reservas.API.dll"]
