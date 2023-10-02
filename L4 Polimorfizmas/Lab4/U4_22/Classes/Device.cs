using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U4_22.Classes
{
    public abstract class Device : IComparable<Device>, IEquatable<Device>
    {
        

        /// <summary>
        /// Device manufacturer name
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Device model name
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Energy class rating of device
        /// </summary>
        public string EnergyClass { get; set; }
        /// <summary>
        /// Device color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Device price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Device constructor
        /// </summary>
        /// <param name="manufacturer">Device manufacturer name</param>
        /// <param name="model">Device model name</param>
        /// <param name="energyClass">Energy class rating of device</param>
        /// <param name="color">Device color</param>
        /// <param name="price">Device price</param>
        public Device(string manufacturer, string model, string energyClass, string color, decimal price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.EnergyClass = energyClass;
            this.Color = color;
            this.Price = price;
        }
        public abstract int CompareTo(Device other);
        public abstract bool Equals(Device other);
        public abstract List<string> ParamArray();
        public abstract override string ToString();
        public abstract List<string> ToStringArray();
        public abstract string ToCSVString();
    }
}