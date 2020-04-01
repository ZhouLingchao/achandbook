FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
EXPOSE 80

WORKDIR /src
COPY /release /app

WORKDIR /app
ENTRYPOINT ["dotnet", "AnimalCrossing.dll"]