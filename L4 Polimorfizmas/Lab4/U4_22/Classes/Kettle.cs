using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U4_22.Classes
{
    public class Kettle : Device, IComparable<Device>, IEquatable<Device>
    {
        /// <summary>
        /// Ammount of power that the kettle has
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Ammount of water that can fit in the kettle
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Constructor to create a Kettle
        /// </summary>
        /// <param name="manufacturer">Manufacturer of the device</param>
        /// <param name="model">Model name of the device</param>
        /// <param name="energyClass">Energy class of the device</param>
        /// <param name="color">Color of the device</param>
        /// <param name="price">Price of the device</param>
        /// <param name="power">Ammount of power that the kettle has</param>
        /// <param name="volume">Ammount of water that can fit in the kettle</param>
        public Kettle(string manufacturer, string model, string energyClass, string color, decimal price, int power, int volume) : base(manufacturer, model, energyClass, color, price)
        {
            this.Power = power;
            this.Volume = volume;
        }

        /// <summary>
        /// Compares <paramref name="other"/> kettle to current based on power rating
        /// </summary>
        /// <param name="other">Kettle to compare to</param>
        /// <returns></returns>
        public override int CompareTo(Device other)
        {
            if (other is Kettle)
            {
                Kettle kettle = other as Kettle;
                return this.Power.CompareTo(kettle.Power);
            } else
            {
                return -1;
            }

        }

        /// <summary>
        /// Check if the <paramref name="other"/> kettle has the same power
        /// </summary>
        /// <param name="other">Kettle to compare to</param>
        /// <returns>Returns true if both kettles have the same power rating | Otherwise false</returns>
        public override bool Equals(Device other)
        {
            Kettle kettle = other as Kettle;
            return this.Power == kettle.Power;
        }

        /// <summary>
        /// Get Kettle paramater names
        /// </summary>
        /// <returns>Returns a string representation of parameters</returns>
        public override List<string> ParamArray()
        {
            return new List<string>() { "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Galia", "Talpa"};
        }

        /// <summary>
        /// Puts all Kettle data to single line
        /// </summary>
        /// <returns>string with formated Kettle data</returns>
        public override string ToString()
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";

            return String.Format(spacing, "Virdulys", this.Manufacturer, this.Model, this.EnergyClass, this.Color, this.Price, this.Volume, "-", "-", "-", "-", "-", this.Power, "-");
        }

        /// <summary>
        /// Convert Kettle data to List<string>
        /// </summary>
        /// <returns>Returns a string representation of the kettle</returns>
        public override List<string> ToStringArray()
        {
            return new List<string>() { Manufacturer, Model, EnergyClass, Color, Price.ToString(), Power.ToString(), Volume.ToString() };
        }

        /// <summary>
        /// Convert Kettle data to csv string
        /// </summary>
        /// <returns>Returns oven data converted to string</returns>
        public override string ToCSVString()
        {
            return string.Join(";", "Virdulys", this.Manufacturer, this.Model, this.EnergyClass, this.Color, this.Price, this.Power, this.Volume);
        }
    }
}