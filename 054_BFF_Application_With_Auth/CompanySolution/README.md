# CompanySolution — Single-Container BFF Architecture

## Solution Overview

```
CompanySolution/
├── CompanySolution.sln
├── Dockerfile                    ← single Dockerfile for all 3 projects
├── start.sh                      ← container startup script
├── README.md
└── src/
    ├── Company.BFF/              ← public gateway (YARP reverse proxy)
    │   ├── Controllers/
    │   │   ├── BffController.cs       GET /
    │   │   └── DevAuthController.cs   GET /dev/token  (Development only)
    │   ├── Program.cs
    │   └── appsettings.json
    ├── UserMgmt.Api/             ← internal: user data
    │   ├── Controllers/
    │   │   └── UsersController.cs     GET /users
    │   └── Program.cs
    └── ProdMgmt.Api/             ← internal: product data
        ├── Controllers/
        │   └── ProductsController.cs  GET /products
        └── Program.cs
```

---

## Architecture Explained

### Path-based routing via YARP

`Company.BFF` uses [YARP (Yet Another Reverse Proxy)](https://microsoft.github.io/reverse-proxy/)
to forward incoming requests to the correct internal API:

| Public URL (BFF)                        | Forwarded to (internal)               |
|-----------------------------------------|---------------------------------------|
| `GET /`                                 | BFF's own controller — no proxy       |
| `GET /user-mgmt`                        | `UserMgmt.Api  → GET /users`          |
| `GET /prod-mgmt`                        | `ProdMgmt.Api  → GET /products`       |
| `GET /swagger`                          | BFF's own Swagger UI                  |

YARP applies a **PathSet transform** that rewrites the path before forwarding:

```json
"userMgmtRoute": {
  "Match": { "Path": "/user-mgmt" },
  "Transforms": [ { "PathSet": "/users" } ]
}
```

### How base URL works in every environment

The `Authorization` header and JWT secret are shared across all three services,
so a token obtained from `/dev/token` works when testing any service directly.

| Environment        | Public base URL                        | How it is set                    |
|--------------------|----------------------------------------|----------------------------------|
| Local (no Docker)  | `http://localhost:8080`                | `launchSettings.json`            |
| Local (Docker)     | `http://localhost:8080`                | `docker run -p 8080:8080`        |
| Azure Container Apps | `https://application.client.com`    | ACA Ingress + custom domain      |

The application itself never has a hardcoded domain name.
Path-based routing (`/user-mgmt`, `/prod-mgmt`) works identically at every level
because the paths are relative — they work with any hostname in front of them.

---

## Ports

| Service         | Local dev port | Inside Docker |
|-----------------|---------------|---------------|
| Company.BFF     | 8080          | 8080 (exposed)|
| UserMgmt.Api    | 8081          | 8081 (private)|
| ProdMgmt.Api    | 8082          | 8082 (private)|

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for Docker steps)
- Visual Studio 2022 or VS Code (optional)

---

## 1 — Run Locally (without Docker)

Open **three separate terminals** in the `CompanySolution/` directory.

**Terminal 1 — UserMgmt.Api:**
```bash
dotnet run --project src/UserMgmt.Api/UserMgmt.Api.csproj
# Listening on http://localhost:8081
```

**Terminal 2 — ProdMgmt.Api:**
```bash
dotnet run --project src/ProdMgmt.Api/ProdMgmt.Api.csproj
# Listening on http://localhost:8082
```

**Terminal 3 — Company.BFF:**
```bash
dotnet run --project src/Company.BFF/Company.BFF.csproj
# Listening on http://localhost:8080
```

> Start the internal APIs (terminals 1 & 2) **before** the BFF (terminal 3).
> The BFF does not crash if they're unavailable, but requests will fail until they're up.

### Test URLs (local)

```
GET http://localhost:8080              → { "message": "Company BFF is running" }
GET http://localhost:8080/user-mgmt   → proxied to UserMgmt.Api/users
GET http://localhost:8080/prod-mgmt   → proxied to ProdMgmt.Api/products
GET http://localhost:8080/swagger     → BFF Swagger UI
GET http://localhost:8081/swagger     → UserMgmt.Api Swagger UI (direct)
GET http://localhost:8082/swagger     → ProdMgmt.Api Swagger UI (direct)
```

---

## 2 — Run from Visual Studio

1. Open `CompanySolution.sln` in Visual Studio 2022.
2. Right-click the solution → **Set Startup Projects** → **Multiple startup projects**.
3. Set all three projects to **Start**.
4. Press **F5** — three browser tabs open at each Swagger UI.

Port assignments are defined in each project's `Properties/launchSettings.json`:
- BFF → 8080, UserMgmt.Api → 8081, ProdMgmt.Api → 8082

