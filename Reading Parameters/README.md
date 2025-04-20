# RevitWallReader

This is a Revit external command written in C# that exports wall data (ID, width, and height) from a Revit model to an Excel spreadsheet. It leverages the Revit API and the Excel Interop library to automate the process of exporting wall-related data.

## Features
- Collects all wall elements from the active Revit model.
- Extracts data such as Wall ID, Width (in mm), and Height (in mm).
- Exports the collected data into an Excel file.
- The Excel file is saved to a specified path (customizable in the code).
- Displays the export path once the data is successfully saved.

## Prerequisites
- Revit 2025 (or similar versions).
- Visual Studio (for compiling and debugging).
- Microsoft Excel installed on your system.
- Git for version control (optional, for publishing the code to GitHub).

## Installation

### 1. Clone the repository
Clone this repository to your local machine using Git:
```bash
git clone https://github.com/your-username/RevitWallReader.git

