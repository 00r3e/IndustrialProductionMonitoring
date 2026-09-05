# PROJECT_CONTEXT.md

# Industrial Production Monitoring System

## Project Goal

Build a portfolio-quality Industrial Production Monitoring System using
ASP.NET Core, Clean Architecture, Entity Framework Core, SQL Server and
Angular.

The application simulates a real industrial production environment where
machines inspect products and send inspection results to a central
server.

The system allows operators and production managers to: - Monitor
machine status - Record production inspections - View production
statistics - Analyze quality information - Monitor production in real
time (later with SignalR)

The project demonstrates professional software architecture rather than
simple CRUD operations.

## Architecture

Presentation (API) → Application → Domain → Infrastructure → SQL Server

### Domain

-   Entities
-   Enums
-   Business Rules

### Application

-   CQRS Commands
-   CQRS Queries
-   DTOs
-   Repository Interfaces
-   Handlers

### Infrastructure

-   EF Core
-   SQL Server
-   Configurations
-   Repositories
-   Unit Of Work
-   Migrations
-   Seed Data

### API

-   Controllers
-   Swagger
-   Dependency Injection

## Current Features

### Machines

-   Start
-   Stop
-   Enter Maintenance
-   Exit Maintenance
-   Get Machines

### Inspections

-   Create Inspection
-   Get Inspections

### Dashboard

-   Dashboard Summary

### Lookup APIs

-   Products (Get All / Get By Id)
-   Production Lines (Get All / Get By Id)

## Current Phase

Phase 4.5 -- Backend Polish

Planned: - Global Exception Middleware - Custom Exceptions -
ProblemDetails - Better HTTP Status Codes - Validation
