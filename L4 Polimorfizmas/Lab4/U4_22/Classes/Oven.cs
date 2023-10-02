using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U4_22.Classes
{
    public class Oven : Device, IComparable<Device>, IEquatable<Device>
    {
        /// <summary>
        /// Power of oven
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Ammmount of programs the oven has
        /// </summary>
        public int ProgramCount { get; set; }

        /// <summary>
        /// Constructor to create Oven 
        /// </summary>
        /// <param name="manufacturer">Manufacturer of the device</param>
        /// <param name="model">Model name of the device</param>
        /// <param name="energyClass">Energy class of the device</param>
        /// <param name="color">Color of the device</param>
        /// <param name="price">Price of the device</param>
        /// <param name="power">Power rating of the oven</param>
        /// <param name="programCount">Ammount of different programs the oven has</param>
        public Oven(string manufacturer, string model, string energyClass, string color, decimal price, int power, int programCount) : base(manufacturer, model, energyClass, color, price)
        {
            this.Power = power;
            this.ProgramCount = programCount;
        }

        /// <summary>
        /// Compares <paramref name="other"/> Oven to current based on power rating
        /// </summary>
        /// <param name="other">Oven to compare to</param>
        /// <returns></returns>
        public override int CompareTo(Device other)
        {
            if (other is Oven)
            {
                Oven oven = other as Oven;
                return this.Power.CompareTo(oven.Power);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Check if the <paramref name="other"/> oven has the same power
        /// </summary>
        /// <param name="other">Oven to compare to</param>
        /// <returns>Returns true if both ovens have the same power rating | Otherwise false</returns>
        public override bool Equals(Device other)
        {
            Oven oven = other as Oven;
            return this.Power == oven.Power;
        }

        /// <summary>
        /// Get Kettle paramater names
        /// </summary>
        /// <returns>Returns a string representation of parameters</returns>
        public override List<string> ParamArray()
        {
            return new List<string>() { "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Galia", "Programų skaičius"};
        }

        /// <summary>
        /// Puts all Oven data to single line
        /// </summary>
        /// <returns>string with formated Oven data</returns>
        public override string ToString()
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";

            return String.Format(spacing, "Mikrobanginė", this.Manufacturer, this.Model, this.EnergyClass, this.Color, this.Price, "-", "-", "-", "-", "-", "-", this.Power, this.ProgramCount);

        }

        /// <summary>
        /// Convert Oven to List<string>
        /// </summary>
        /// <returns>Returns a string representation of the oven</returns>
        public override List<string> ToStringArray()
        {
            return new List<string>() { Manufacturer, Model, EnergyClass, Color, Price.ToString(), Power.ToString(), ProgramCount.ToString() };
        }

        /// <summary>
        /// Convert Oven data to csv string
        /// </summary>
        /// <returns>Returns oven data converted to string</returns>
        public override string ToCSVString()
        {
            return string.Join(";", "Mikrobanginė", this.Manufacturer, this.Model, this.EnergyClass, this.Color, this.Price, this.Power, this.ProgramCount);
        }
    }
}