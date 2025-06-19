# Stage 1: ASP.NET Web API build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-api
WORKDIR /src
COPY auth-site/ ./auth-site/
WORKDIR /src/auth-site
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Stage 2: React app build
FROM node:18 AS build-react
WORKDIR /app
COPY main-site/ .
RUN npm install
RUN npm run build

# Stage 3: Final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0
RUN apt-get update && apt-get install -y nginx && rm -rf /var/lib/apt/lists/*
COPY nginx/nginx.conf /etc/nginx/nginx.conf

# Copy API
COPY --from=build-api /app/publish /app

# Copy React static build
COPY --from=build-react /app/dist /usr/share/nginx/html/main-site

# Entrypoint
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

EXPOSE 8080
ENTRYPOINT ["/entrypoint.sh"]
