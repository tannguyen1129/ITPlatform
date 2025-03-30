# --------- Build stage ----------
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /src
    
    # Copy solution and project files
    COPY . .
    RUN dotnet restore ITPlatform.sln
    RUN dotnet publish ITPlatformUMT/ITPlatformUMT.csproj -c Release -o /app/publish
    
    # --------- Runtime stage ----------
    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
    WORKDIR /app
    COPY --from=build /app/publish ./
    ENTRYPOINT ["dotnet", "ITPlatformUMT.dll"]
    