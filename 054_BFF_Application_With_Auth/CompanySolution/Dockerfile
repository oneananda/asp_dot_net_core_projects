# ─── Stage 1: Build ───────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution + project files first to exploit Docker layer caching.
# Re-running restore only when .csproj files change, not on every source edit.
COPY CompanySolution.sln ./
COPY src/Company.BFF/Company.BFF.csproj       src/Company.BFF/
COPY src/UserMgmt.Api/UserMgmt.Api.csproj     src/UserMgmt.Api/
COPY src/ProdMgmt.Api/ProdMgmt.Api.csproj     src/ProdMgmt.Api/

RUN dotnet restore

# Copy all remaining source files and publish each project
COPY . .

RUN dotnet publish src/Company.BFF/Company.BFF.csproj   \
      -c Release -o /publish/bff       --no-restore

RUN dotnet publish src/UserMgmt.Api/UserMgmt.Api.csproj \
      -c Release -o /publish/usermgmt  --no-restore

RUN dotnet publish src/ProdMgmt.Api/ProdMgmt.Api.csproj \
      -c Release -o /publish/prodmgmt  --no-restore


# ─── Stage 2: Runtime ─────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy all three published apps
COPY --from=build /publish/bff       ./bff/
COPY --from=build /publish/usermgmt  ./usermgmt/
COPY --from=build /publish/prodmgmt  ./prodmgmt/

# Copy the startup script and make it executable
COPY start.sh ./start.sh
RUN chmod +x ./start.sh

# ── Environment: tell YARP inside the container to use 127.0.0.1 ──────────────
# The __ separator maps to JSON hierarchy:
#   ReverseProxy → Clusters → userMgmtCluster → Destinations → destination1 → Address
ENV ReverseProxy__Clusters__userMgmtCluster__Destinations__destination1__Address=http://127.0.0.1:8081
ENV ReverseProxy__Clusters__prodMgmtCluster__Destinations__destination1__Address=http://127.0.0.1:8082

# Only the BFF port is exposed externally; internal ports (8081, 8082) stay private
EXPOSE 8080

ENTRYPOINT ["/bin/bash", "./start.sh"]
