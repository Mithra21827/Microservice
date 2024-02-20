FROM mcr.Microsoft.com/dotnet/sdk:6.0 AS build-dev
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.Microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app
COPY --from=build-dev /app/out .
ENTRYPOINT ["dotnet", "PlatfromService.dll"]
