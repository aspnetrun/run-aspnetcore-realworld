# STAGE 1: Build
# We switched from 'dotnet/core/sdk:3.1' to 'dotnet/sdk:5.0'
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# 1. Copy the project files
COPY src/AspnetRun.Core/*.csproj ./src/AspnetRun.Core/
COPY src/AspnetRun.Application/*.csproj ./src/AspnetRun.Application/
COPY src/AspnetRun.Infrastructure/*.csproj ./src/AspnetRun.Infrastructure/
COPY src/AspnetRun.Web/*.csproj ./src/AspnetRun.Web/

# 2. Restore dependencies
RUN dotnet restore src/AspnetRun.Web/AspnetRun.Web.csproj

# 3. Copy the rest of the source code
COPY src/ ./src/

# 4. Build and Publish
WORKDIR /app/src/AspnetRun.Web
RUN dotnet publish -c Release -o /app/publish

# STAGE 2: Runtime
# We switched from 'dotnet/core/aspnet:3.1' to 'dotnet/aspnet:5.0'
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "AspnetRun.Web.dll"]
