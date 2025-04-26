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
```

## Usage

1. Open a Revit project containing walls.
2. Run the command from the `Add-Ins` tab.
3. After execution:
   - A new Excel workbook opens.
   - Wall data will be saved to:

     ```
     C:\Users\USER\Documents\WallData.xlsx
     ```

4. A confirmation dialog will appear once done.

## Code Overview

- **Collect Walls**: Uses `FilteredElementCollector` to get all Wall elements.
- **Extract Parameters**:
  - `Wall.Width`
  - `WALL_USER_HEIGHT_PARAM`
- **Excel Interop**:
  - Creates a new workbook.
  - Writes data row by row.
  - Saves the workbook to disk.
  - Optionally keeps Excel open for user review.

## Notes

- You can change the **save path** in the `savePath` variable inside the code.
- This example uses **COM Interop** for Excel. Remember to **release COM objects** in a production environment to avoid memory leaks.
- If a wall’s height parameter is missing, it displays as "Missing" in the Excel file.

## To-Do (for future improvements)

- Let the user choose the save location via a Save File Dialog.
- Add more wall parameters (e.g., Type Name, Volume).
- Export data without opening Excel (using `ClosedXML` or `EPPlus` instead of Interop).
- Improve error handling.

## License

This project is free to use for educational and personal purposes.
