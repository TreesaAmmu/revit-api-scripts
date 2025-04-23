# Dynamo Script: Update Wall Parameters in Revit

## Description

This Python script for Dynamo automates the process of updating a specific parameter in wall elements within a Revit document. It iterates over the selected walls and updates the value of the "Reviewed" parameter to "Yes" if the parameter is not read-only.

This script is useful for quickly marking walls as reviewed in a project, which can be part of a larger workflow for managing Revit models.

## Features

- **Automates Parameter Update**: Iterates through the selected wall elements and updates the "Reviewed" parameter to "Yes".
- **Handles Read-Only Parameters**: Checks if the "Reviewed" parameter is not read-only before attempting to set its value.
- **Transaction Management**: Ensures that the script runs within a valid Revit transaction, enabling safe modification of the Revit model.

## Requirements

- **Revit** (or compatible version)
- **Dynamo for Revit**
- **IronPython2 for Dynamo**
- **Revit API** (included in Revit installation)

## Instructions

1. Open Dynamo for Revit.
2. Create a new Dynamo script or open an existing one.
3. Paste the provided Python code into a Python Script node.
4. Connect the input node to the wall elements you want to modify.
5. Run the Dynamo script to automatically update the "Reviewed" parameter for all selected walls.

## Screenshot

Here’s a preview of how the Dynamo script looks in action:

![Screenshot of Output](Dynamo Connection/Screenshot 2025-04-23 122601.png)

## Script Breakdown

1. **clr.AddReference**: Imports necessary libraries and references required to access the Revit API.
2. **DocumentManager.Instance.CurrentDBDocument**: Retrieves the current Revit document.
3. **UnwrapElement(IN[0])**: Unwraps the input elements from Dynamo and retrieves the wall elements.
4. **TransactionManager.Instance.EnsureInTransaction**: Begins a transaction to modify the document.
5. **LookupParameter("Reviewed")**: Looks up the "Reviewed" parameter for each wall element.
6. **param.Set("Yes")**: Sets the "Reviewed" parameter to "Yes" for each wall if the parameter is editable.
7. **TransactionManager.Instance.TransactionTaskDone()**: Commits the transaction after modifying the parameters.

## Example Input

- **IN[0]**: A list of wall elements from the Dynamo workspace that you wish to modify.

## Output

- The script outputs a message indicating how many walls were updated.

```python
OUT = "Updated walls: {}".format(len(elements))
