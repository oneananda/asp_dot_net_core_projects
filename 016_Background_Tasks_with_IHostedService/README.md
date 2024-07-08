# Running Background tasks using TimedHostedService

This project demonstrates how to implement and use `IHostedService` in an ASP.NET Core application. The example includes a background service that logs a message every 5 seconds.

## Overview

The `TimedHostedService` class implements the `IHostedService` interface and provides an example of running a timed background task. The service starts when the application starts and stops when the application is shutting down.

## Project Structure

- `Services/TimedHostedService.cs`: Contains the implementation of the timed hosted service.
- `Startup.cs`: Registers the hosted service.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) 3.1 or later

### Installation

1. Clone the repository:

```sh
git clone https://github.com/oneananda/asp_dot_net_core_projects.git
cd TimedHostedService
```