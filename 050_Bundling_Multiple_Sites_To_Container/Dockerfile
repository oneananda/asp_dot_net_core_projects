# Stage 1: Build ASP.NET Web API
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-api
WORKDIR /src
COPY auth-site/ ./auth-site/
WORKDIR /src/auth-site
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Build React App
FROM node:18 AS build-react
WORKDIR /app
COPY main-site/ .
RUN npm install
RUN npm run build

# Stage 3: Final runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
# Install nginx
RUN apt-get update 
RUN apt-get install -y nginx 
RUN rm -rf /var/lib/apt/lists/*

COPY nginx/nginx.conf /etc/nginx/nginx.conf

# Copy built .NET app
COPY --from=build-api /app/publish /app

# Copy React static files
COPY --from=build-react /app/build /usr/share/nginx/html/main-site

# Copy entrypoint script
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

EXPOSE 8080
ENTRYPOINT ["/entrypoint.sh"]
