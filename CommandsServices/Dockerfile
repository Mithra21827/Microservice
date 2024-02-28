FROM mcr.Microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c release  -o out

FROM mcr.Microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/out ./
CMD ["dotnet","CommandsServices.dll"]

