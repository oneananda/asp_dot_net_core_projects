# ASP.NET Core Web API with Advanced Versioning Strategies

This project demonstrates multiple advanced API versioning strategies in ASP.NET Core. It includes examples of URL Path Versioning, Query String Versioning, Header Versioning, Media Type Versioning, and the use of the `Microsoft.AspNetCore.Mvc.Versioning` library for structured version management.

## Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Versioning Strategies](#api-versioning-strategies)
  - [URL Path Versioning](#url-path-versioning)
  - [Query String Versioning](#query-string-versioning)
  - [Header Versioning](#header-versioning)
  - [Media Type Versioning](#media-type-versioning)
  - [ASP.NET Core API Versioning Library](#aspnet-core-api-versioning-library)
  - [Combining Multiple Versioning Strategies](#combining-multiple-versioning-strategies)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This project showcases how to implement different API versioning strategies in an ASP.NET Core Web API. Proper API versioning is crucial for maintaining backward compatibility while evolving your API.

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any other code editor of your choice

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/oneananda/asp_dot_net_core_projects.git
    cd aspnet-core-api-versioning
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```   
## Running the Application

Run the application using the following command:

```bash
dotnet run
```

## URL Path Versioning

Access the API:

Version 1: GET /api/v1/products

Version 2: GET /api/v2/products

## Query String Versioning

Access the API:

Version 1: GET /api/products?apiVersion=1.0

Version 2: GET /api/products?apiVersion=2.0

## Header Versioning

Passing the Header Value

To pass the api-version header in your HTTP request, you need to include the header in the request.

Examples

**Using CURL**

```
curl -H "api-version: 1.0" https://your-api-url/api/customers
```

**Using Postman**

Open Postman.

Create a new GET request.

Enter the URL (e.g., https://your-api-url/api/customers).

Go to the "Headers" tab.

Add a new header with the name api-version and value 1.0.

Send the request.


**Using C# HttpClient**

```

using System.Net.Http;
using System.Threading.Tasks;

public async Task<string> GetCustomerVersionAsync()
{
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("api-version", "1.0");
        var response = await client.GetAsync("https://your-api-url/api/customers");
        return await response.Content.ReadAsStringAsync();
    }
}

```
