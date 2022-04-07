#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IntegraCompanies.Api/IntegraCompanies.Api.csproj", "IntegraCompanies.Api/"]
COPY ["IntegraCompanies.Data/IntegraCompanies.Data.csproj", "IntegraCompanies.Data/"]
COPY ["IntegraCompanies.Core/IntegraCompanies.Core.csproj", "IntegraCompanies.Core/"]
RUN dotnet restore "IntegraCompanies.Api/IntegraCompanies.Api.csproj"
COPY . .
WORKDIR "/src/IntegraCompanies.Api"
RUN dotnet build "IntegraCompanies.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegraCompanies.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegraCompanies.Api.dll"]