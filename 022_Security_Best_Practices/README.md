# ASP.NET Core MVC - Security Best Practices

This is a sample ASP.NET Core MVC project demonstrating how to protect against common web vulnerabilities such as Cross-Site Scripting (XSS) and Cross-Site Request Forgery (CSRF).

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Security Measures](#security-measures)
  - [Cross-Site Scripting (XSS)](#cross-site-scripting-xss)
  - [Cross-Site Request Forgery (CSRF)](#cross-site-request-forgery-csrf)
  - [HTTPS Enforcement](#https-enforcement)
- [Contributing](#contributing)
- [License](#license)

## Overview

This project aims to demonstrate how to implement security measures in an ASP.NET Core MVC application to protect against common web vulnerabilities like XSS and CSRF.

## Features

- Protection against XSS by using automatic encoding and `HtmlEncoder`.
- Protection against CSRF using anti-forgery tokens.
- HTTPS enforcement for secure data transmission.

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/oneananda/SecurityBestPractices.git
    cd SecurityBestPractices
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the project:
    ```bash
    dotnet run
    ```

## Usage

1. Navigate to `https://localhost:5001` in your web browser.
2. Test the XSS protection by viewing the content on the home page.
3. Test the CSRF protection by submitting the form on the Contact page.

## Security Measures

### Cross-Site Scripting (XSS)

ASP.NET Core provides built-in mechanisms to protect against XSS:

- **Automatic Encoding**: Razor views automatically HTML-encode any data output.
- **Explicit Encoding**: Use `HtmlEncoder` to encode any data that may contain malicious scripts.

```csharp
using Microsoft.AspNetCore.Mvc;

namespace SecurityDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var input = "<script>alert('XSS');</script>";
            ViewData["Input"] = input;
            return View();
        }
    }
}
```


### Implementing Content Security Policy (CSP)

Implementing Content Security Policy (CSP) headers in ASP.NET Core MVC is a good practice to enhance the security of your application by preventing cross-site scripting (XSS) attacks.

Modify the Startup.cs File:

You need to add CSP headers in the response. This can be done by adding middleware in the Configure method of the Startup class.

```
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("Content-Security-Policy",
                "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self' data:;");
            await next();
        });
```

In this example, the CSP header is set with a policy that allows resources only from the same origin ('self') and allows inline styles and scripts for demonstration purposes. 

### HTTPS Enforcement

Simply use `app.UseHttpsRedirection()`

HTTPS Redirection is a feature that ensures all HTTP requests are redirected to HTTPS. This helps enforce secure communication between the client and server by upgrading any non-secure requests to secure ones.

#### Configure HTTPS redirection with custom settings

How It Works

When app.UseHttpsRedirection() is called, it adds middleware that intercepts HTTP requests and issues a 301 (Moved Permanently) or 302 (Found) redirect to the equivalent HTTPS URL.

Configuration

You can configure the redirection behavior, including specifying the status code for the redirect and the HTTPS port to redirect to. Here’s an example of how to configure it:

```
 // Configure HTTPS redirection with custom settings
        app.UseHttpsRedirection(new HttpsRedirectionOptions
        {
            RedirectStatusCode = StatusCodes.Status308PermanentRedirect, // Use 308 status code for permanent redirection
            HttpsPort = 443 // Specify the HTTPS port to redirect to
        });
```
