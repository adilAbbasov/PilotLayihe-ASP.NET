# PilotLayihe-ASP.NET

This project is an ASP.NET Core Web API that utilizes Entity Framework Core with PostgreSQL as the database and NetTopologySuite for handling geometric data.

## Overview

This API provides functionalities to manage geometric data along with other CRUD operations for PostgreSQL database.

## Features

- GeoJSON Import/Export: Import and export GeoJSON data for geometric data.
- Management: CRUD operations for managing geometric data.

## Endpoints

- POST /api/v1/import-points: Import GeoJSON data for points.
- POST /api/v1/import-buildings: Import GeoJSON data for buildings.
- POST /api/v1/import-roads: Import GeoJSON data for roads.
- GET /api/v1/export-buildings: Export building data as GeoJSON.
- GET /api/v1/export-building/{id}: Export a specific building as GeoJSON.
- PUT /api/v1/update-building/{id}: Update a building's attributes using GeoJSON data.
- DELETE /api/v1/delete-building/{id}: Delete a building by ID.
- POST /api/v1/import-building: Import building data using GeoJSON.

Refer to the API controller for more specific endpoint details.

## Prerequisites

Ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- Any compatible IDE or text editor (Visual Studio, Visual Studio Code, etc.)
- Before running the project, check Dependencies to make sure you have the necessary dependencies installed on your machine

## Setup

1. Clone the Repository:
   
   git clone https://github.com/adilAbbasov/PilotLayihe-ASP.NET.git

3. Update the connection string with your own connection string in appsettings.json file:
   
   {
      "ConnectionStrings": {
         "DefaultConnection": "your_own_connection_string_here"
      }
   }

4. Apply Database Migration:
   
   Add-Migration YourMigrationName

   Update-Database

## Check Endpoints

- Check endpoints using Swagger UI or Postman
