🚀 **Clean Architecture Boilerplate for .NET**

A professional boilerplate project built with .NET using Clean Architecture principles.
This template is designed to be a solid foundation every time you start a new backend project.

The goal is to save time, ensure structure, and provide a clean architectural baseline similar to how real production teams build backend systems.

You can fork, clone, and start building features immediately.

🎯 **Purpose of This Boilerplate**

Starting a backend project from scratch often leads to mixing concerns, unclear structure, and messy code.
This boilerplate provides:

* A clean, production-like Clean Architecture structure

* Strong separation of concerns

* A Generic Repository Pattern

* Zero database setup — runs instantly

* A scalable foundation for future real-world projects

* A personal development tool you can reuse in all .NET backend projects

This is your own starter toolkit for professional backend development.

🧩 **Project Structure**
```
Solution Root
 ├── Api              → Web API (Controllers, Dependency Injection)
 ├── Application      → Use Cases, DTOs, Commands, Queries
 ├── Domain           → Entities, Interfaces, Domain Logic
 └── Infrastructure   → Repository Implementations (in-memory)
```

🧱 Layer Overview (Clean Architecture)
**Domain**

The core of the system.
No external dependencies.

Contains:

* Entities (e.g., TodoItem)

*Domain logic

*Interfaces such as:

*IEntity

*IGenericRepository<T>

**Application**

Contains all application-specific logic, implemented as use cases.

Includes:

*DTOs

*Commands & Queries

*Use case handlers (e.g., CreateTodoHandler, GetAllTodosHandler)

*No direct data access — communicates only via Domain interfaces

**Infrastructure**

Implements all external concerns.

This boilerplate includes:

*A fake in-memory GenericRepository<T>

*No database required

*Easily replaceable with EF Core, SQL Server, PostgreSQL, SQLite, etc.

**API**

The outermost layer.
Only responsible for:

*Controllers

*Routing

*Dependency injection

*Accepting requests and returning responses

*No business logic inside controllers — all logic flows through Application → Domain → Infrastructure.

🔁 **Generic Repository Pattern**

This project implements a reusable and flexible repository system.

Defined in Domain (IGenericRepository<T>)

Implemented in Infrastructure (GenericRepository<T>)

Consumed in Application via dependency injection

Controllers never access data directly

This pattern allows you to:

✔️ Swap in a real database later
✔️ Keep API and business logic clean
✔️ Avoid duplication in data-access code
✔️ Maintain high testability

🚀 **Getting Started**

This project requires no database.
All data is stored in memory and resets when the API restarts.

1. Build the solution
dotnet build

2. Run the API
dotnet run --project Api


Swagger UI will be available at:

https://localhost:<port>/swagger


You can immediately test:

POST /api/Todo

GET /api/Todo

📄 Documentation Included

This project includes:

README.md – Overview, structure, and how to start

specs.md – Functional specifications and API endpoints

CHANGELOG.md – Version history

These documents make the project easy to understand for new developers, future you, or teammates.

🔮 Future Improv

