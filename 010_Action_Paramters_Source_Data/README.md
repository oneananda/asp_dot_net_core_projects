# ASP.NET Core Action Paramters Source Data

This project demonstrates the use of various parameter binding attributes in ASP.NET Core MVC. The attributes covered are:
- `FromQuery`
- `FromBody`
- `FromForm`
- `FromHeader`
- `FromKeyedServices`
- `FromRoute`
- `FromServices`

## Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- ASP.NET Core 8.0 or later for `FromKeyedServices`

## Setup

1. Clone the repository:
    ```sh
    git clone https://github.com/oneananda/asp_dot_net_core_projects.git
    cd asp_dot_net_core_projects
    ```

2. Restore the dependencies and run the application:
    ```sh
    dotnet restore
    dotnet run
    ```

3. The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## Usage

### `FromQuery`

Endpoint: `/products`

**Description**: Binds a parameter to data in the query string.

**Example**: 
```http
GET /products?category=electronics&page=2
```

### `FromBody`

Endpoint: /products

```
POST /products
Content-Type: application/json

{
    "Name": "New Product",
    "Price": 29.99
}
```

### `FromForm`

POST /upload
Content-Type: multipart/form-data

file: (binary file data)
description: "File description"
