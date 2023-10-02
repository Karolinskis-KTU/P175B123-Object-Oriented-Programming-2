using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U4_22.Classes
{
    public class Store
    {
        /// <summary>
        /// Name of the store
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Adress of the store
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Phone number of the store
        /// </summary>
        public string Phone { get; set; }

        private List<Device> Devices = new List<Device>();
        
        /// <summary>
        /// Creates new store
        /// </summary>
        public Store()
        {
            this.Devices = new List<Device>();
        }

        public void Add(Store store)
        {
            for (int i = 0; i < store.Count(); i++)
            {
                Device device = store.Get(i);
                this.Devices.Add(device);
            }
        }

        /// <summary>
        /// Adds device data to store
        /// </summary>
        /// <param name="device">Device to add</param>
        public void Add(Device device)
        {
            Devices.Add(device);
        }

        /// <summary>
        /// Gives the ammount of items in store
        /// </summary>
        /// <returns>Returns integer of items</returns>
        public int Count()
        {
            return Devices.Count();
        }

        /// <summary>
        /// Gets device element from store
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Returns device</returns>
        public Device Get(int index)
        {
            return Devices[index];
        }
       
        public void Sort()
        {
            Devices.Sort();
        }

        /// <summary>
        /// Get all fridges that are in the store
        /// </summary>
        /// <returns>Returns all fridges</returns>
        public List<Fridge> GetFridges()
        {
            List<Fridge> fridges = new List<Fridge>();
            foreach (var device in Devices)
            {
                if (device is Fridge)
                {
                    fridges.Add(device as Fridge);
                }
            }

            return fridges;
        }

        /// <summary>
        /// Get all kettles that are in the store
        /// </summary>
        /// <returns>Returns all kettles</returns>
        public List<Kettle> GetKettles()
        {
            List<Kettle> kettles = new List<Kettle>();
            foreach (var device in Devices)
            {
                if (device is Kettle)
                {
                    kettles.Add(device as Kettle);
                }
            }

            return kettles;
        }

        /// <summary>
        /// Get all ovens that are in the store
        /// </summary>
        /// <returns>Returns all ovens</returns>
        public List<Oven> GetOvens()
        {
            List<Oven> ovens = new List<Oven>();
            foreach (var device in Devices)
            {
                if (device is Oven)
                {
                    ovens.Add(device as Oven);
                }
            }

            return ovens;
        }

        /// <summary>
        /// Finds all different colors that this type of device has
        /// </summary>
        /// <param name="type">Type of device</param>
        /// <returns>List of all different colors</returns>
        public List<string> AllColorsByDeviceType(string type)
        {
            List<string> colors = new List<string>();

            foreach (var device in Devices)
            {
                if (device.GetType().Name == type)
                {
                    string color = device.Color;
                    if (!colors.Contains(device.Color))
                    {
                        colors.Add(color);
                    }
                }
            }

            return colors;
        }

        /// <summary>
        /// Finds all fridges that has a width <paramref name="from"/> x <paramref name="to"/> x
        /// </summary>
        /// <param name="from">From what size to check</param>
        /// <param name="to">To what size to check</param>
        /// <returns>List of all fridges</returns>
        public List<Device> AllFridgesBetweenWidth(int from, int to)
        {
            List<Device> fridges = new List<Device>();

            foreach (var device in Devices)
            {
                if (device is Fridge)
                {
                    Fridge fridge = (Fridge)device;
                    if (fridge.Width >= from && fridge.Width <= to)
                    {
                        fridges.Add(fridge);
                    }
                }
            }

            return fridges;
        }

        /// <summary>
        /// Finds cheapest fridge by <paramref name="rating"/>
        /// </summary>
        /// <param name="store">Store to check</param>
        /// <param name="rating">Rating to compare by</param>
        /// <returns>Cheapest fridge in <paramref name="rating"/> class</returns>
        public Fridge FindCheapestFridgeByRating(string rating="A+")
        {
            Fridge cheapestFridge = null;
            decimal cheapestPrice = decimal.MaxValue;

            foreach (var device in Devices)
            {
                if (device is Fridge)
                {
                    Fridge fridge = (Fridge)device;
                    if (device.Price < cheapestPrice && device.EnergyClass == rating)
                    {
                        cheapestFridge = fridge;
                        cheapestPrice = device.Price;
                    }
                }
            }

            return cheapestFridge;
        }

        /// <summary>
        /// Finds cheapest fridge by <paramref name="rating"/>
        /// </summary>
        /// <param name="store">Store to check</param>
        /// <param name="rating">Rating to compare by</param>
        /// <returns>Cheapest fridge in <paramref name="rating"/> class</returns>
        public Kettle FindCheapestKettleByRating(string rating = "A+")
        {
            Kettle cheapestKettle = null;
            decimal cheapestPrice = decimal.MaxValue;

            foreach (var device in Devices)
            {
                if (device is Kettle)
                {
                    Kettle kettle = (Kettle)device;
                    if (device.Price < cheapestPrice && device.EnergyClass == rating)
                    {
                        cheapestKettle = kettle;
                        cheapestPrice = device.Price;
                    }
                }
            }

            return cheapestKettle;
        }

        /// <summary>
        /// Finds cheapest oven by <paramref name="rating"/>
        /// </summary>
        /// <param name="store">Store to check</param>
        /// <param name="rating">Rating to compare by</param>
        /// <returns>Cheapest oven in <paramref name="rating"/> class</returns>
        public Oven FindCheapestOvenByRating(string rating = "A+")
        {
            Oven cheapestOven = null;
            decimal cheapestPrice = decimal.MaxValue;

            foreach (var device in Devices)
            {
                if (device is Oven)
                {
                    Oven oven = (Oven)device;
                    if (device.Price < cheapestPrice && device.EnergyClass == rating)
                    {
                        cheapestOven = oven;
                        cheapestPrice = device.Price;
                    }
                }
            }

            return cheapestOven;
        }
    }
}