---

## 3 — Build and Run with Docker

All commands run from the `CompanySolution/` directory.

### Build the image
```bash
docker build -t company-single-container .
```

### Run the container
```bash
docker run -p 8080:8080 company-single-container
```

### Test URLs (Docker)

```
GET http://localhost:8080
GET http://localhost:8080/user-mgmt
GET http://localhost:8080/prod-mgmt
GET http://localhost:8080/swagger
```

> UserMgmt.Api (8081) and ProdMgmt.Api (8082) are **not** port-mapped to the host.
> They are private, only reachable by the BFF process inside the container.

---

## 4 — Swagger and JWT Authentication

### Step 1 — Get a development token

**In Development (local run):**

```
GET http://localhost:8080/dev/token
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5...",
  "expiresInHours": 8,
  "swaggerUsage": "Bearer eyJhbGciOiJIUzI1NiIsInR5..."
}
```

> `/dev/token` is unavailable in Production (`ASPNETCORE_ENVIRONMENT=Production`).
> It returns `404` inside Docker.

### Step 2 — Authorize in Swagger

1. Open `http://localhost:8080/swagger`.
2. Click **Authorize** (padlock icon).
3. Paste the full value from `swaggerUsage`: `Bearer eyJ...`
4. Click **Authorize**, then **Close**.
5. All endpoints now send the token automatically.

### JWT configuration

All three services share the **same** secret, issuer, and audience (in `appsettings.json`):

```json
"Jwt": {
  "Key":      "SuperSecretDevelopmentKeyForTestingOnly123!",
  "Issuer":   "CompanyApp",
  "Audience": "CompanyAppUsers"
}
```

Override in production via environment variables:
```
Jwt__Key=<your-production-secret>
Jwt__Issuer=CompanyApp
Jwt__Audience=CompanyAppUsers
```

---

## 5 — Debugging BFF + Internal APIs Together

### Visual Studio

Use **Multiple startup projects** (see Section 2). Breakpoints work in all three
projects simultaneously.

### VS Code

Create `.vscode/launch.json`:

```json
{
  "version": "0.2.0",
  "compounds": [
    {
      "name": "All APIs",
      "configurations": ["BFF", "UserMgmt", "ProdMgmt"]
    }
  ],
  "configurations": [
    {
      "name": "BFF",
      "type": "coreclr",
      "request": "launch",
      "program": "${workspaceFolder}/src/Company.BFF/bin/Debug/net8.0/Company.BFF.dll",
      "cwd": "${workspaceFolder}/src/Company.BFF",
      "env": { "ASPNETCORE_ENVIRONMENT": "Development", "ASPNETCORE_URLS": "http://localhost:8080" }
    },
    {
      "name": "UserMgmt",
      "type": "coreclr",
      "request": "launch",
      "program": "${workspaceFolder}/src/UserMgmt.Api/bin/Debug/net8.0/UserMgmt.Api.dll",
      "cwd": "${workspaceFolder}/src/UserMgmt.Api",
      "env": { "ASPNETCORE_ENVIRONMENT": "Development", "ASPNETCORE_URLS": "http://localhost:8081" }
    },
    {
      "name": "ProdMgmt",
      "type": "coreclr",
      "request": "launch",
      "program": "${workspaceFolder}/src/ProdMgmt.Api/bin/Debug/net8.0/ProdMgmt.Api.dll",
      "cwd": "${workspaceFolder}/src/ProdMgmt.Api",
      "env": { "ASPNETCORE_ENVIRONMENT": "Development", "ASPNETCORE_URLS": "http://localhost:8082" }
    }
  ]
}
```

Run **"All APIs"** compound to start and debug all three at once.

---

## 6 — Docker Build Details

The Dockerfile uses a **two-stage multi-project build**:

```
Stage 1 (sdk:8.0)
  ├── dotnet restore   (only csproj files — fast cache layer)
  ├── dotnet publish → /publish/bff
  ├── dotnet publish → /publish/usermgmt
  └── dotnet publish → /publish/prodmgmt

Stage 2 (aspnet:8.0)  ← smaller runtime image, no SDK
  ├── /app/bff/
  ├── /app/usermgmt/
  ├── /app/prodmgmt/
  └── start.sh
       ├── dotnet usermgmt/UserMgmt.Api.dll  (background, port 8081)
       ├── dotnet prodmgmt/ProdMgmt.Api.dll  (background, port 8082)
       └── exec dotnet bff/Company.BFF.dll   (foreground, port 8080)

EXPOSE 8080
```

### Make start.sh executable (Linux/Mac hosts)

```bash
chmod +x start.sh
```

