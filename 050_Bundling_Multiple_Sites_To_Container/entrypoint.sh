#!/bin/sh

# Start ASP.NET app in background
dotnet /app/auth-site.dll &

# Start nginx in foreground
nginx -g 'daemon off;'
