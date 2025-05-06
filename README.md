# NIA.OnlineApp

A .NET 8 Web API that demonstrates:

- Code First approach with Entity Framework Core
- Repository pattern for data access abstraction
- Centralized exception logging to a database table
- SQL Server integration
- Swagger UI support for API testing

## Features

- Create and retrieve `Entity` records via RESTful endpoints
- Logs unhandled exceptions in the `ErrorLogs` table
- Modular architecture with separation of concerns (Entities, Configurations, Repositories)

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core 9
- SQL Server Express (local)
- Swagger (Swashbuckle)
- Postman (for testing)
