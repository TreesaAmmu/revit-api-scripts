import clr
clr.AddReference("RevitServices")
from RevitServices.Persistence import DocumentManager
from RevitServices.Transactions import TransactionManager

clr.AddReference("RevitAPI")
import Autodesk.Revit.DB as DB

# Get the current document
doc = DocumentManager.Instance.CurrentDBDocument

# Get the input walls and unwrap them
elements = UnwrapElement(IN[0])

# Begin transaction to modify the document
TransactionManager.Instance.EnsureInTransaction(doc)

for wall in elements:
    param = wall.LookupParameter("Reviewed")
    if param and not param.IsReadOnly:
        param.Set("Yes")

TransactionManager.Instance.TransactionTaskDone()

OUT = "Updated walls: {}".format(len(elements))

