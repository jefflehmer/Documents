FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Documents/Documents.csproj", "Documents/"]

RUN dotnet restore "Documents/Documents.csproj"
COPY . .
WORKDIR "/src/Documents"
RUN dotnet build "Documents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Documents.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Documents.dll"]