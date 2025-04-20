using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel; // Alias to avoid 'Parameter' conflict

namespace RevitWallReader
{
    [Transaction(TransactionMode.Manual)]
    public class ExportWallDataToExcel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            // Collect all walls in the model
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> walls = collector.OfClass(typeof(Wall)).ToElements();

            // Start Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet sheet = workbook.Sheets[1];
            sheet.Name = "Wall Data";

            // Header row
            sheet.Cells[1, 1] = "Wall ID";
            sheet.Cells[1, 2] = "Width (mm)";
            sheet.Cells[1, 3] = "Height (mm)";

            int row = 2;

            foreach (Element element in walls)
            {
                Wall wall = element as Wall;
                if (wall == null) continue;

                double width = UnitUtils.ConvertFromInternalUnits(wall.Width, UnitTypeId.Millimeters);
                Autodesk.Revit.DB.Parameter heightParam = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);
                double height = (heightParam != null && heightParam.HasValue)
                    ? UnitUtils.ConvertFromInternalUnits(heightParam.AsDouble(), UnitTypeId.Millimeters)
                    : -1;

                sheet.Cells[row, 1] = wall.Id.Value.ToString();
                sheet.Cells[row, 2] = width.ToString("F2");
                sheet.Cells[row, 3] = (height != -1) ? height.ToString("F2") : "Missing";

                row++;
            }

            // Save the file (change path as needed)
            string savePath = @"C:\Users\USER\Documents\WallData.xlsx";
            workbook.SaveAs(savePath);

            // Show Excel (or use .Quit() to close silently)
            excelApp.Visible = true;

            // Optional: release Excel COM objects
            // workbook.Close(false);
            // excelApp.Quit();
            // Marshal.ReleaseComObject(sheet);
            // Marshal.ReleaseComObject(workbook);
            // Marshal.ReleaseComObject(excelApp);

            TaskDialog.Show("Success", $"Wall data exported to:\n{savePath}");
            return Result.Succeeded;
        }
    }
}
