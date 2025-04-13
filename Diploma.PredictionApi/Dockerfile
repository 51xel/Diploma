# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt-get update && apt-get install -y python3 python3-pip python3-dev python3-venv

RUN pip install joblib --break-system-packages

ENV PYTHONNET_PYDLL=/usr/lib/x86_64-linux-gnu/libpython3.11.so

USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Diploma.PredictionApi/Diploma.PredictionApi.csproj", "Diploma.PredictionApi/"]
COPY ["Diploma.Application/Diploma.Application.csproj", "Diploma.Application/"]
COPY ["Diploma.Domain/Diploma.Domain.csproj", "Diploma.Domain/"]
COPY ["Diploma.Contracts/Diploma.Contracts.csproj", "Diploma.Contracts/"]
COPY ["Diploma.Dal.EntityFramework/Diploma.Dal.EntityFramework.csproj", "Diploma.Dal.EntityFramework/"]
COPY ["Diploma.Dal.MemoryCache/Diploma.Dal.MemoryCache.csproj", "Diploma.Dal.MemoryCache/"]
COPY ["Diploma.Dal.PythonRunTime/Diploma.Dal.PythonRunTime.csproj", "Diploma.Dal.PythonRunTime/"]
COPY ["Diploma.Dal.RedisCache/Diploma.Dal.RedisCache.csproj", "Diploma.Dal.RedisCache/"]
COPY ["Diploma.Dal.Storage/Diploma.Dal.Storage.csproj", "Diploma.Dal.Storage/"]
RUN dotnet restore "./Diploma.PredictionApi/Diploma.PredictionApi.csproj"
COPY . . 
WORKDIR "/src/Diploma.PredictionApi"
RUN dotnet build "./Diploma.PredictionApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Diploma.PredictionApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diploma.PredictionApi.dll"]