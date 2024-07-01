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
