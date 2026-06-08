#!/bin/bash
# Startup script — runs inside the container.
# Starts UserMgmt.Api and ProdMgmt.Api as background processes,
# then starts Company.BFF in the foreground so Docker tracks its lifecycle.

set -e

echo "[start.sh] Starting UserMgmt.Api on port 8081..."
ASPNETCORE_URLS="http://+:8081" \
ASPNETCORE_ENVIRONMENT="Production" \
dotnet /app/usermgmt/UserMgmt.Api.dll &

echo "[start.sh] Starting ProdMgmt.Api on port 8082..."
ASPNETCORE_URLS="http://+:8082" \
ASPNETCORE_ENVIRONMENT="Production" \
dotnet /app/prodmgmt/ProdMgmt.Api.dll &

# Give internal services a moment to bind before BFF tries to proxy
echo "[start.sh] Waiting for internal services to start..."
sleep 3

echo "[start.sh] Starting Company.BFF on port 8080 (foreground)..."
ASPNETCORE_URLS="http://+:8080" \
ASPNETCORE_ENVIRONMENT="Production" \
exec dotnet /app/bff/Company.BFF.dll
