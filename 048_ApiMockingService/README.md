# 🧪 API Mocking Service

A lightweight and extensible **ASP.NET Core Web API** that allows developers to create and manage mock HTTP endpoints for frontend/backend testing.

---

## 📦 Features

- Create mock endpoints with custom routes, methods, status codes, and response bodies
- Simulate delays for network latency
- Store and manage mocks using a built-in SQLite database
- Automatically match incoming requests and return mocked responses
- RESTful API to create, retrieve, and delete mocks
- Middleware-based mock routing
- Swagger UI for testing and documentation

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 7 SDK or later](https://dotnet.microsoft.com/en-us/download)
- SQLite (optional – used by EF Core, installed automatically)

---

### 📥 Installation

1. **Clone the repository**

```bash
git clone https://github.com/yourusername/api-mocking-service.git
cd api-mocking-service
````

2. **Restore dependencies**

```bash
dotnet restore
```

3. **Apply database migrations**

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. **Run the application**

```bash
dotnet run
```

---

## 📘 API Usage

### 🔹 Create a Mock

`POST /api/mocks`

```json
{
  "method": "GET",
  "path": "/api/test",
  "statusCode": 200,
  "responseBody": "{ \"message\": \"Hello from mock\" }",
  "contentType": "application/json",
  "delayMs": 100
}
```

### 🔹 Get All Mocks

`GET /api/mocks`

### 🔹 Get Mock by ID

`GET /api/mocks/{id}`

### 🔹 Delete a Mock

`DELETE /api/mocks/{id}`

---

## 🧪 Using a Mock Endpoint

Once created, simply make a request to the specified path (e.g., `GET /api/test`), and the mocked response will be returned.

---

## 🧱 Project Structure

```
/ApiMockingService
│
├── Controllers/          # REST API for managing mocks
├── Middleware/           # Dynamic mock routing logic
├── Models/               # Data model for mock endpoints
├── Data/                 # EF Core context
├── Program.cs            # App startup
└── README.md             # You're here!
```

---

## 🔐 Roadmap & Features

* [ ] JWT Authentication for mock management
* [ ] UI dashboard for mock editing
* [ ] Import/Export mock definitions
* [ ] Request logging and analytics
* [ ] Project-based mock grouping
* [ ] Rate limiting per mock

---

## 🤝 Contributing

PRs are welcome! For major changes, open an issue first to discuss your ideas.

---


