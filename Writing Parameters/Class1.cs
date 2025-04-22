using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;

[Transaction(TransactionMode.Manual)]
public class SetReviewedForWalls : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uidoc = commandData.Application.ActiveUIDocument;
        Document doc = uidoc.Document;
        int updatedCount = 0;

        using (Transaction tx = new Transaction(doc, "Set Reviewed to Yes"))
        {
            tx.Start();

            // 1. Update Wall Instances
            var walls = new FilteredElementCollector(doc)
                            .OfClass(typeof(Wall))
                            .WhereElementIsNotElementType()
                            .ToList();

            foreach (var wall in walls)
            {
                Parameter reviewedParam = wall.LookupParameter("Reviewed");
                if (reviewedParam != null && !reviewedParam.IsReadOnly)
                {
                    reviewedParam.Set("Yes");
                    updatedCount++;
                }
            }

            // 2. Update Wall Types
            var wallTypes = new FilteredElementCollector(doc)
                                .OfClass(typeof(WallType))
                                .ToList();

            foreach (var wallType in wallTypes)
            {
                Parameter reviewedParam = wallType.LookupParameter("Reviewed");
                if (reviewedParam != null && !reviewedParam.IsReadOnly)
                {
                    reviewedParam.Set("Yes");
                    updatedCount++;
                }
            }

            tx.Commit();
        }

        TaskDialog.Show("Set Reviewed", $"Updated 'Reviewed' parameter to 'Yes' on {updatedCount} walls and wall types.");
        return Result.Succeeded;
    }
}
