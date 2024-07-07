# RequestDelegate in ASP.NET Core

## Introduction
`RequestDelegate` is a delegate that represents a function that can process an HTTP request. It is a fundamental part of the middleware pipeline in ASP.NET Core and is used to define the sequence of operations that handle an HTTP request and produce a response.

## Process

### This will do the following process

- Process an Incoming Request: Each middleware component can inspect, modify, or process the incoming HTTP request, Except for "No-Op Middleware" which is just passing the command to next Middleware (does nothing other than this, and not recommended)
- Modify the Response (Optional): Middleware components can also modify the HTTP response before it is sent back to the client. This step is optional and depends on the middleware's purpose.
- Call the Next Middleware Component in the Pipeline: Middleware components usually call the next component in the pipeline to continue the request processing. This is done by invoking the RequestDelegate passed to the middleware.

## Key Uses of `RequestDelegate`

1. **Middleware Implementation**:
   - `RequestDelegate` is used in custom middleware components to define the logic for processing HTTP requests.
   - Middleware components receive a `RequestDelegate` parameter in their constructor, which represents the next middleware in the pipeline. This allows the current middleware to pass control to the next middleware.

2. **Request Processing**:
   - The `RequestDelegate` encapsulates the logic for processing an HTTP request, which includes reading the request, performing operations (such as authentication, logging, or modifying the request), and producing a response.

3. **Creating Custom Middleware**:
   - When creating custom middleware, `RequestDelegate` is used to invoke the next middleware in the pipeline. This ensures that the request is passed through the entire pipeline and all middleware components get a chance to process it.

## Output

### In Console

```
Handling request in CustomMiddleware
Finished handling request in AdditionalMiddleware
Finished handling request in CustomMiddleware
```

## Code Explaination

### CustomMiddleware Class:

- The CustomMiddleware class has a constructor that accepts a RequestDelegate parameter, which represents the next middleware in the pipeline.
The InvokeAsync method is where the request processing logic is implemented. Before calling _next(context), you can add logic to handle the request. After calling _next(context), you can add logic to handle the response.

### CustomMiddlewareExtensions Class:

- This class contains an extension method UseCustomMiddleware to add the custom middleware to the application builder.

### Startup Class:

- In the Configure method, app.UseCustomMiddleware() adds the custom middleware to the request pipeline.
app.Run(...) is a terminal middleware that processes the request and generates a response.
