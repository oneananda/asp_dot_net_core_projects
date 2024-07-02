# ASP.NET Core FromServices attribute Example

This project demonstrates how to use the `[FromServices]` attribute in an ASP.NET Core application to inject services directly into controller action method parameters.

## Table of Contents

- [Introduction](#introduction)
- [Services Definition](#services-definition)
- [Setup](#setup)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Explanation of Example](#explanation-of-example)
- [When to Use](#when-to-use)
- [Recommendations](#recommendations)

## Introduction

The `[FromServices]` attribute allows you to inject services from the dependency injection (DI) container directly into action method parameters in ASP.NET Core. This is useful for injecting services that are only needed for specific actions, thus keeping your controllers clean and maintainable.

## Services Definition

We have two services, `IServiceA` and `IServiceB`, each with a method to return some data.

### IServiceA

```
public interface IServiceA
{
    string GetDataA();
}

public class ServiceA : IServiceA
{
    public string GetDataA()
    {
        return "Data from Service A";
    }
}
```

### IServiceB
```
public interface IServiceB
{
    string GetDataB();
}

public class ServiceB : IServiceB
{
    public string GetDataB()
    {
        return "Data from Service B";
    }
}
```

### Endpoints

__The project exposes two endpoints:

***Get Data from Service A***

```
URL: /Products/dataA
Method: GET
Response: Data from Service A
```

***Get Data from Service B***

```
URL: /Products/dataB
Method: GET
Response: Data from Service B
```

### Explanation of Example

Services Definitions: 

We define two services, IServiceA and IServiceB, each with a method to return some data.

Register Services in Startup:

In the ConfigureServices method, we register the services with the DI container.

Controller Using [FromServices]: 

In the ExampleController, we have two action methods:

GetDataA: Uses [FromServices] to inject IServiceA.

GetDataB: Uses [FromServices] to inject IServiceB.

### When to Use

When to Use [FromServices]

Specific Action Method: 

When a service is needed only for a specific action method and not for the entire controller.

Reduce Constructor Parameters: 

To avoid having a large number of constructor parameters in the controller.

### Recommendations

Selective Injection: 

Inject services only where needed, promoting cleaner and more maintainable code.

Action-Level Dependencies: 

Useful for action-specific dependencies that are not required at the controller level.