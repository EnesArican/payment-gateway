FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY ./Pokemon.Api/*.csproj ./Pokemon.Api/
RUN dotnet restore ./Pokemon.Api/

COPY ./Pokemon.Api.Client/*.csproj ./Pokemon.Api.Client/
RUN dotnet restore ./Pokemon.Api.Client/

COPY ./ ./
RUN dotnet publish ./Pokemon.Api/ -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Pokemon.Api.dll"]