On Windows hosts the file permission is set inside the Dockerfile via `RUN chmod +x ./start.sh`.

### Override YARP destinations at runtime

YARP cluster addresses can be overridden with environment variables at `docker run` time:

```bash
docker run -p 8080:8080 \
  -e "ReverseProxy__Clusters__userMgmtCluster__Destinations__destination1__Address=http://127.0.0.1:8081" \
  -e "ReverseProxy__Clusters__prodMgmtCluster__Destinations__destination1__Address=http://127.0.0.1:8082" \
  company-single-container
```

(These are already set as defaults in the Dockerfile `ENV` instructions.)

---

## 7 — Azure Container Apps Deployment

### Prerequisites
- Azure CLI installed and logged in (`az login`)
- An Azure Container Registry (ACR)
- An Azure Container Apps Environment

### Push image to ACR

```bash
az acr login --name <acr-name>

docker tag company-single-container <acr-name>.azurecr.io/company-single-container:latest
docker push <acr-name>.azurecr.io/company-single-container:latest
```

### Deploy to Azure Container Apps

```bash
az containerapp create \
  --name company-bff-app \
  --resource-group <resource-group> \
  --environment <container-app-env> \
  --image <acr-name>.azurecr.io/company-single-container:latest \
  --registry-server <acr-name>.azurecr.io \
  --target-port 8080 \
  --ingress external \
  --min-replicas 1 \
  --max-replicas 3 \
  --env-vars \
      "Jwt__Key=<production-secret>" \
      "Jwt__Issuer=CompanyApp" \
      "Jwt__Audience=CompanyAppUsers"
```

> `--target-port 8080` — ACA routes all external traffic to port 8080 only.
> Ports 8081 and 8082 are never reachable from outside the container.

### Bind a custom domain

```bash
az containerapp hostname add \
  --name company-bff-app \
  --resource-group <resource-group> \
  --hostname application.client.com
```

Once the DNS and certificate are configured:

```
https://application.client.com          → BFF root
https://application.client.com/user-mgmt → users
https://application.client.com/prod-mgmt → products
https://application.client.com/swagger   → Swagger UI
```

---

## 8 — Common Issues and Fixes

### `dotnet restore` fails — "Unable to find package Yarp.ReverseProxy"

Ensure you have internet access during build or a private NuGet feed configured.
Run `dotnet nuget locals all --clear` and retry.

### `GET /user-mgmt` returns `502 Bad Gateway`

The BFF can't reach UserMgmt.Api. Checklist:
1. Is UserMgmt.Api running? (`dotnet run --project src/UserMgmt.Api/...`)
2. Is it on port 8081? Check `Properties/launchSettings.json`.
3. Check `appsettings.json` → `ReverseProxy.Clusters.userMgmtCluster.Destinations.destination1.Address`.

### `401 Unauthorized` on `/user-mgmt` or `/prod-mgmt`

The downstream API rejected the JWT. Possible causes:
- No Authorization header sent. Add `Bearer {token}` via Swagger Authorize dialog.
- Token expired (tokens are valid for 8 hours). Get a fresh one from `GET /dev/token`.
- JWT key mismatch — verify all three `appsettings.json` files have the same `Jwt:Key`.

### `404` on `GET /dev/token`

`/dev/token` only works when `ASPNETCORE_ENVIRONMENT=Development`.
Inside Docker it returns 404 by design (the environment is set to `Production` in `start.sh`).
Run locally with `dotnet run` to use this endpoint.

### Docker container exits immediately

Check `docker logs <container-id>`. Common causes:
- `start.sh` line endings are CRLF (Windows). Convert to LF:
  ```bash
  dos2unix start.sh
  ```
  Or open in VS Code → click CRLF in status bar → change to LF → save.
- One of the internal APIs crashed. The BFF foreground process is the last to start;
  if it exits (or never starts), Docker stops the container.

### Port conflict when running locally

If port 8080, 8081, or 8082 is already in use:
```powershell
# Windows — find the process using port 8081
netstat -ano | findstr :8081
taskkill /PID <pid> /F
```

---

## 9 — Quick Reference

```bash
# Build
dotnet build

# Run individually
dotnet run --project src/UserMgmt.Api/UserMgmt.Api.csproj
dotnet run --project src/ProdMgmt.Api/ProdMgmt.Api.csproj
dotnet run --project src/Company.BFF/Company.BFF.csproj

# Docker
docker build -t company-single-container .
docker run -p 8080:8080 company-single-container

# Test
curl http://localhost:8080
curl http://localhost:8080/user-mgmt   -H "Authorization: Bearer <token>"
curl http://localhost:8080/prod-mgmt   -H "Authorization: Bearer <token>"
```
