# Stage 1 - Build the .NET 8 application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy all source files
COPY *.csproj .  
# Restore dependencies
RUN dotnet restore 
COPY . .
RUN dotnet publish -c Release -o out

# Stage 2 - Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

#Expose port 80 for HTTP
EXPOSE 80  

# Start the application
ENTRYPOINT ["dotnet", "WeatherApi.dll"]  
