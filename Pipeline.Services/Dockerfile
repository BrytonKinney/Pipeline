FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Pipeline.Services/Pipeline.Services.csproj", "Pipeline.Services/"]
RUN dotnet restore "Pipeline.Services/Pipeline.Services.csproj"
COPY . .
WORKDIR "/src/Pipeline.Services"
RUN dotnet build "Pipeline.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pipeline.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pipeline.Services.dll"]