# Doctor Visit Reservation

## Overview
This is a C# application using ASP.NET Core, designed to facilitate scheduling and managing doctor appointments. The system currently offers a backend API.

## Technologies
The project uses the following technologies:
- **.NET Core**: Core framework for backend development.
- **CQRS & MediatR**: Implements the Command Query Responsibility Segregation pattern to separate read and write operations.
- **AutoMapper**: Utilized for mapping domain models to data transfer objects.
- **.NET API**: Core technology for backend development.
- **EF Core**: Entity Framework Core for ORM and data management.
- **xUnit & Moq**: For unit testing to ensure code quality and functionality.

## Project Structure
- **DoctorVisitReservation.Application**: Contains the application layer with the application logic and interfaces.
- **DoctorVisitReservation.Domain**: Contains the domain layer with the domain models.
- **DoctorVisitReservation.Persistence**: Contains the persistence layer with the implementation of interfaces defined in the application layer, managing database details and data access.
- **DoctorVisitReservation.Api**: Hosts the RESTful API endpoints.
- **DoctorVisitReservation.UnitTests**: Contains unit tests for the application. This project uses xUnit and Moq for mocking dependencies


## Features

- **API for managing doctor visits**: The current functionality revolves around creating, managing, and searching for doctor appointments via RESTful services.
- **Global Error Handling**: The API includes a global error handling mechanism.
- **Validation with FluentValidation**: Requests are validated using FluentValidation. This ensures that the data received by our API meets the business rules before being processed.
- **Response Status Codes**: The API is designed to return HTTP status codes that reflect the outcome of the API operations.

## Planned Features
- **Blazor Client**: To provide a frontend user interface for interacting with the API.
- **JWT Authentication**: To secure the application.

## Getting Started
To get started with the project, follow these steps:

1. Clone the repository to your local machine: git clone https://github.com/filipfilip1/DoctorVisitReservation.git
2. Open the solution file in Visual Studio or another IDE.
3. Restore the NuGet packages.
4. Configure the database connection:
- Ensure SQL Server is running and accessible.
- Update the connection string in appsettings.json accordingly to match your database server.
5. Apply database migrations to set up your database schema:
- dotnet ef database update 
6. Set the startup project to DoctorVisitReservation.Api.
7. Run the project.

## API Documentation
Access the API documentation through Swagger UI

## Usage
Access the API through tools like Swagger or Postman.

