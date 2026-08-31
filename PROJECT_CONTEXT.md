# PROJECT_CONTEXT

## Current Progress

-   Phase 1: Solution architecture ✅
-   Phase 2: Domain model completed ✅
-   Phase 3: Started Infrastructure

## Current Step

Install EF Core packages and next create the AppDbContext.

## Architecture

API ├── Application ├── Infrastructure └── Domain

Project references:

-   API -\> Application
-   API -\> Infrastructure
-   Application -\> Domain
-   Infrastructure -\> Application
-   Infrastructure -\> Domain

## Domain

Entities: - ProductionLine - Machine - Product - Inspection - Defect

Enums: - MachineStatus - InspectionResult - DefectType

## Important Decisions

-   Domain is independent from EF Core.
-   Private setters are used.
-   Constructors enforce valid creation.
-   Navigation properties use null! for EF Core compatibility.
-   Inspection exposes defects as IReadOnlyCollection.
-   Machine owns its own state transitions.
-   Validation belongs in the domain where appropriate.

## Next

Create AppDbContext inside Infrastructure, configure Fluent API
mappings, then create the first migration.
