
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env 
WORKDIR /app

# Copy file .csproj và restore các dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ source code và publish ứng dụng
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0  
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "HistoryAPI.dll"]
