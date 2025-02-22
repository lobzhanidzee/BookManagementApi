# Book Management API
The **Book Management API** is a RESTful service that allows users to manage a collection of books. It provides endpoints for creating, reading, updating, and deleting books, as well as user authentication using **JWT tokens**.

## Features

- **CRUD Operations:** Create, read, update, and delete books.
- **Pagination:** Retrieve books with pagination support.
- **JWT Authentication:** Secure endpoints with JSON Web Tokens.
- **Swagger Documentation:** Interactive API documentation with Swagger UI.
- **Soft Delete:** Soft delete functionality for books.
- **Bulk Operations:** Add and delete multiple books in a single request.

## Technologies Used
- **.NET 8**
- **C# 12.0**
- **Entity Framework Core 9.0.2**
- **SQL Server**
- **JWT Authentication**
- **Swagger (Swashbuckle.AspNetCore 6.6.2)**


## Getting Started

### Prerequisites
* .NET 8 SDK
* SQL Server
* Visual Studio

### Installation
1.	Clone the repository:


```bash
   git clone https://github.com/lobzhanidzee/BookManagementApi.git
   cd BookManagementApi
```
2.	Update the connection string in appsettings.json:
```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=[your-server];Database=[database-name];Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"
     },
     "JwtConfig": {
       "Issuer": "your_issuer",
       "Audience": "your_audience",
       "Key": "your_secret_key",
       "TokenValidityMins": 30
     }
   }
```

3.	Run database migrations. *Open the NuGet Package Manager Console:*
```bash
add-migration [migration name]
update-database
```

## Usage
### *Authentication*

1.	Obtain a **JWT token** by sending a POST request to /api/auth/login with your username and password.

| Username | Password     | Description                |
| :-------- | :------- | :------------------------- |
| `Daviti` | `daviti123` | Get **Your token** |

```json
{
  "username": "Daviti",
  "password": "daviti123"
}
```

2.	Then authorize with token given in header response.
```json
{
  "username": "Daviti",
  "token": "HERE WILL BE YOUR TOKEN",
  "expiresIn": 1799
}
```

## Endpoints
- **Get Books:** GET /api/books
- **Get Book by ID:** GET /api/books/{id}
- **Add Book:** POST /api/books
- **Update Book:** PUT /api/books/{id}
- **Soft Delete Book:** DELETE /api/books/{id}
- **Add Books in Bulk:** POST /api/books/bulk
- **Soft Delete Books in Bulk:** DELETE /api/books/bulk

## Swagger Documentation
Access the Swagger UI at /swagger to explore and test the API endpoints interactively.
