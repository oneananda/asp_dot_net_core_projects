# ASP.NET Core Web API Rate Limiting Middleware Testing

## Overview

This project demonstrates how to test the rate limiting middleware implemented in an ASP.NET Core application using a C# console application. The goal is to verify that the rate limiting middleware correctly enforces request limits and handles traffic as expected.

## Prerequisites

- **.NET 6 or later**
- **ASP.NET Core Web API** with rate limiting middleware
- **C# Console Application** for sending HTTP requests

## Setup

### 1. Prepare the ASP.NET Core Application

1. **Create and Configure the ASP.NET Core Web API Project:**
   - Ensure that the ASP.NET Core application has the rate limiting middleware integrated.
   - Include a simple API endpoint for testing.

2. **Run the ASP.NET Core Application:**
   - Start the web server by running the ASP.NET Core application. Make a note of the application's URL (e.g., `http://localhost:5000`).

### 2. Prepare the C# Console Application

1. **Create a C# Console Application:**
   - This application will be used to send multiple HTTP requests to the ASP.NET Core application.

2. **Add HTTP Client Code:**
   - Implement logic to send a series of HTTP requests to the test endpoint of the ASP.NET Core application.
   - Handle responses to observe the rate limiting behavior.

## Testing

1. **Run the ASP.NET Core Application:**
   - Ensure the ASP.NET Core application is running and accessible.

2. **Run the Console Application:**
   - Execute the C# console application to send multiple requests.
   - Monitor the responses to verify that rate limiting is applied correctly:
     - Requests should succeed up to the defined limit.
     - Once the limit is exceeded, subsequent requests should receive a `429 Too Many Requests` response.

3. **Verify Results:**
   - Check the ASP.NET Core application logs or console output for rate limiting activity.
   - Observe the console application's output to ensure that it correctly identifies rate limit responses and behaves as expected.

## Customization

- **Adjust Test Parameters:** Modify the number of requests or request intervals in the console application to test different scenarios.
- **Configure Rate Limiting:** Update the rate limiting settings in the ASP.NET Core application to match your testing requirements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with any changes or improvements. For more details, refer to the [CONTRIBUTING](CONTRIBUTING.md) guidelines.
