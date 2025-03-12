# AddScoped DeepDive

We will see the how AddScoped works internally

## What Exactly Happens in the example (Step-by-Step)?

When you make an HTTP GET request to `TrackerController`:

1. **ASP.NET Core creates a single scope** for this incoming request.
2. **First resolution**: Controller constructor requests an `IRequestTracker`.  
   - Since none exists yet for this request, a new instance is created.
   - Let's say the generated ID is `12345`.
3. **Second resolution**: Controller constructor also requests `IServiceA` and `IServiceB`.  
   - Both services depend on `IRequestTracker`.
   - Since the scoped lifetime dictates only **one instance per request**, the already-created instance (`12345`) is injected into both `ServiceA` and `ServiceB`.
4. When you invoke the `Get()` action, it prints:
   ```
   TrackerController: 12345
   ServiceA: 12345
   ServiceB: 12345
   ```

This confirms the same instance is shared throughout the scope of the request.

---