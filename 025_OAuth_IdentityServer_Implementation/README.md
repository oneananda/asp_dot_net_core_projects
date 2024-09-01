# ASP.NET Core Web API with OAuth and IdentityServer Implementation

This project demonstrates the implementation of OAuth 2.0 and OpenID Connect for authentication and authorization in an ASP.NET Core Web API using IdentityServer4. It includes user authentication, token management, and secured API access.

## Table of Contents
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Testing the API](#testing-the-api)
- [Project Structure](#project-structure)
- [Key Features](#key-features)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will guide you to set up the project on your local machine for development and testing purposes.

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other database supported by EF Core
- [Postman](https://www.postman.com/) or [Insomnia](https://insomnia.rest/) for testing the API endpoints

## Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/OAuth_IdentityServer_Implementation.git
    cd OAuth_IdentityServer_Implementation
    ```

2. **Restore the dependencies:**
    ```bash
    dotnet restore
    ```

3. **Set up the database:**
    - Update the connection string in `appsettings.json` under the `DefaultConnection`.
    - Apply the migrations to set up the database:
    ```bash
    dotnet ef database update
    ```

## Configuration

1. **IdentityServer Configuration:**
   - IdentityServer is configured in the `Startup.cs` file. You can define clients, API resources, and identity resources there.

2. **OAuth 2.0 / OpenID Connect Configuration:**
   - Scopes and claims are configured within IdentityServer in the `Config.cs` file.
   - Update client credentials and API scopes as per your application requirements.

## Running the Application

1. **Start the IdentityServer:**
    ```bash
    dotnet run --project IdentityServer
    ```
   
2. **Start the Web API:**
    ```bash
    dotnet run --project WebAPI
    ```

3. **Access the API:**
   - Use Postman or Insomnia to access API endpoints. 
   - Obtain an access token from the IdentityServer and include it in the `Authorization` header using the Bearer scheme.

## Testing the API

1. **Register a new client in IdentityServer.**
2. **Generate an access token:**
   - Use the `/connect/token` endpoint of the IdentityServer to obtain an access token.
3. **Access secured endpoints:**
   - Use the access token to call secured API endpoints by including it in the `Authorization: Bearer {token}` header.

## Key Features

- **OAuth 2.0 / OpenID Connect:** Secure authentication and authorization using IdentityServer.
- **Token Management:** Access and refresh tokens for API access.
- **Role-based Authorization:** Protect API endpoints based on user roles and scopes.
- **EF Core Integration:** Using Entity Framework Core for database access and management.

## Troubleshooting

- Ensure your database connection string is correctly configured in `appsettings.json`.
- Check IdentityServer logs for any errors related to client configuration or token issuance.
- Ensure migrations are correctly applied to the database before running the API.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss any changes.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.


