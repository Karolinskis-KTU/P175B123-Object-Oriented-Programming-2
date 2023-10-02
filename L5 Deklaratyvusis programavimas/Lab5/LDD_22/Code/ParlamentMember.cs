using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LDD_22.Code
{
    public class ParlamentMember
    {
        /// <summary>
        /// Surname of parlament member
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Name of parlament member
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date when parlament member is on-call
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Time from when parlament member is on-call
        /// </summary>
        public DateTime OnCallStart { get; set; }
        /// <summary>
        /// Time to when parlament member is on-call
        /// </summary>
        public DateTime OnCallEnd { get; set; }

        /// <summary>
        /// Parlament member constructor
        /// </summary>
        /// <param name="surname">Surname of parlament member</param>
        /// <param name="name">Name of parlament member</param>
        /// <param name="date">Date when parlament member is on-call</param>
        /// <param name="onCallStart">Time from when parlament member is on-call</param>
        /// <param name="onCallEnd">Time to when parlament member is on-call</param>
        public ParlamentMember(string surname, string name, DateTime date, DateTime onCallStart, DateTime onCallEnd)
        {
            Surname = surname;
            Name = name;
            Date = date;
            OnCallStart = onCallStart;
            OnCallEnd = onCallEnd;
        }

        /// <summary>
        /// Puts all the data of the ParlamentMember in a string
        /// </summary>
        /// <returns>a list of all data names</returns>
        public List<string> GetDataNames()
        {
            return new List<string>()
            {
                "Pavardė",
                "Vardas",
                "Budėjimo data",
                "Budėjimo pradžia",
                "Budejimo pabaiga"
            };
        }

        /// <summary>
        /// Putsa all ParlamentMember data to List<string>
        /// </summary>
        /// <returns>Returns a List<string> representation of consultation data</returns>
        public List<string> ToStringArray()
        {
            return new List<string> { Surname, Name, Date.ToString("yyyy-MM-dd"), OnCallStart.ToString("HH:mm"), OnCallEnd.ToString("HH:mm") };
        }
    }
}