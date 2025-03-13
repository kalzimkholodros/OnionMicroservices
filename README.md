# N-Layer Architecture API

A robust N-Layer Architecture API built with .NET 8, implementing clean architecture principles, featuring product and category management with PostgreSQL integration.

## Technologies Used

- .NET 8
- PostgreSQL
- Entity Framework Core
- AutoMapper
- FluentValidation
- Swagger

## Architecture Layers

1. **Core Layer** (`NLayerApp.Core`)
   - Contains entities, interfaces, and DTOs
   - Defines the contract of the application

2. **Infrastructure Layer** (`NLayerApp.Infrastructure`)
   - Implements data access
   - Contains DbContext, repositories, and configurations
   - Handles database operations

3. **Application Layer** (`NLayerApp.Application`)
   - Contains business logic
   - Implements services
   - Handles validation and mapping

4. **API Layer** (`NLayerApp.API`)
   - Presents HTTP endpoints
   - Handles HTTP requests/responses
   - Contains controllers and middleware configurations

## Features

- Generic Repository Pattern
- Unit of Work Pattern
- DTO Pattern
- Fluent Validation
- Global Exception Handling
- Entity Configurations
- AutoMapper Implementation
- CRUD Operations
- PostgreSQL Integration
- Swagger Documentation

## Getting Started

### Prerequisites

- .NET 8 SDK
- PostgreSQL
- An IDE (Visual Studio, VS Code, etc.)

### Database Configuration

1. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "PostgreSQL": "Host=localhost;Port=5432;Database=NLayerDb;Username=postgres;Password=postgres"
  }
}
```

2. Apply migrations:
```bash
cd NLayerApp.Infrastructure
dotnet ef database update --startup-project ../NLayerApp.API
```

### Running the Application

1. Clone the repository
2. Navigate to the API project:
```bash
cd NLayerApp.API
```
3. Run the application:
```bash
dotnet run
```
4. Access Swagger UI at: `http://localhost:5242/swagger`

## API Endpoints

### Categories
- GET `/api/Categories` - Get all categories
- GET `/api/Categories/{id}` - Get category by ID
- POST `/api/Categories` - Create new category
- PUT `/api/Categories` - Update category
- DELETE `/api/Categories/{id}` - Delete category
- GET `/api/Categories/{id}/products` - Get category with its products

### Products
- GET `/api/Products` - Get all products
- GET `/api/Products/{id}` - Get product by ID
- POST `/api/Products` - Create new product
- PUT `/api/Products` - Update product
- DELETE `/api/Products/{id}` - Delete product
- GET `/api/Products/GetProductsWithCategory` - Get all products with their categories

## Project Structure

```
NLayerApp/
├── NLayerApp.Core/
│   ├── DTOs/
│   ├── Models/
│   ├── Repositories/
│   ├── Services/
│   └── UnitOfWorks/
├── NLayerApp.Infrastructure/
│   ├── Context/
│   ├── Repositories/
│   └── UnitOfWorks/
├── NLayerApp.Application/
│   ├── Mapping/
│   ├── Services/
│   └── Validations/
└── NLayerApp.API/
    ├── Controllers/
    └── Program.cs
``` 