# SmartClinic - Appointment Scheduling API

This project demonstrates an ASP.NET Core Web API for a fictional SmartClinic platform. It covers the essentials for managing doctors, patients, and appointments while securing access with JSON Web Tokens (JWT).

## Features

- Doctor management (CRUD) with administrator-only write access.
- Patient management (CRUD) with role-based permissions.
- Appointment scheduling module with conflict detection, cancellation, and status updates.
- JWT-based authentication with seeded demo accounts for an administrator, doctor, and patient.
- Swagger/OpenAPI documentation configured to accept bearer tokens.

## Getting Started

1. Restore dependencies and run the API:

   ```bash
   dotnet restore
   dotnet run --project 052_SmartClinic_Appointment_Scheduling/SmartClinic.csproj
   ```

2. Open Swagger UI at `http://localhost:5050/swagger` (Development profile).

3. Authenticate via `POST /api/auth/login` using one of the seeded accounts:

   | Role           | Username    | Password    |
   |----------------|-------------|-------------|
   | Administrator  | `admin`     | `Admin@123` |
   | Doctor         | `dr.carson` | `Doctor@123`|
   | Patient        | `marcus.lee`| `Patient@123`|

4. Copy the returned bearer token and use it to authorize requests to protected endpoints.

## Project Structure

- `Controllers/` – API endpoints for authentication, doctors, patients, and appointments.
- `Models/` – Domain models representing clinic entities.
- `DTOs/` – Request and response contracts used by the API.
- `Repositories/` – In-memory data store implementation.
- `Services/` – Business logic, validation, and JWT generation helpers.
- `Configurations/` – Strongly typed configuration settings for JWT.

## Notes

- Data is stored in memory for demonstration purposes; replace `InMemoryClinicRepository` with a persistent store for production scenarios.
- Update the `Jwt:Key` value in `appsettings.json` before deploying.

