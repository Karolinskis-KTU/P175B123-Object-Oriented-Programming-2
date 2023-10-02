using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lab1.src;

namespace Lab1
{
    public partial class Varzybos : System.Web.UI.Page
    {

        private string FileDirDataIn = "data/U4.txt";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(FileDirDataIn)) == false)
            {
                // Disable solution button if target file doesn't exist
                Button1.Enabled = false;
                CustomValidator1.ErrorMessage = "Duomenų failas: " + FileDirDataIn + " neegzistuoja.";
                CustomValidator1.IsValid = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string FileDump = Server.MapPath("data/data.txt");

            List<Town> Towns = new List<Town>();
            List<Route> Routes = new List<Route>();

            int src;
            int dest;

            string[] allLines = File.ReadAllLines(Server.MapPath(FileDirDataIn));
            InOutUtils.GetRoutesData(allLines, out Towns, out Routes, out src, out dest);

            // Create table with given data
            Table1.Rows.Add(DataOutput.MakeRow(Towns.Count.ToString(), Routes.Count.ToString()));

            foreach (var town in Towns)
            {
                Table1.Rows.Add(DataOutput.MakeRow(town.Name));
            }

           

            Table1.Rows.Add(DataOutput.MakeEmptyRow());

            Table1.Rows.Add(DataOutput.MakeRow(TaskUtils.TownToString(src, Towns), TaskUtils.TownToString(dest, Towns)));

            Table1.Rows.Add(DataOutput.MakeEmptyRow());


            foreach (var route in Routes)
            {
                Table1.Rows.Add(DataOutput.MakeRow(route.Start, route.End, route.Distance.ToString()));
            }

            // Solution
            List<Routing> routing = new List<Routing>();
            int[,] graph = TaskUtils.CreateGraph(Towns, Routes);
            int[] distances = TaskUtils.Dijkstra(graph, src, Towns, out routing);

            int[] shortestDistances = new int[graph.GetLength(0)];
            int[] parents = new int[graph.GetLength(0)];

            // Print solution
            Table2.Rows.Add(DataOutput.MakeRow("Minimalus atstumas tarp vietoviu"));

            int routeID = TaskUtils.GetCorrectRoute(distances, dest, Towns);
            Table2.Rows.Add(DataOutput.MakeRow(Towns[src].Name + " ir " + Towns[routeID].Name, distances[routeID].ToString() + " km"));


            Table2.Rows.Add(DataOutput.MakeRow("Trasa eina per vietoves:"));
            for (int i = 0; i < routing[routeID].Count; i++)
            {
                Table2.Rows.Add(DataOutput.MakeRow(TaskUtils.TownToString(routing[routeID].Get(i), Towns)));
            }
            Table2.Rows.Add(DataOutput.MakeRow(TaskUtils.TownToString(dest, Towns)));

            InOutUtils.PrintAllDataToTxtFile(FileDump, Towns, Routes, src, dest);

        }
    }
}