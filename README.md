# UserManagement.API

A **.NET 7 Web API** for internal user management, built with **ASP.NET Core**, featuring:

* CRUD operations for user management
* Validation and error handling
* Logging middleware
* Authentication middleware
* Swagger integration
* Unit testing and Postman test cases

---

## Table of Contents

* [Features](#features)
* [Getting Started](#getting-started)
* [API Endpoints](#api-endpoints)
* [Middleware](#middleware)
* [Testing](#testing)
* [Copilot Contribution Documentation](#copilot-contribution-documentation)

---

## Features

* **CRUD operations**: Create, Read, Update, Delete users
* **Validation**: Ensures email, name, and other fields are valid
* **Global error handling**: Catches unhandled exceptions, returns JSON errors
* **Logging**: Tracks HTTP method, request path, status codes, and response times
* **Authentication**: Token-based access for secure internal usage
* **Swagger integration**: Interactive API documentation with authorization support
* **Performance optimizations**: AsNoTracking, paged queries, reduced EF overhead

---

## Getting Started

1. Clone the repository:

```bash
git clone <repo-url>
cd UserManagementAPI
```

2. Run the API:

```bash
dotnet run
```

3. Navigate to Swagger UI:

```
https://localhost:<port>/swagger
```

4. Use the token `my-secret-token` in the Authorize button to access secured endpoints.

---

## API Endpoints

| Method | Endpoint        | Description     | Status Codes  |
| ------ | --------------- | --------------- | ------------- |
| GET    | /api/users      | Get all users   | 200           |
| GET    | /api/users/{id} | Get user by ID  | 200, 404      |
| POST   | /api/users      | Create new user | 201, 400      |
| PUT    | /api/users/{id} | Update user     | 200, 400, 404 |
| DELETE | /api/users/{id} | Delete user     | 204, 404      |

---

## Middleware

* **Error Handling Middleware**: Catches all unhandled exceptions and returns JSON errors.
* **Authentication Middleware**: Validates token and returns 401 if invalid or missing.
* **Logging Middleware**: Logs HTTP method, path, response status, and execution time.

**Pipeline order (important):**

1. Error handling
2. Authentication
3. Logging
4. Controllers

---

## Testing

* Use **tests.http** / **Postman** to test all CRUD endpoints.
* Validate edge cases such as missing/invalid tokens, invalid user data, and exceptions.
* Middleware logs appear in console; JSON error responses ensure stability.

---

## Copilot Contribution Documentation

### How Copilot Assisted in Improving the API

Copilot helped accelerate development and ensure quality through:

#### 1. Boilerplate Generation

* Generated **Program.cs** with clean configuration
* Configured **EF Core InMemory** database for rapid development/testing
* Added **Swagger setup** for API documentation

#### 2. CRUD Endpoint Scaffolding

* Generated **UsersController** with full CRUD operations
* Correct **HTTP verbs** (GET, POST, PUT, DELETE)
* RESTful routing patterns
* Proper **return types** and HTTP status codes (200, 201, 204, 404, 400)

#### 3. Code Quality Improvements

* Added **async/await** for non-blocking operations
* Applied **model validation attributes** ([Required], [EmailAddress], etc.)
* Used **CreatedAtAction** for REST compliance
* Introduced **centralized error handling**
* Enforced **separation of concerns**

#### 4. Best Practices Applied

* **Dependency Injection** for services and DbContext
* **DbContext pattern** for database access
* `[ApiController]` for automatic validation
* Clean, descriptive naming conventions
* Structured project layout for maintainability

#### 5. Testing Guidance

* Provided **Postman test cases** for all endpoints
* Suggested **unit testing** with xUnit / WebApplicationFactory

---

### Copilot Contribution: Issue Identification & Resolution

#### 1. Identified Design Flaws

* Direct entity binding caused **ID exposure**
* Missing **pagination** in GET endpoints
* No **global exception handling** initially
* Incomplete **validation enforcement**

#### 2. Applied Enterprise Best Practices

* Introduced **DTO pattern** to avoid direct entity exposure
* Implemented **pagination** for performance
* Added **AsNoTracking** for read operations
* Centralized **exception handling middleware**
* Improved **validation consistency**

#### 3. Improved API Stability

* Prevented crashes via **error-handling middleware**
* Ensured proper **HTTP status codes**
* Protected **entity integrity**

#### 4. Increased Performance

* Reduced **EF tracking overhead**
* Implemented **paged queries**
* Optimized **database lookups**

---

### Additional Points

* Copilot suggested **middleware order for optimal performance**
* Assisted in generating **Swagger Bearer token integration snippets**
* Helped produce **tests.http** for quick verification

---



Do you want me to do that next?

Can you please make it markup language
