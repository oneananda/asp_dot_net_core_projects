# ASP.NET Core caching strategies

## Overview

This project demonstrates various caching strategies in an ASP.NET Core application, including response caching, in-memory caching, and distributed caching with Redis and SQL Server.

## Features

- **Response Caching**: Caches HTTP responses to improve performance.
- **In-Memory Caching**: Uses the memory of the application to store data.
- **Distributed Caching**: Utilizes Redis and SQL Server to store data across multiple instances.


### Response Caching:

Basic Response Caching
This project demonstrates the fundamentals of response caching in ASP.NET Core, showcasing how to cache responses to improve application performance and reduce server load.

Response Caching Query
This project illustrates how to implement response caching based on query string parameters in ASP.NET Core, ensuring that different query parameters result in different cached responses.

Response Caching Header
This project provides an example of using HTTP headers to control response caching in ASP.NET Core, showing how to leverage headers like Cache-Control and Pragma to manage cache behavior.

Conditional Response Caching
This project focuses on conditional response caching in ASP.NET Core, demonstrating how to cache responses based on conditions such as request headers or other custom logic.

### In-Memory Caching:

- **In-Memory Caching**: Caches data in memory with various caching policies.

In-memory caching in ASP.NET Core is a powerful technique to enhance the performance of your application by storing frequently accessed data in memory. By using the IMemoryCache interface, you can easily manage cache entries, define expiration policies, and reduce the load on your data sources. This approach is ideal for data that does not change frequently and needs to be accessed quickly.
