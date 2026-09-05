# 05_Application.md

# Phase 4 -- Application Layer

## Purpose

The Application layer coordinates business workflows.

It contains: - Commands - Queries - Handlers - DTOs - Repository
Interfaces

Business rules remain in the Domain layer.

## Current Features

### Machine

Commands: - StartMachine - StopMachine - EnterMaintenance -
ExitMaintenance

Queries: - GetMachines

### Inspection

Commands: - CreateInspection

Queries: - GetInspections

### Dashboard

Queries: - GetDashboardSummary

### Lookup Data

Products: - GetProducts - GetProduct

Production Lines: - GetProductionLines - GetProductionLine

## Design Principles

-   Thin Controllers
-   Rich Domain Model
-   CQRS
-   Repository Pattern
-   Unit of Work
-   Manual DTO Mapping
-   Dependency Injection

## Planned Improvements

-   Global Exception Middleware
-   Custom Exceptions
-   ProblemDetails
-   FluentValidation
-   Evaluate AutoMapper
-   Evaluate MediatR
