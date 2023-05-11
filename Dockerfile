FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

COPY Assignment4.sln .
COPY Assignment4/*.csproj Assignment4/
COPY Hearthstone.DataAccess/*.csproj Hearthstone.DataAccess/
RUN dotnet restore

COPY Assignment4/. ./Assignment4
COPY Hearthstone.DataAccess/. ./Hearthstone.DataAccess
WORKDIR /source
RUN dotnet publish -c Release -o /app

COPY localhost.pfx /app/

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY  --from=build /app ./
ENTRYPOINT ["dotnet", "Assignment4.dll"]