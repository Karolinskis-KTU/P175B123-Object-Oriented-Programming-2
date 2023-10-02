using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1.src
{
    public static class InOutUtils
    {
        /// <summary>
        /// Gets all data from given <paramref name="allLines"/>
        /// </summary>
        /// <param name="allLines">All data lines</param>
        /// <param name="towns">Lists of towns from data</param>
        /// <param name="routes">List of routes from data</param>
        /// <param name="src">Starting point of race</param>
        /// <param name="dest">Destination of race</param>
        public static void GetRoutesData(string[] allLines, out List<Town> towns, out List<Route> routes, out int src, out int dest)
        {
            towns = new List<Town>();
            routes = new List<Route>();

            string[] AmmountSplit = allLines[0].Split(' ');
            int TownAmm = Int32.Parse(AmmountSplit[0]);
            int RouteAmm = Int32.Parse(AmmountSplit[1]);

            for (int i = 1; i < TownAmm + 1; i++)
            {
                Town town = new Town(allLines[i], i);
                towns.Add(town);
            }

            string[] DestinationSplit = allLines[TownAmm + 2].Split(' ');
            DestinationSplit = DestinationSplit.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            src = TaskUtils.TownToInt(DestinationSplit[0], towns);
            dest = TaskUtils.TownToInt(DestinationSplit[1], towns);

            for (int i = TownAmm + 4; i < TownAmm + 4 + RouteAmm; i++)
            {
                string[] RouteSplit = allLines[i].Split(' ');
                RouteSplit = RouteSplit.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                routes.Add(new Route(RouteSplit[0], RouteSplit[1], Int32.Parse(RouteSplit[2])));
            }
        }

        /// <summary>
        /// Dumps all collected data to <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">File to write to</param>
        /// <param name="towns">Towns to add</param>
        /// <param name="routes">Routes to add</param>
        /// <param name="src">Starting point town id</param>
        /// <param name="dest">Ending point town id</param>
        public static void PrintAllDataToTxtFile(string fileName, List<Town> towns, List<Route> routes, int src, int dest)
        {
            string[] lines = new string[towns.Count + routes.Count + 11];

            lines[0] = String.Empty;
            lines[1] = String.Format("Ammount of towns: {0}", towns.Count - 1);
            lines[2] = String.Format("Ammount of routes: {0}", routes.Count - 1);
            lines[3] = String.Empty;
            lines[4] = String.Format("Town names");
            for (int i = 0; i < towns.Count; i++)
            {
                lines[i + 5] = String.Format("{0}", towns[i].Name); 
            }
            lines[towns.Count + 5] = String.Empty;
            lines[towns.Count + 6] = String.Format("Source: {0} Destination: {1}", TaskUtils.TownToString(src, towns), TaskUtils.TownToString(dest, towns));
            lines[towns.Count + 7] = String.Format(new string('-', 58));
            lines[towns.Count + 8] = String.Format("| {0, -20} | {1, -20} | {2, 8} |", "Start", "End", "Distance");
            lines[towns.Count + 9] = String.Format(new string('-', 58));
            for (int i = 0; i < routes.Count; i++)
            {
                lines[i + towns.Count + 10] = String.Format("| {0, -20} | {1, -20} | {2, 8} |", routes[i].Start, routes[i].End, routes[i].Distance);
            }
            lines[towns.Count + routes.Count + 10] = String.Format(new string('-', 58));

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

    }
}