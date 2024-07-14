# ASP.NET Core CQRS (Command Query Responsibility Segregation) 

This is an example of implementing Command Query Responsibility Segregation (CQRS) in an ASP.NET Core application.
   
## Overview

CQRS (Command Query Responsibility Segregation) is a pattern that separates read and write operations into different models, using commands to update data and queries to read data. This pattern helps to improve performance, scalability, and security by allowing the read and write workloads to scale independently.

This example demonstrates a simple CQRS implementation using ASP.NET Core, Entity Framework Core, and an in-memory database.

## Features

- Separation of read and write operations
- Simplified and maintainable architecture
- Command handlers for write operations
- Query handlers for read operations
- In-memory database for easy setup and testing
- RESTful API implementation

## Project Structure
```
CQRS
├── CQRS.Api
├── CQRS.Application
│ ├── Commands
│ └── Queries
├── CQRS.Domain
├── CQRS.Infrastructure
└── CQRS.Persistence
```
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

## Usage

Use tools like Postman to test the endpoints.

Create a Product
URL: POST /api/products

Body:

```
{
    "name": "Product1",
    "price": 100.0
}
```	

Get a Product by Id
URL: GET /api/products/{id}

Response:


```
{
    "id": "guid",
    "name": "Product1",
    "price": 100.0
}
```
