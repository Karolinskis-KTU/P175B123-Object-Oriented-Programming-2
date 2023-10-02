using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.src
{
    public class Routing
    {
        public int[] routing;
        private int Capacity;
        
        /// <summary>
        /// Shows how many cities route takes
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates new routing array for container
        /// </summary>
        /// <param name="capacity">Size of container</param>
        public Routing(int capacity = 8)
        {
            this.routing = new int[capacity];
        }

        /// <summary>
        /// Adds data to container
        /// </summary>
        /// <param name="container">Container data to add</param>
        public Routing(Routing container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        public bool CityExists(int cityID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (routing[i] == cityID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// If neede ads more capacity to routing array
        /// </summary>
        /// <param name="minimumCapacity">minimum capacity neeed for the array</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                int[] temp = new int[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.routing[i];
                }
                this.Capacity = minimumCapacity;
                this.routing = temp;
            }
        }

        /// <summary>
        /// Adds city to container
        /// </summary>
        /// <param name="cityID">City to add</param>
        public void Add(int cityID)
        {
            if (this.Count == this.Capacity) // container full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            if (CityExists(cityID) == false) // Checks if the same city exists in container
            {
                this.routing[this.Count++] = cityID;
            }

        }

        /// <summary>
        /// Removes city from array at <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to remove at</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.routing[i] = this.routing[i + 1];
            }
        }

        /// <summary>
        /// Gets city element from array with <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to get by</param>
        /// <returns>City in routing</returns>
        public int Get(int index)
        {
            return this.routing[index];
        }
    }
}