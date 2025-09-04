FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SimpleECommerce.WebAPI/SimpleECommerce.WebAPI.csproj", "SimpleECommerce.WebAPI/"]
RUN dotnet restore "SimpleECommerce.WebAPI/SimpleECommerce.WebAPI.csproj"
COPY . .
WORKDIR "/src/SimpleECommerce.WebAPI"
RUN dotnet build "SimpleECommerce.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SimpleECommerce.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleECommerce.WebAPI.dll"]
