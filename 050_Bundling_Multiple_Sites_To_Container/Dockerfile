# Stage 1: Build ASP.NET Web API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-api
WORKDIR /src
COPY auth-site/ ./auth-site/
WORKDIR /src/auth-site
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Build React frontend
FROM node:18 AS build-react
WORKDIR /app
COPY main-site/ .
RUN npm install
RUN npm run build

# Stage 3: Final runtime image with Nginx and API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Install Nginx
RUN apt-get update && \
    apt-get install -y nginx && \
    rm -rf /var/lib/apt/lists/*

# Copy Nginx configuration
COPY nginx/nginx.conf /etc/nginx/nginx.conf

# Copy API output from publish step
COPY --from=build-api /app/publish /app

# Copy React build output
COPY --from=build-react /app/dist /usr/share/nginx/html/main-site

# Copy entrypoint
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Expose HTTP port
EXPOSE 8080

# Start script
ENTRYPOINT ["/entrypoint.sh"]
