# Domain Model

## Entities

-   ProductionLine
-   Machine
-   Product
-   Inspection
-   Defect

## Relationships

ProductionLine (1) -\> (\*) Machine

Machine (1) -\> (\*) Inspection

Product (1) -\> (\*) Inspection

Inspection (1) -\> (\*) Defect

## Current Domain Behavior

Machine: - Start() - Stop() - EnterMaintenance() - ExitMaintenance()

Inspection: - AddDefect()

Business Rules:

-   Passed inspections cannot have defects.
-   Processing time cannot be negative.
-   Entity constructors validate required data.
