# Anime API

## Overview

Anime API is a RESTful web service built with **ASP.NET 8** that provides full **CRUD** (Create, Read, Update, Delete) functionality for managing anime show data stored in a **SQL database**. Each anime entry includes an `ID`, `Name`, `Author`, and `Animation Studio`.

This project was created to explore modern API development practices using ASP.NET and to demonstrate secure data handling with **Data Transfer Objects (DTOs)**.

## Features

- RESTful endpoints for anime data management
- Secure data exposure using DTOs to hide internal identifiers when appropriate
- SQL database integration for persistent storage
- Clean separation of concerns using layered architecture
- Scalable and maintainable codebase

## Technologies Used

- ASP.NET 8
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger (for API documentation)

## API Endpoints

| Method | Endpoint           | Description                  |
|--------|--------------------|------------------------------|
| GET    | `/api/anime`       | Retrieve all anime shows     |
| GET    | `/api/anime/{id}`  | Retrieve a specific anime    |
| POST   | `/api/anime`       | Create a new anime entry     |
| PUT    | `/api/anime/{id}`  | Update an existing anime     |
| DELETE | `/api/anime/{id}`  | Delete an anime entry        |

## Data Model

Each anime show includes the following fields:

- `ID` (internal use only)
- `Name`
- `Author`
- `AnimationStudio`

DTOs are used to control which fields are exposed to the client, improving security and flexibility.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (local or cloud instance)

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/madridcm010/AnimeApi.git
   cd AnimeApi/Api
Update the connection string in appsettings.json to match your SQL Server configuration.

Run database migrations:
  - dotnet ef database update

 Launch the API:
  - dotnet run
- Access Swagger UI at http://localhost:5000/swagger to explore and test the endpoints.
