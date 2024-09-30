# ASP.NET Core Web API with JWT Authentication and Swagger

This project demonstrates how to implement JWT authentication in an ASP.NET Core Web API and how to test it using Swagger.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Testing with Swagger](#testing-with-swagger)
- [Contributing](#contributing)
- [License](#license)

## Overview

This project provides a template for creating a secure ASP.NET Core Web API with JWT authentication. It includes:
- Configuring JWT authentication.
- Protecting API endpoints.
- Generating and validating JWT tokens.
- Integrating Swagger for API documentation and testing.

## Features

- **JWT Authentication:** Secure your API endpoints using JSON Web Tokens (JWT).
- **Swagger Integration:** Easily test and document your API using Swagger UI.
- **Role-based Access Control:** Implement role-based access control to secure sensitive endpoints.

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/oneananda/asp_dot_net_core_projects.git
   ```

## Test Credentials

- Username: "Test"
- Password: "Test"

## Testing with Swagger

- Run the application.
- Open your browser and navigate to https://localhost:<port>/swagger.
- Use the /auth/token endpoint to generate a JWT token (with Bearer prefix).
- Click on the Authorize button in Swagger UI, enter Bearer {your_token}, and click Authorize.
- Now you can access the protected endpoints by including the JWT token in the request headers.