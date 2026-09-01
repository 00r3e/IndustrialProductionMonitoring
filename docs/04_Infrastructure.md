# Infrastructure Layer

## Overview

The Infrastructure layer is responsible for implementing technical
concerns of the application.

Unlike the Domain layer, which contains business rules, the
Infrastructure layer contains the implementation details required to
persist data, communicate with external systems, and integrate
third-party libraries.

In this project, the Infrastructure layer is responsible for:

-   Entity Framework Core
-   SQL Server
-   Database configuration
-   Dependency Injection registration
-   Entity mappings
-   Migrations

The Domain layer remains completely independent of these technologies.

## AppDbContext

Responsibilities:

-   Represents a session with the database
-   Tracks entity changes
-   Executes LINQ queries
-   Coordinates inserts, updates and deletes
-   Applies entity configurations

Current DbSets:

-   ProductionLines
-   Machines
-   Products
-   Inspections
-   Defects

Entity configurations are registered automatically using:

``` csharp
modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
```

## Entity Configurations

-   ProductConfiguration
-   MachineConfiguration
-   InspectionConfiguration
-   ProductionLineConfiguration
-   DefectConfiguration

## Why Fluent API?

Database configuration is kept in Infrastructure instead of the Domain.

Advantages:

-   Domain remains persistence-independent
-   Better separation of concerns
-   Easier maintenance
-   Supports advanced mappings

## Relationships

-   ProductionLine (1) → Machine (\*)
-   Machine (1) → Inspection (\*)
-   Product (1) → Inspection (\*)
-   Inspection (1) → Defect (\*)

Delete behaviors:

-   Restrict
-   Restrict
-   Restrict
-   Cascade

## Migrations

Current migration:

-   InitialCreate

Commands:

``` powershell
Add-Migration InitialCreate
Update-Database
```

## SQL Server

Database: IndustrialMonitoringDb

Server: KETI`\SQLEXPRESS`{=tex}

## Dependency Injection

``` csharp
builder.Services.AddInfrastructure(builder.Configuration);
```

## Lessons Learned

-   DbContext
-   DbSet
-   Change Tracking
-   Fluent API
-   IEntityTypeConfiguration`<T>`{=html}
-   ApplyConfigurationsFromAssembly
-   Code First
-   Migrations
-   SQL Server integration

## Common Problems Solved

-   Installed Microsoft.EntityFrameworkCore.Tools
-   Installed Microsoft.EntityFrameworkCore.Design in the API project

## Phase Summary

Phase 3 completed successfully with a complete EF Core Code First
infrastructure.
