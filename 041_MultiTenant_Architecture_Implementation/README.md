
# ASP.NET Core MVC with EF Database-First Multi-Tenant Architecture

This project demonstrates how to implement **multi-tenancy** using **Entity Framework (EF) Database-First** in an ASP.NET Core MVC application. It supports three multi-tenant models:

1. **Database-per-tenant**
2. **Schema-per-tenant**
3. **Shared schema** (TenantId-based filtering)

## 🏗️ Project Structure

```
/MultiTenantApp
│
├── /Controllers
├── /Models
│   └── Database Models (generated via EF DB-First)
├── /Data
│   └── Tenant-aware DbContext classes
├── /Views
├── appsettings.json
└── Startup.cs / Program.cs
```

---

## 🔁 Multi-Tenant Approaches

### 1. Database-per-Tenant

Each tenant has a **separate database** with identical schema.

**Implementation:**

- Resolve the tenant (via subdomain, header, or query).
- Dynamically configure the connection string.
- Use a factory pattern to create a DbContext with the tenant’s connection string.

```
public class TenantDbContextFactory
{
    public ApplicationDbContext CreateDbContext(string connectionString)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString)
            .Options;
        return new ApplicationDbContext(options);
    }
}
```

### 2. Schema-per-Tenant

All tenants share one database, but each tenant has its **own schema**.

**Implementation:**

- Use a schema-aware DbContext.
- At runtime, set the default schema based on the tenant.

```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.HasDefaultSchema(_tenantSchema);
    base.OnModelCreating(modelBuilder);
}
```

> Note: EF DB-First scaffolding supports schema mapping via `-Schemas` in the command line.

### 3. Shared Schema (TenantId-based)

All tenants share the **same database and schema**, and each table includes a **TenantId** column.

**Implementation:**

- Add a `TenantId` filter globally using EF Core query filters.

```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Customer>().HasQueryFilter(c => c.TenantId == _currentTenantId);
}
```

> Useful for SaaS applications where data isolation is logical rather than physical.

---
