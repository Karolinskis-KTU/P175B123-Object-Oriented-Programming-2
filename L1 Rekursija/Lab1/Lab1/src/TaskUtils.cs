using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.src
{
    public class TaskUtils : DataOutput
    {
        /// <summary>
        /// Finds the shortest distance from all distances
        /// </summary>
        /// <param name="distances">All distances</param>
        /// <param name="tree">Tree of distances</param>
        /// <param name="min">Minnimum distance length</param>
        /// <param name="min_index">Minimum distance index</param>
        /// <param name="Nodes">Node ammount</param>
        /// <param name="iteration">Itteration start</param>
        private static void MinimumDistance(int[] distances, bool[] tree, int min, ref int min_index, int Nodes, int iteration)
        {
            if (iteration != Nodes)
            {
                if (tree[iteration] == false && distances[iteration] <= min)
                {
                    min = distances[iteration];
                    min_index = iteration;
                }
                MinimumDistance(distances, tree, min, ref min_index, Nodes, iteration + 1);
            }

            else
                return;
        }

        /// <summary>
        /// Finds all paths from <paramref name="src"/> to all different cities
        /// </summary>
        /// <param name="graph">Distances between all towns</param>
        /// <param name="src">Start of path finding</param>
        /// <param name="towns">All towns</param>
        /// <param name="routing">Found routes</param>
        /// <returns>Distances between all cities</returns>
        public static int[] Dijkstra(int[,] graph, int src, List<Town> towns, out List<Routing> routing)
        {
            routing = new List<Routing>();

            int Nodes = towns.Count;

            int[] distances = new int[Nodes];
            bool[] tree = new bool[Nodes];


            // Set distances to max value
            for (int i = 0; i < Nodes; i++)
            {
                distances[i] = int.MaxValue;
                tree[i] = false;
            }
            distances[src] = 0;


            for (int i = 0; i < Nodes - 1; i++)
            {

                int min = int.MaxValue;
                int min_Index = -1;
                int iteration = 0;

                MinimumDistance(distances, tree, min, ref min_Index, Nodes, iteration);

                int u = min_Index;

                tree[u] = true;

                for (int j = 0; j < Nodes; j++)
                {
                    if (routing.Count - 1 < j)
                    {
                        routing.Add(new Routing());
                    }

                    if (!tree[j] && graph[u, j] != 0 && distances[u] != int.MaxValue && distances[u] + graph[u, j] < distances[j])
                    {
                        distances[j] = distances[u] + graph[u, j];

                        routing[j].Add(u);

                    }
                }
            }


            return distances;
        }

        /// <summary>
        /// Creates a graph from all <paramref name="towns"/> and <paramref name="routes"/>
        /// </summary>
        /// <param name="towns">List of towns to add</param>
        /// <param name="routes">List of routes to add</param>
        /// <returns>Returns graph of all towns and routes</returns>
        public static int[,] CreateGraph(List<Town> towns, List<Route> routes)
        {
            int[,] graph = new int[towns.Count, towns.Count];

            foreach (Route route in routes)
            {
                for (int i = 0; i < towns.Count - 1; i++)
                {
                    for (int j = 0; j < towns.Count; j++)
                    {
                        if (route.Start == towns[i].Name && route.End == towns[j].Name)
                        {
                            graph[i, j] = route.Distance;
                        }
                    }
                }
            }

            return graph;
        }

        /// <summary>
        /// Converts human readable town name to town id
        /// </summary>
        /// <param name="town">Town name to convert</param>
        /// <param name="towns">List of all towns to convert by</param>
        /// <returns>Returns id of town</returns>
        public static int TownToInt(string town, List<Town> towns)
        {
            for (int i = 0; i < towns.Count; i++)
            {
                if (town == towns[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Converts town id to human readable town name
        /// </summary>
        /// <param name="town">Town id to convert</param>
        /// <param name="towns">List of all towns to convert by</param>
        /// <returns>Returns human readable string of town</returns>
        public static string TownToString(int town, List<Town> towns)
        {
            for (int i = 0; i < towns.Count; i++)
            {
                if (town == i)
                {
                    return towns[i].Name;
                }
            }
            return "not found";
        }

        /// <summary>
        /// Gets the route by <paramref name="destination"/>
        /// </summary>
        /// <param name="distances">All distances from source</param>
        /// <param name="destination">Destination of route</param>
        /// <param name="towns">List of all towns</param>
        /// <returns></returns>
        public static int GetCorrectRoute(int[] distances, int destination, List<Town> towns)
        {
            for (int i = 0; i < distances.Length; i++)
            {
                if (i == destination)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}