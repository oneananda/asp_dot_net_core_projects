# Custom Load Testing Tool for ASP.NET Core APIs (Under Dev)

**A lightweight, easy-to-use load testing tool for ASP.NET Core applications that provides in-depth performance metrics and highlights bottlenecks in your API.**

## Overview

Existing load testing tools like JMeter and k6, though powerful, are often too complex for small-to-medium-sized API projects, especially for ASP.NET Core developers who require targeted insights. This project aims to build a load testing tool tailored specifically for ASP.NET Core APIs, offering a streamlined approach to simulating high-traffic scenarios and providing detailed performance metrics such as response time, throughput, CPU/memory usage, and slow-performing database queries or middleware.

## Features

- **Simulate High-Traffic Scenarios**: Generate load on your API to test how it handles concurrent users and requests.
- **Detailed Performance Metrics**: Measure response times, request throughput, CPU/memory usage, and more.
- **Highlight Bottlenecks**: Identify slow-performing database queries, middleware, and endpoints that impact performance.
- **Easy Integration**: Integrate seamlessly with ASP.NET Core APIs and use Docker for containerized environments.
- **Lightweight and Configurable**: Focus on simplicity and provide flexibility for configuring test scenarios, request rates, and load duration.

## Technologies

- **ASP.NET Core**: The main target for the tool, ensuring compatibility and insights specific to ASP.NET Core APIs.
- **HTTPClient**: Used for making concurrent requests to simulate high traffic on your API.
- **k6**: A load testing library for generating high loads and analyzing API performance.
- **Docker**: For containerized deployment and ease of use in CI/CD environments.

## Table of Contents

1. [Getting Started](#getting-started)
2. [Installation](#installation)
3. [Configuration](#configuration)
4. [Usage](#usage)
5. [Example Scenarios](#example-scenarios)
6. [Performance Metrics](#performance-metrics)
7. [Contributing](#contributing)
8. [License](#license)

## Getting Started

Follow these instructions to get a copy of the tool up and running on your local machine or in your CI/CD pipeline.

### Prerequisites

- **.NET 6 SDK or higher**
- **Docker** (for containerized usage)
- **k6** (install from [https://k6.io/](https://k6.io/))

## Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/oneananda/asp_dot_net_core_projects.git
   cd asp_dot_net_core_projects

   Locate the project : 033_Custom_Load_Testing
