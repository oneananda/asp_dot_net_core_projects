# ASP.NET Core Dependency Injection Example

This project demonstrates the use of Dependency Injection (DI) in an ASP.NET Core application. It includes examples of services with different lifetimes: Transient, Scoped, and Singleton.

## Overview

The project consists of:
- A simple ASP.NET Core MVC application
- Interfaces and implementations for different services
- Registration of services with various lifetimes
- Injection and usage of these services in a controller

## Services

### Interfaces and Implementations

This is done in the Controller level

- `IMyService` / `MyService`: A simple service that returns a message.
- `ITransientService` / `TransientService`: A service with a Transient lifetime.
- `IScopedService` / `ScopedService`: A service with a Scoped lifetime.
- `ISingletonService` / `SingletonService`: A service with a Singleton lifetime.

### Service Lifetimes

- **Transient**: Services are created each time they are requested. Best for lightweight, stateless services.
- **Scoped**: Services are created once per request. Ideal for services that maintain state across a single request.
- **Singleton**: Services are created once and shared throughout the application's lifetime. Suitable for stateless services and shared resources.

## Getting Started

### Prerequisites

- .NET SDK 6.0 or later

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/oneananda/asp_dot_net_core_projects.git
    cd asp_dot_net_core_projects
    ```

2. Build the project:
    ```sh
    dotnet build
    ```

3. Run the project:
    ```sh
    dotnet run
    ```

### Project Structure

012_DI_Dependency_Injection/
├── Controllers/
│ └── HomeController.cs
├── Interfaces/
│ ├── IMyService.cs
│ ├── ITransientService.cs
│ ├── IScopedService.cs
│ └── ISingletonService.cs
├── Startup.cs
├── Program.cs
└── 012_DI_Dependency_Injection.csproj


### Usage

After running the project, navigate to `http://localhost:5000` in your web browser. You will see a message from each of the services, demonstrating their lifetimes.
