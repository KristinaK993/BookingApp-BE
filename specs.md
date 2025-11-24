# System Specifications – Clean Architecture Boilerplate (.NET)

This document describes the functional specifications, use cases, and API endpoints included in this boilerplate.

---

## ✅ Purpose of the System

This boilerplate provides a minimal but production-inspired backend architecture using Clean Architecture principles.  
It contains a simple Todo feature to demonstrate how entities, use cases, controllers, and repositories interact.

The system does NOT require a real database.  
All data is stored in an in-memory repository.

---

## 📌 Features

- Create a new Todo item
- Retrieve all Todo items
- Store data in an in-memory repository (no DB required)
- Clean Architecture separation between Domain, Application, Infrastructure, and API layers

---

## 🧩 Use Cases

### **1. CreateTodo**
**Handler:** `CreateTodoHandler`  
**Input:** `CreateTodoCommand`  
- `Title : string`

**Process:**
- Creates a new `TodoItem` entity
- Automatically assigns an ID
- Marks it as `IsCompleted = false`
- Stores it in the Generic Repository

**Output:**  
`TodoItemDto` containing:
- `Id`
- `Title`
- `IsCompleted`

---

### **2. GetAllTodos**
**Handler:** `GetAllTodosHandler`  
**Input:** `GetAllTodosQuery` (empty query)  
**Process:**
- Retrieves all Todo entities from the repository
- Converts each to DTOs

**Output:**  
List of `TodoItemDto`

---

## 🌐 API Endpoints

### **POST /api/Todo**
Create a new Todo item.

**Request Body:**
```json
{
  "title": "Example todo"
}
```

**Response Body (200 OK):**
```json
{
  "id": 1,
  "title": "Example todo",
  "isCompleted": false
}
```

---

### **GET /api/Todo**
Retrieve all Todo items.

**Example Response (200 OK):**
```json
[
  {
    "id": 1,
    "title": "Example todo",
    "isCompleted": false
  },
  {
    "id": 2,
    "title": "Another item",
    "isCompleted": false
  }
]
```

---

## ⚙️ Architectural Rules & Assumptions

- **API layer** must not access data directly  
  (only via Application use cases)
- **Application layer** uses Domain interfaces only
- **Infrastructure layer** implements repository logic
- No database configuration required
- Data resets on application restart
- Entities must implement `IEntity` (have an `Id`)

---

## 📌 Technologies Used

- .NET 8 (or current version)
- ASP.NET Core Web API
- Clean Architecture structure
- Generic Repository pattern (in-memory implementation)

---

## 🧪 Intended Usage

This boilerplate can be used to:

- Start new backend projects quickly  
- Learn or practice Clean Architecture  
- Extend with new features, databases, or services  
- Provide a clean, scalable foundation for future projects

---
