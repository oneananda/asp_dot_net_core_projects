# ASP.NET Core MediatR Implementation

This is a simple ASP.NET Core Web API application demonstrating the use of MediatR to implement the mediator pattern. MediatR helps in decoupling the sending and handling of requests in the application, leading to cleaner and more maintainable code.

## Features

- Implementation of the mediator pattern using MediatR
- Decoupled request and handler logic
- Example of querying a list of products

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### Clone the repository

```bash
git clone https://github.com/yourusername/MediatRExample.git
cd MediatRExample
```

### Project Structure

Models/: Contains the Product model.

Requests/: Contains the MediatR request class for querying products.

Handlers/: Contains the MediatR handler class for handling the product query.

Controllers/: Contains the ASP.NET Core controller for handling HTTP requests.

Startup.cs: Configures the services and the request pipeline for the application.

#### Summary

In this example, we:

Created an ASP.NET Core Web API project.

Defined a request and handler using MediatR.

Registered MediatR in the Startup class.

Used MediatR in a controller to handle requests.
