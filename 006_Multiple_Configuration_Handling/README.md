# ASP.NET Core Multiple Configuration Handling

This project demonstrates how to handle multiple configurations in an ASP.NET Core application.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Setup](#setup)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/oneananda/asp_dot_net_core_projects.git    
    ```

2. Open the project in Visual Studio or Visual Studio Code.

3. Restore the NuGet packages:
    ```bash
    dotnet restore
    ```

## Configuration

This project uses various configuration sources, including JSON files, environment variables, and command-line arguments. The configurations are set up in the `Program.cs` file:

