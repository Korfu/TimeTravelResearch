FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TimeTravelResearch.csproj", "./"]
RUN dotnet restore "TimeTravelResearch.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TimeTravelResearch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTravelResearch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeTravelResearch.dll"] 