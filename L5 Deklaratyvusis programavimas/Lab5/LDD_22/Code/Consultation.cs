using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LDD_22.Code
{
    public class Consultation
    {
        /// <summary>
        /// Admission day
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Person's surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Person's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Time person arrived at the consultation
        /// </summary>
        public DateTime ArrivalTime { get; set; }
        /// <summary>
        /// Length of consultation
        /// </summary>
        public DateTime ConsultationTime { get; set; }

        /// <summary>
        /// Constructor of Admission
        /// </summary>
        /// <param name="date">Admission day</param>
        /// <param name="surname">Person's surname</param>
        /// <param name="name">Person's name</param>
        /// <param name="arrivalTime">Time person arrived at the consultation</param>
        /// <param name="consultaionTime">Length of consultation</param>
        public Consultation(DateTime date, string surname, string name, DateTime arrivalTime, DateTime consultationTime)
        {
            Date = date;
            Surname = surname;
            Name = name;
            ArrivalTime = arrivalTime;
            ConsultationTime = consultationTime;
        }

        /// <summary>
        /// Puts all the data of the consultation in a string
        /// </summary>
        /// <returns>a list of all data names</returns>
        public List<string> GetDataNames()
        {
            return new List<string>()
            {
                "Pavardė",
                "Vardas",
                "Atvykimo laikas",
                "Konsultacijos trukmė"
            };
        }

        /// <summary>
        /// Puts all Consultation data to List<string>
        /// </summary>
        /// <returns>Returns a List<string> representation of consultation data</returns>
        public List<string> ToStringArray()
        {
            return new List<string>() { Surname, Name, ArrivalTime.ToString("HH:mm"), ConsultationTime.ToString("HH:mm") };
        }

    }
}