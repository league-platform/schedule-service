FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ./ScheduleService ./ScheduleService
WORKDIR /src/ScheduleService
RUN dotnet restore "ScheduleService.csproj"
RUN dotnet publish "ScheduleService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ScheduleService.dll"]
