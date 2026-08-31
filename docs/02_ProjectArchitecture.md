# Project Architecture

## Solution

IndustrialMonitoring.sln

-   IndustrialMonitoring.Api
-   IndustrialMonitoring.Application
-   IndustrialMonitoring.Domain
-   IndustrialMonitoring.Infrastructure

## Dependency Direction

API ├── Application ├── Infrastructure

Application └── Domain

Infrastructure ├── Application └── Domain

Domain (no dependencies)

## Philosophy

The Domain must never depend on ASP.NET Core, EF Core, SQL Server, or
Angular.
