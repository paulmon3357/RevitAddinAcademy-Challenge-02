#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

#endregion

namespace RevitAddinAcademy_Challenge_02
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            //Application app = uiapp.Application;
            Document doc = uidoc.Document;

            TaskDialog.Show("REVI Addin Academy", "Challenge 02");

            String excelFile = @"E:\C-Sharp\RevitAddinAcademy-Challenge 02\Session02_Challenge.xlsx";
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWb=excelApp.Workbooks.Open(excelFile);
            Excel.Worksheet excelWs = excelWb.Worksheets.Item[1];

            Excel.Range excelRng = excelWs.UsedRange;
            int rowCount = excelRng.Rows.Count;

            //do some stuff in Excel

            excelWb.Close();
            excelApp.Quit();


            return Result.Succeeded;
        }
    }
}
