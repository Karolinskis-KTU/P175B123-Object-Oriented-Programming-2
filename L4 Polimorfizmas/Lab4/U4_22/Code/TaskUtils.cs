using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using U4_22.Classes;

namespace U4_22.Code
{
    public class TaskUtils
    {

        /// <summary>
        /// Finds all devices in <paramref name="store"/> that have above minimum prices
        /// </summary>
        /// <param name="store">Store to check</param>
        /// <param name="minFridge">Minimum price of fridge</param>
        /// <param name="minOven">Minimum price of oven</param>
        /// <param name="minKettle">Minimum price of kettle</param>
        /// <returns>Returns all devices that are above minimum prices</returns>
        public static List<Device> FindAllDevicesAbovePrices(Store store, decimal minFridge, decimal minOven, decimal minKettle)
        {
            List<Device> result = new List<Device>();
            for (int i = 0; i < store.Count(); i++)
            {
                var device = store.Get(i);
                if (device is Fridge)
                {
                    var fridge = device as Fridge;
                    if (fridge.Price > minFridge)
                    {
                        result.Add(device);
                    }
                }
                else if (device is Kettle)
                {
                    var kettle = device as Kettle;
                    if (kettle.Price > minKettle)
                    {
                        result.Add(device);
                    }
                }
                else if (device is Oven)
                {
                    var oven = device as Oven;
                    if (oven.Price > minOven)
                    {
                        result.Add(device);
                    }
                }
                
            }
            return result;
        }
    }
}