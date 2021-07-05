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
        private string parameterValue11;
        private string parameterValue22;
        private string parameterValue33;




        //Class variable 
        Document revitDoc { get; set; }

            public Form1(Document doc)
            {
                InitializeComponent();

                this.revitDoc = doc;
                //Create a list of the parameters you want your user to choose from 
                List<string> stringParameters = new List<string>
            {
                "Вес",
                "Габариты",
                "Производитель"
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
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_PipeFitting);

            //Applying Filter

            IList<Element> ducts = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            foreach (Element duct in ducts)
            {
                //Get Parameter values

                string parameterValue1 = duct.LookupParameter(comboBox1.Text).AsValueString();
                string parameterValue2 = duct.LookupParameter(comboBox2.Text).AsValueString();
                string parameterValue3 = duct.LookupParameter(comboBox3.Text).AsValueString();


                List<string> listParam = new List<string> { parameterValue1, parameterValue2, parameterValue3 };
                List<string> listCombosNotNull = new List<string>();
                List<string> listChosen = new List<string>();

                if (comboBox1.Text != "")
                {
                    listCombosNotNull.Add(parameterValue1);
                }

                if (comboBox2.Text != "")
                {
                    listCombosNotNull.Add(parameterValue2);
                }

                if (comboBox3.Text != "")
                {
                    listCombosNotNull.Add(parameterValue3); ;
                }



                foreach (string el in listCombosNotNull)
                {

                    if (listCombosNotNull.Contains(parameterValue1))
                    {
                       listChosen.Add(el);
                    }


                    if (listCombosNotNull.Contains(parameterValue2))
                    {
                        listChosen.Add(el);
                    }

                    if (listCombosNotNull.Contains(parameterValue3))
                    {
                        listChosen.Add(el);
                    }

                }

                string newValue = String.Join(" ,", listChosen);

                using (Transaction t = new Transaction(revitDoc, "Set Parameter name"))
                {
                    t.Start();
                    duct.LookupParameter("New").Set(newValue);
                    t.Commit();
                }
















                //foreach (string s in listParam) 
                
                //{
                   
                //    if (s != "" /*&& s != null*/)
                //    {
                //        List<string> listParamNotNull = new List<string> { s };
                //        string newValue = String.Join(" ,", listParamNotNull);


                //        using (Transaction t = new Transaction(revitDoc, "Set Parameter name"))
                //        {
                //            t.Start();
                //            duct.LookupParameter("New").Set(newValue);
                //            t.Commit();
                //        }



                //    }
                //}


               















                //String.Join(" ", list.ToArray());

                //listParamNotNull

                //string newValue = parameterValue11 + "-" + parameterValue22 + "-" + parameterValue33;




                //if (parameterValue1 != "" || parameterValue1 != null)

                //{
                //    parameterValue1 = parameterValue11;
                //}

                //if (parameterValue2 != "" || parameterValue2 != null)

                //{
                //    parameterValue1 = parameterValue22;
                //}
                //if (parameterValue3 != "" || parameterValue3 != null)

                //{
                //    parameterValue3 = parameterValue33;
                //}


                //if (parameterValue1 == "" || parameterValue1 == null)

                //{
                //    parameterValue11 = "";
                //}

                //if (parameterValue2 == "" || parameterValue2 == null)

                //{
                //    parameterValue22 = "";
                //}
                //if (parameterValue3 == "" || parameterValue3 == null)

                //{
                //    parameterValue33 = "";
                //}









                //do not need .ToString() when setting parameter




                //using (Transaction t = new Transaction(revitDoc, "Set Parameter name"))
                //    {
                //        t.Start();
                //        duct.LookupParameter("New").Set(newValue);
                //        t.Commit();
                //    }

            }




        }



     

    }
}
