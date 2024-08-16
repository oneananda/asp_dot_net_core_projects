# ASP.NET Core Rate Limiting Middleware

## Overview

This project demonstrates a basic implementation of rate limiting in an ASP.NET Core application using custom middleware. The middleware helps to prevent abuse and manage traffic by limiting the number of requests that can be made from a single IP address within a specified time window.

## Features

- **Request Limiting:** Controls the number of requests per IP address to prevent excessive use.
- **Rate Limiting Response:** Responds with an appropriate error message when the rate limit is exceeded.
- **In-Memory Storage:** Uses in-memory caching for tracking request counts, suitable for simple or development scenarios.

## Requirements

- **.NET 6 or later**
- **ASP.NET Core**

## Setup Instructions

1. **Clone the Repository:**

   Clone the repository to your local machine using your preferred method (e.g., Git).

2. **Build and Run the Project:**

   Follow the standard procedure to build and run the ASP.NET Core application. This typically involves restoring dependencies and running the project using your IDE or command line.

## How It Works

### Middleware Functionality

The rate limiting middleware is designed to intercept HTTP requests and monitor the number of requests coming from each IP address. It uses an in-memory cache to keep track of request counts and enforces limits based on a defined maximum number of requests per minute.

### Configuration

- **Rate Limit Settings:** You can configure the maximum number of requests allowed per minute and the time window for rate limiting by modifying the middleware settings.
- **Response Handling:** When the request limit is exceeded, the middleware returns a `429 Too Many Requests` HTTP status code with an appropriate message to the client.

## Testing

To test the rate limiting functionality:

1. **Run the Application:** Start the application and make requests to the API.
2. **Observe Rate Limiting:** Make multiple requests from the same IP address within a short time period. Verify that requests exceeding the defined limit receive a `429 Too Many Requests` response.

## Customization

- **Adjust Limits:** Modify the settings to change the request limits and time window according to your application's requirements.
- **Extend Functionality:** Consider extending the middleware to implement user-based rate limiting or integrating with a distributed cache if needed.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

If you wish to contribute to this project, please fork the repository and submit a pull request. For further details, refer to the [CONTRIBUTING](CONTRIBUTING.md) guidelines.

