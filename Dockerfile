# Sử dụng image SDK .NET để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env  # Giữ nguyên nếu dự án vẫn là 8.0
WORKDIR /app

# Copy file .csproj và restore các dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ source code và publish ứng dụng
COPY . ./
RUN dotnet publish -c Release -o out

# Sử dụng image ASP.NET Core runtime để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:8.0  
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "HistoryAPI.dll"]