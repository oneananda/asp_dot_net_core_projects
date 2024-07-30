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



