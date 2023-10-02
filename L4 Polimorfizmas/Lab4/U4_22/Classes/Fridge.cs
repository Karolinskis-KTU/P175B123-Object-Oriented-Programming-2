using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U4_22.Classes
{
    public class Fridge : Device, IComparable<Device>, IEquatable<Device>
    {
        /// <summary>
        /// Capacity of fridge in liters
        /// </summary>
        public decimal Capacity { get; set; }
        /// <summary>
        /// Mounting type of fridge
        /// </summary>
        public string MountingType { get; set; }
        /// <summary>
        /// Fridge has freezer or not
        /// </summary>
        public Freezer HasFreezer { get; set; }
        /// <summary>
        /// Height of fridge 
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Width of fridge
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Depth of fridge
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Constructor to create Fridge
        /// </summary>
        /// <param name="manufacturer">Manufacturer of the device</param>
        /// <param name="model">Model name of the device</param>
        /// <param name="energyClass">Energy class of the device</param>
        /// <param name="color">Color of the device</param>
        /// <param name="price">Price of the device</param>
        /// <param name="capacity">Capacity of fridge in liters</param>
        /// <param name="mountingType">Mounting type of fridge</param>
        /// <param name="hasFreezer">Fridge has freezer or not</param>
        /// <param name="height">Height of fridge</param>
        /// <param name="width">Width of fridge</param>
        /// <param name="depth">Depth of fridge</param>
        public Fridge(string manufacturer, string model, string energyClass, string color, decimal price, decimal capacity, string mountingType, Freezer hasFreezer, int height, int width, int depth) : base(manufacturer, model, energyClass, color, price)
        {
            this.Capacity = capacity;
            this.MountingType = mountingType;
            this.HasFreezer = hasFreezer;
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }

        /// <summary>
        /// Compares <paramref name="other"/> kettle to current based on height
        /// </summary>
        /// <param name="other">Kettle to compare to</param>
        /// <returns></returns>
        public override int CompareTo(Device other)
        {
            if (other is Fridge)
            {
                Fridge fridge = other as Fridge;
                return this.Height.CompareTo(fridge.Height);
            } else
            {
                return -1;
            }

        }

        /// <summary>
        /// Check if the <paramref name="other"/> kettle has the same height
        /// </summary>
        /// <param name="other">Kettle to compare to</param>
        /// <returns>Returns true if both kettles have the same height | Otherwise false</returns>
        public override bool Equals(Device other)
        {
            Fridge fridge = other as Fridge;
            return this.Height == fridge.Height;
        }

        /// <summary>
        /// Get Fridge paramater names
        /// </summary>
        /// <returns>Returns a string representation of parameters</returns>
        public override List<string> ParamArray()
        {
            return new List<string>() { "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Šaldiklis?", "Aukšis", "Plotis", "Gylis"};
        }

        /// <summary>
        /// Puts all Fridge data to single line
        /// </summary>
        /// <returns>string with formated fridge data</returns>
        public override string ToString()
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";

            return String.Format(spacing, "Šaldytuvas", this.Manufacturer, this.Model, this.EnergyClass, this.Color, this.Price, this.Capacity, this.MountingType, this.HasFreezer, this.Height, this.Width, this.Depth, "-", "-");
        }

        /// <summary>
        /// Convert Fridge data to List<string>
        /// </summary>
        /// <returns>Returns a string representation of the oven</returns>
        public override List<string> ToStringArray()
        {
            return new List<string>() { Manufacturer, Model, EnergyClass, Color, Price.ToString(), Capacity.ToString(), MountingType, HasFreezer.ToString(), Height.ToString(), Width.ToString(), Depth.ToString() };
        }

        /// <summary>
        /// Convert Fridge data to csv string
        /// </summary>
        /// <returns>Returns oven data converted to string</returns>
        public override string ToCSVString()
        {
            return string.Join(";", "Šaldytuvas", Manufacturer, Model, EnergyClass, Color, Price, Capacity, MountingType, HasFreezer, Height, Width, Depth);
        }

    }
}