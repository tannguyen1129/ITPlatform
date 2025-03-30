# --------- Build stage ----------
    FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
    WORKDIR /src
    
    # Copy everything
    COPY . .
    
    # Restore and publish
    RUN dotnet restore ITPlatform.sln
    RUN dotnet publish ITPlatformUMT/ITPlatformUMT.csproj -c Release -o /app/publish
    
    # --------- Runtime stage ----------
    FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
    WORKDIR /app
    COPY --from=build /app/publish ./
    ENTRYPOINT ["dotnet", "ITPlatformUMT.dll"]
    