FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY ./Payment.Gateway.Api/*.csproj ./Payment.Gateway.Api/
RUN dotnet restore ./Payment.Gateway.Api/

COPY ./Payment.Gateway.Api.Client/*.csproj ./Payment.Gateway.Api.Client/
RUN dotnet restore ./Payment.Gateway.Api.Client/

COPY ./ ./
RUN dotnet publish ./Payment.Gateway.Api/ -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Payment.Gateway.Api.dll"]