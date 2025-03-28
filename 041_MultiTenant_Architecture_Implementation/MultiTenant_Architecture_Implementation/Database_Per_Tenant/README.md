# 🏢 ASP.NET Core MVC – Multi-Tenant (Database-per-Tenant) with EF Core (DB-First)

This project demonstrates how to implement **Database-per-Tenant** architecture in an **ASP.NET Core MVC** application using **Entity Framework Core (Database-First)**.

---

## 📘 What is Database-per-Tenant?

In this multi-tenant model, each tenant (organization, customer, etc.) gets their **own dedicated database**. All tenant databases share the **same schema**, ensuring data isolation and security.

---

## 📂 Folder Structure

```
/MultiTenantApp
│
├── Controllers/                  # MVC controllers
├── Data/                        # TenantDbContextFactory
├── Middleware/                  # Tenant resolution middleware
├── Models/                      # EF DB-First generated models
├── Services/                    # TenantProvider service
├── appsettings.json
└── Program.cs
```

---

## ⚙️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core (Database-First)
- SQL Server
- Middleware-based tenant resolution

---

## 🚧 Setup Instructions

### 1. Scaffold EF Core Models (Once)

Use a **template tenant database** to scaffold the context:

```
dotnet ef dbcontext scaffold "Server=.;Database=TenantTemplateDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer \
  --output-dir Models --context-dir Data --context ApplicationDbContext --use-database-names
```

> All tenant databases must have the **same schema**.

---

### 2. Configure `appsettings.json`

```
{
  "ConnectionStrings": {
    "TenantTemplate": "Server=.;Database={0};Trusted_Connection=True;"
  }
}
```

---

### 3. Register Services in `Program.cs`

```
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<TenantDbContextFactory>();
```

---

### 4. Add Tenant Resolution Middleware

```
app.UseMiddleware<TenantResolutionMiddleware>();
```

---

## 📦 Components Overview

### ✅ `TenantProvider.cs`

Stores the current tenant ID per request.

```
public interface ITenantProvider
{
    string TenantId { get; }
    void SetTenant(string tenantId);
}
```

### ✅ `TenantResolutionMiddleware.cs`

Reads `X-Tenant-ID` from request headers.

```
public async Task Invoke(HttpContext context, ITenantProvider tenantProvider)
{
    var tenantId = context.Request.Headers["X-Tenant-ID"].FirstOrDefault();
    tenantProvider.SetTenant(tenantId);
    await _next(context);
}
```

### ✅ `TenantDbContextFactory.cs`

Creates a new `ApplicationDbContext` using the tenant's connection string.

```
public ApplicationDbContext CreateDbContext()
{
    string conn = string.Format(_config["ConnectionStrings:TenantTemplate"], _tenantProvider.TenantId);
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlServer(conn)
        .Options;

    return new ApplicationDbContext(options);
}
```

### ✅ Sample Usage in `HomeController.cs`

```
public IActionResult Index()
{
    using var db = _dbFactory.CreateDbContext();
    var customers = db.Customers.ToList();
    return View(customers);
}
```

---

## 🧪 How to Test

1. Create multiple tenant databases (e.g., `Tenant1DB`, `Tenant2DB`) using the same schema.
2. Use Postman or browser with custom headers:

```
GET / HTTP/1.1
Host: localhost:5000
X-Tenant-ID: Tenant1DB
```

---

## ✅ Benefits of Database-per-Tenant

| Advantage                     | Description                                        |
|------------------------------|----------------------------------------------------|
| 🔐 Strong Isolation           | Each tenant’s data is completely separated         |
| 📦 Easy Backups               | You can backup/restore per tenant                  |
| 📊 Tenant-Specific Tuning     | Performance tuning, indexing per tenant           |

---

## 🚫 Considerations

- Managing many databases can become complex.
- Schema updates must be applied to all tenant databases.
- Requires good automation and migration strategies.

---

## 📚 Related Links

- [EF Core Database-First Docs](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/)
- [Multi-Tenant Architecture Patterns](https://learn.microsoft.com/en-us/azure/architecture/guide/multitenant/overview)

---

