FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80

WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
ENTRYPOINT ["dotnet", "AnimalCrossing.dll"]