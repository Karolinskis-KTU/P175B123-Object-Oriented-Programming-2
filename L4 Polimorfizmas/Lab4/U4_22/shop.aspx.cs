using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;

using U4_22.Classes;
using U4_22.Code;

namespace U4_22
{
    public partial class shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Server.MapPath("App_Data");
            string dir = Server.MapPath(TextBox1.Text);

            Store allStores;

            try
            {
                allStores = InOutUtils.ReadDevicesDir(dir);
            } catch (Exception ex)
            {
                Debug.WriteLine("Oops an error occured:");
                Debug.WriteLine(ex);
                throw ex;
            }

            


            // TASK 1
            // Find all different colors of fridges
            List<string> FridgeColors = allStores.AllColorsByDeviceType("Fridge");
            foreach (var fridgeColor in FridgeColors)
            {
                FridgeColorsTable.Rows.Add(DataOutput.MakeRow(fridgeColor));
            }
            Label2.Visible = true;

            // TASK 2
            // Find all different colors of kettles
            List<string> KettleColors = allStores.AllColorsByDeviceType("Kettle");
            foreach (var kettleColor in KettleColors)
            {
                KettleColorsTable.Rows.Add(DataOutput.MakeRow(kettleColor));
            }
            Label3.Visible = true;

            // TASK 3
            // Find all cheapest A+ devices

            Fridge CheapestFridge = allStores.FindCheapestFridgeByRating();
            Oven CheapestOven = allStores.FindCheapestOvenByRating();
            Kettle CheapestKettle = allStores.FindCheapestKettleByRating();

            Label4.Visible = true;
            if (CheapestFridge != null)
            {
                CheapestFridgeTable.Rows.Add(DataOutput.MakeRow(CheapestFridge.ParamArray()));
                CheapestFridgeTable.Rows.Add(DataOutput.MakeRow(CheapestFridge.ToStringArray()));
            } else
            {
                CheapestFridgeTable.Rows.Add(DataOutput.MakeRow("Nerasta šaldytuvų"));
            }

            Label5.Visible = true;
            if (CheapestOven != null)
            {
                CheapestOvenTable.Rows.Add(DataOutput.MakeRow(CheapestOven.ParamArray()));
                CheapestOvenTable.Rows.Add(DataOutput.MakeRow(CheapestOven.ToStringArray()));
            } else
            {
                CheapestOvenTable.Rows.Add(DataOutput.MakeRow("Nerasta mikrobangų krosnelių"));
            }

            Label6.Visible = true;
            if (CheapestKettle != null)
            {
                CheapestKettleTable.Rows.Add(DataOutput.MakeRow(CheapestKettle.ParamArray()));
                CheapestKettleTable.Rows.Add(DataOutput.MakeRow(CheapestKettle.ToStringArray()));
            } else
            {
                CheapestKettleTable.Rows.Add(DataOutput.MakeRow("Nerasta virdulių"));
            }



            


            // TASK 4
            // Get all fridges which width is between 52 and 56 cm
            List<Device> CertainWidthFridge = allStores.AllFridgesBetweenWidth(52, 56);
            // Print
            InOutUtils.PrintDevicesCSV(Server.MapPath("App_Data/Tilps.csv"), CertainWidthFridge);

            // TASK 5
            // Find all most expensive devices
            decimal minFridge = 1000;
            decimal minOven = 500;
            decimal minKettle = 50;
            List<Device> allStoresAbovePrice = TaskUtils.FindAllDevicesAbovePrices(allStores, minFridge, minOven, minKettle);
            allStoresAbovePrice.Sort();

            InOutUtils.PrintDevicesCSV(Server.MapPath("App_Data/Brangus.csv"), allStoresAbovePrice);

        }
    }
}