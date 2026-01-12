# Project Name

A Clean Architecture-based project using **CQRS**, **MediatR**, **Generic Repository**, and **Unit of Work** patterns.  
This architecture ensures maintainability, scalability, and clean separation of concerns.

---



## Architecture Overview

This project is designed with **Clean Architecture principles**, with a slight adjustment:

- **API Layer**: Handles HTTP requests. Controllers interact with MediatR commands/queries.  
- **Services Layer**: Contains business logic, CQRS commands and queries, MediatR handlers.  
- **Domain Layer**: Contains entities and domain models.  
- **Infrastructure Layer**: Handles database access, Generic Repositories, Unit of Work, and EF Core DbContext.  

> **Note:** The `Services` layer here replaces the traditional "Application" layer.

---

### Key Features

1. **CQRS (Command Query Responsibility Segregation)**  
   - Commands for data-changing operations (`CreateDeviceCommand`)  
   - Queries for data retrieval (`GetDeviceByIdQuery`)  

2. **MediatR**  
   - Mediates between controllers and handlers.  
   - Supports decoupled, clean, and testable code.  

3. **Generic Repository**  
   - `RepositoryEntityBase<TId, T>` handles basic CRUD without duplicating code.  
   - Works with any entity type.  

4. **Unit of Work**  
   - `UnitOfWork` manages multiple repositories and ensures a **single transaction** per operation.  
   - `Commit()` method saves all changes at once.  

5. **Asynchronous Operations**  
   - All repository and database operations are async for performance.  

---

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- SQL Server instance (local or cloud)
- Visual Studio / VS Code

### Installation

1. Clone the repository:

```bash
git clone https://github.com/yourusername/projectname.git
cd projectname
