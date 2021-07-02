using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombineParametersWinForm
{
   
    public partial class Form1 : System.Windows.Forms.Form
    {

        //Class variable 
        Document revitDoc { get; set; }

        public Form1(Document doc)
        {
            InitializeComponent();

            this.revitDoc = doc;
            //Create a list of the parameters you want your user to choose from 
            List<string> stringParameters = new List<string>
            {
                "textParameter1",
                "textParameter2",
                "textParameter3"//,
               // "textParameter4"
            };
            //Add list to comboboxes on form 
            foreach (string parameterName in stringParameters)
            {
                comboBox1.Items.Insert(0, parameterName);
                comboBox2.Items.Insert(0, parameterName);
                comboBox3.Items.Insert(0, parameterName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FilteredElementCollector collector = new FilteredElementCollector(revitDoc);
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_DuctFitting);

            //Applying Filter

            IList<Element> ducts = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            using (Transaction t = new Transaction(revitDoc, "Set Parameter name"))
            {
                //Use a try and catch for transactions
                try
                {
                    t.Start();
                    foreach (Element duct in ducts)
                    {
                        //Get Parameter values
                        string parameterValue1 = duct.LookupParameter(comboBox1.Text).AsString();
                        string parameterValue2 = duct.LookupParameter(comboBox2.Text).AsString();
                        string parameterValue3 = duct.LookupParameter(comboBox3.Text).AsString();

                        string newValue = parameterValue1 + "-" + parameterValue2 + "-" + parameterValue3;

                        //do not need .ToString() when setting parameter
                        duct.LookupParameter("NewParameter").Set(newValue);
                    }
                    t.Commit();
                }

                //Catch with error message
                catch (Exception err)
                {
                    TaskDialog.Show("Error", err.Message);
                    t.RollBack();
                }



            }

        }

    }
}
