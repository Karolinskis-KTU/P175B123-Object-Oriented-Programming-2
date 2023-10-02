using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.src
{
    public class Route
    {
        /// <summary>
        /// Starting city name of route
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// Ending city name of route
        /// </summary>
        public string End { get; set; }
        /// <summary>
        /// Distance between towns
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Create new route
        /// </summary>
        /// <param name="start">Starting city name of route</param>
        /// <param name="end">Ending city name of route</param>
        /// <param name="distance">Distance between towns</param>
        public Route(string start, string end, int distance)
        {
            Start = start;
            End = end;
            Distance = distance;
        }
    }
}