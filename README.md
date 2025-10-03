# Minimal API - .NET Core 8

This project has learning purposes and provides a simple **Minimal API** built with **.NET Core 8** for managing `Person` entities.  
The API supports creating, retrieving, updating, and deleting people in the database.

---

## Endpoints

### 1. Create a Person
**POST** `/person`  
Creates a new person in the database.

**Request body:**
```json
{
  "name": "string"
}
```

**Response example:**
```json
{
  "id": "1101777e-5605-4bf4-9a33-0cf229b60790",
  "name": "John Doe"
}
```

---

### 2. Get All People

**GET** `/person`
Retrieves all registered people.

**Response example:**
```json
[
  {
    "id": "1101777e-5605-4bf4-9a33-0cf229b60790",
    "name": "Maria"
  }
]
```

---

### 3. Update a Person

**PUT** `/person/{id}`
Updates the name of a person based on their ID.

**Request body:**
```json
{
 "name": "Maria"
}
```

**Response example:**
```json
[
  {
    "id": "1101777e-5605-4bf4-9a33-0cf229b60790",
    "name": "Maria"
  }
]
```

---

### 4. Delete a Person
**DELETE** `/person/{id}`
Deletes a person from the database.

**Response example:**
```json
{
  "id": "1101777e-5605-4bf4-9a33-0cf229b60790",
  "name": "Maria"
}
```

---

## Requirements
To run this project, make sure you have installed:

- .NET 8 SDK
- Ridle, Visual Studio 2022 or Visual Studio Code (with the C# extension installed)
- A database provider (for example, SQL Server or SQLite, depending on your configuration)

---

## How to Run

1. Clone this repository
```bash
git clone https://github.com/your-username/minimal-api-dotnet8.git
cd minimal-api-dotnet8
```

2. Restore dependencias
```bash
dotnet restore
```

3. Apply database migrations (if using Entity Framework Core)
Migrations are not created or applied automatically when running the application.
You must execute the following commands:
```bash
dotnet ef migrations add InitialCreate   # Creates the first migration (only once)
dotnet ef database update                # Applies the migration(s) to the database
```

4. Run the application
```bash
dotnet run
```

5. Click on the link
Visual Studio launches a terminal window and displays the URL of the running application. The API is hosted at https://localhost:<port>, where <port> is a set of port numbers chosen randomly at project creation.

---

## Libraries and Tools Used

- .NET 8 Minimal API
- Entity Framework Core (for database access)
- Swagger / Swashbuckle (for API documentation, if enabled)
- Dependency Injection (native support in .NET)
