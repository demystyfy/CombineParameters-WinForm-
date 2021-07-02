using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
//using System.Windows.Media.Imaging;


namespace CombineParametersWinForm
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }


        public Result OnStartup(UIControlledApplication app)
        {
            //Create Ribbon Element
            app.CreateRibbonTab("D1C P");
            string path = Assembly.GetExecutingAssembly().Location;
            //needs to be string, therefore using quotation marks 
            PushButtonData button = new PushButtonData("QWERTY", "Click to combine parameters", path, "CombineParametersWinForm.CombineParametersWinForm");
            //panel - group of commands
            RibbonPanel panel = app.CreateRibbonPanel("D1C P", "Combining parameters using Win Forms");
            PushButton pushButton = panel.AddItem(button) as PushButton;

            return Result.Succeeded;
        }



    }






}
