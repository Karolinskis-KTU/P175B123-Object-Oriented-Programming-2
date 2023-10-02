using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.src
{
    public class Town
    {
        /// <summary>
        /// Name of the town
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ID of town
        /// </summary>
        public int Num { get; set; }

        public DataOutput DataOutput
        {
            get => default;
            set
            {
            }
        }

        public Town(string name, int num)
        {
            Name = name;
            Num = num;
        }
    }
}