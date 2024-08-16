# ASP.NET Core Projects

Welcome to the ASP.NET Core Projects repository! This repository contains a collection of projects ranging from basic to advanced concepts implemented in ASP.NET Core. Each project is designed to help you understand and master different aspects of ASP.NET Core.

## Table of Contents

1. [Getting Started](#getting-started)
2. [Project Structure](#project-structure)
3. [Projects](#projects)    
4. [Contributing](#contributing)
5. [License](#license)

## Getting Started

To get started with these projects, you'll need to have the following installed on your machine:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for projects using a database)

Clone this repository to your local machine using the following command:

```sh
git clone https://github.com/oneananda/asp_dot_net_core_projects.git
```

## Projects

---

### 001_Web_API_Hello_World
This project is a simple ASP.NET Core Web API that serves as an introductory "Hello World" example. It demonstrates the basic setup of an ASP.NET Core application, including creating a controller, defining routes, and returning a simple message. This project is perfect for beginners looking to understand the fundamentals of ASP.NET Core Web API development.

---

### 002_Dependency_Injection
This project illustrates the concept of Dependency Injection (DI) in ASP.NET Core. It shows how to inject dependencies into controllers and services, manage their lifetimes (transient, scoped, singleton), and configure DI in the Startup class. This is essential for building maintainable and testable applications.

---

### 003_Middleware_Request_Logging
This project focuses on middleware in ASP.NET Core, specifically on how to create custom middleware for logging HTTP requests and responses. It explains the middleware pipeline, how to create and register middleware, and best practices for logging.

---

### 004_Routing
This project delves into the routing system in ASP.NET Core. It covers attribute routing, conventional routing, route constraints, and custom route templates. Understanding routing is crucial for defining how HTTP requests are handled by your application.

---

### 005_Global_Exception_Handler
This project demonstrates how to implement global exception handling in ASP.NET Core. It includes creating a custom middleware to catch and handle exceptions, returning user-friendly error messages, and logging errors. This helps in creating robust and user-friendly applications.

---

### 006_Multiple_Configuration_Handling
This project shows how to handle multiple configuration sources in ASP.NET Core. It covers configuration providers, reading from JSON, XML, and environment variables, and injecting configurations into services. This is vital for applications that need flexible and dynamic configurations.

---

### 007_Options_Pattern_Configuration
This project explains the Options Pattern in ASP.NET Core for configuration management. It includes defining configuration classes, binding them to configuration sections, and injecting options into services. This pattern promotes strongly-typed configurations and validation.

---

### 008_Options_Pattern_Complex_Type_Configuration
This project extends the Options Pattern to handle complex types in configuration. It covers hierarchical configurations, nested options classes, and validation of complex configurations. This is useful for applications with intricate configuration needs.

---

### 009_API_Versioning_Strategies
This project covers API versioning strategies in ASP.NET Core. It includes versioning via URL, query string, and HTTP headers. Additionally, it demonstrates how to configure and use the Microsoft.AspNetCore.Mvc.Versioning package to manage API versions effectively.

---

### 010_Action_Paramters_Source_Data
This project focuses on action parameters in ASP.NET Core. It explains the various sources of action parameters, including route data, query strings, and request bodies. It also covers model binding and validation, helping developers handle input data efficiently.

---

### 011_FromServices_Attribute_Multi_Services
This project showcases the use of the `[FromServices]` attribute to inject services directly into action methods in ASP.NET Core. It demonstrates scenarios where this approach is beneficial and how to manage multiple services within action methods.

---

### 012_DI_Dependency_Injection
This project revisits Dependency Injection in ASP.NET Core, providing advanced examples and best practices. It covers custom service lifetimes, service provider validation, and advanced DI scenarios, enhancing the understanding of DI in complex applications.

---

### 013_HATEOAS_Implementation
This project demonstrates the implementation of HATEOAS (Hypermedia as the Engine of Application State) in ASP.NET Core. It includes creating hypermedia-driven APIs, adding links to resources, and building clients that navigate through hypermedia links, promoting RESTful API principles.

---

### 014_RequestDelegate_Implementation
This project explains the concept of `RequestDelegate` in ASP.NET Core. It includes creating and chaining multiple middleware components, handling requests and responses, and using `RequestDelegate` to build flexible and modular middleware pipelines.

---

### 015_Policy_based_Authorization
This project covers policy-based authorization in ASP.NET Core. It explains how to define authorization policies, apply them to controllers and actions, and implement custom authorization handlers. This approach provides fine-grained control over access to application resources.

---

### 016_Background_Tasks_with_IHostedService
This project demonstrates how to run background tasks in ASP.NET Core using `IHostedService`. It includes creating long-running services, scheduling tasks, and managing background processing. This is essential for applications that require background operations.

---

### 017_JWT_Based_Auth_Swagger
This project integrates JWT-based authentication with Swagger in ASP.NET Core. It covers generating and validating JWT tokens, securing APIs, and configuring Swagger to support authenticated endpoints. This is crucial for securing and documenting APIs effectively.

---

### 018_CQRS_Command_Query_Responsibility_Segregation
This project introduces the CQRS (Command Query Responsibility Segregation) pattern in ASP.NET Core. It covers separating read and write operations, implementing commands and queries, and using MediatR for mediator pattern integration. This enhances the scalability and maintainability of applications.

---

### 019_gRPC_Service_Implementation
This project demonstrates the implementation of gRPC services in ASP.NET Core. It includes defining proto files, generating server and client code, and handling gRPC calls. gRPC is a high-performance RPC framework suitable for microservices communication.

---

### 020_Caching_Strategies
This project explores caching strategies in ASP.NET Core. It covers in-memory caching, distributed caching, and response caching. It also provides best practices for implementing caching to improve application performance and scalability.

---

### 021_SignalR_Implementation
This project showcases the implementation of SignalR in ASP.NET Core for real-time web functionality. It includes setting up SignalR hubs, handling client-server communication, and broadcasting messages to multiple clients. SignalR is ideal for applications requiring real-time updates.

---

### 022_Security_Best_Practices
In today's digital landscape, safeguarding web applications is crucial. This section outlines essential security practices, including preventing Cross-Site Scripting (XSS), implementing Content Security Policy (CSP), enforcing HTTPS for secure communication, and configuring HTTPS redirection with custom settings. These measures collectively enhance the security posture of your application, protecting it from common vulnerabilities and ensuring the integrity and confidentiality of user data.

---

### 023_MediatR_Mediator_Pattern
This is a simple ASP.NET Core Web API application demonstrating the use of MediatR to implement the mediator pattern. MediatR helps in decoupling the sending and handling of requests in the application, leading to cleaner and more maintainable code.

---

### 024_Rate_Limiting
This project demonstrates a basic implementation of rate limiting in an ASP.NET Core application using custom middleware. The middleware helps to prevent abuse and manage traffic by limiting the number of requests that can be made from a single IP address within a specified time window.

---

### 024B_Rate_Limiting_Test
This project demonstrates how to test the rate limiting middleware implemented in an ASP.NET Core application using a C# console application. The goal is to verify that the rate limiting middleware correctly enforces request limits and handles traffic as expected.
---