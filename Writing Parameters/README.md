# SetReviewedForWalls

A Revit add-in that automatically sets the custom "Reviewed" parameter to **"Yes"** for all **Wall instances** and **Wall types** in a project.

## Features

- Scans all **Wall elements** (instances).
- Scans all **Wall types** (definitions).
- If a "Reviewed" parameter exists and is editable, sets its value to **"Yes"**.
- Counts and reports how many elements were updated.

## Prerequisites

- Revit 2022 or later (tested with Revit 2026).
- .NET Framework compatible with your Revit version.
- A shared or project parameter named **"Reviewed"** must exist on Walls and Wall Types.

## Installation

1. Build the project in Visual Studio.
2. Create a `.addin` file pointing to the compiled `.dll`.
3. Place the `.addin` file in one of Revit’s Addins folders:
   - `%AppData%\Autodesk\Revit\Addins\2026\`
   - Or your corresponding Revit version folder.

Example `.addin` file:

```xml
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<RevitAddIns>
  <AddIn Type="Command">
    <Name>Set Reviewed For Walls</Name>
    <Assembly>C:\Path\To\Your\Compiled\DLL\SetReviewedForWalls.dll</Assembly>
    <AddInId>YOUR-GUID-HERE</AddInId>
    <FullClassName>SetReviewedForWalls</FullClassName>
    <VendorId>COMPANY_ID</VendorId>
    <VendorDescription>Your Company Name</VendorDescription>
  </AddIn>
</RevitAddIns>
```

## Usage

1. Open a Revit project where the "Reviewed" parameter exists for Walls.
2. Run the command from the `Add-Ins` tab.
3. After execution:
   - All walls and wall types will have their "Reviewed" parameter set to **"Yes"**.
   - A dialog box will appear showing the total number of elements updated.

## Code Overview

- **Wall Instances**:
  - Uses `FilteredElementCollector` with `.WhereElementIsNotElementType()`.
- **Wall Types**:
  - Uses `FilteredElementCollector` without instance filtering.
- **Parameter Setting**:
  - Checks if "Reviewed" parameter exists and is writable.
  - Sets its value to "Yes".
- **Transaction Handling**:
  - All updates happen inside a single Revit transaction.

## Notes

- The "Reviewed" parameter must already be created and assigned to Walls and Wall Types.
- The code ignores walls that don't have the "Reviewed" parameter or where the parameter is read-only.

## To-Do (for future improvements)

- Add UI to allow users to pick the parameter name.
- Extend functionality to other categories (e.g., Floors, Roofs).
- Allow custom values ("Yes", "Reviewed", date-stamped text, etc.).
- Add Undo support through Revit transaction groups.

## License

This project is free to use for educational and personal purposes.
