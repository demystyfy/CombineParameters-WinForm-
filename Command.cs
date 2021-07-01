#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace CombineParametersWinForm
{

    [Transaction(TransactionMode.Manual)]


    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message,
         ElementSet elements)
        
        {

        }





    }


}
