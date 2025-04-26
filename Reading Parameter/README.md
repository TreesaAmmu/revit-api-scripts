# ExportWallDataToExcel

A simple Revit add-in that collects all **Wall** elements from an active Revit model and exports their **ID**, **Width**, and **Height** into an **Excel** spreadsheet.

## Features

- Collects all Wall elements in the current Revit project.
- Extracts:
  - Wall ID
  - Width (in millimeters)
  - Height (in millimeters)
- Exports the data into an Excel (.xlsx) file.
- Opens Excel automatically after export.

## Prerequisites

- Revit 2022 or later (tested with Revit 2026).
- .NET Framework (compatible with your Revit version).
- Microsoft Excel installed on your machine.
- Microsoft.Office.Interop.Excel reference added to your project.

## Installation

1. Build the project in Visual Studio.
2. Create a `.addin` file pointing to the compiled `.dll`.
3. Place the `.addin` file in one of Revit’s Addins folders:
   - `%AppData%\Autodesk\Revit\Addins\2026\`
   - Or your corresponding Revit version folder.
4. Make sure to give the <Assembly> as the path where you saved the file

Example `.addin` file:

```xml
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<RevitAddIns>
  <AddIn Type="Command">
    <Name>Export Wall Data to Excel</Name>
    <Assembly>C:\Path\To\Your\Compiled\DLL\RevitWallReader.dll</Assembly>
    <AddInId>YOUR-GUID-HERE</AddInId>
    <FullClassName>RevitWallReader.ExportWallDataToExcel</FullClassName>
    <VendorId>COMPANY_ID</VendorId>
    <VendorDescription>Your Company Name</VendorDescription>
  </AddIn>
</RevitAddIns>

