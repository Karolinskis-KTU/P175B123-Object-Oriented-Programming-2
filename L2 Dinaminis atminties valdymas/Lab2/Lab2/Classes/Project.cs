using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Classes
{
    public class Project
    {
        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname of the person responsible of the project
        /// </summary>
        public string ProfSurname { get; set; }
        /// <summary>
        /// Name of the person responsible of the project
        /// </summary>
        public string ProfName { get; set; }
        /// <summary>
        /// Given time to finish project
        /// </summary>
        public int GivenTime { get; set; }

        /// <summary>
        /// Constructor to create Project
        /// </summary>
        /// <param name="name">Project name</param>
        /// <param name="profSurname">Surname of the person responsible of the project</param>
        /// <param name="profName">Name of the person responsible of the project</param>
        /// <param name="givenTime">Given time to finish project</param>
        public Project(string name = "", string profSurname = "", string profName = "", int givenTime = 0)
        {
            this.Name = name;
            this.ProfSurname = profSurname;
            this.ProfName = profName;
            this.GivenTime = givenTime;
        }

        /// <summary>
        /// Compare two Project classes by their person's name and surname
        /// </summary>
        /// <param name="other">Other project</param>
        /// <returns></returns>
        public int CompareTo(Project other)
        {
            if (ProfSurname.CompareTo(other.ProfSurname) == 0)
            {
                return ProfName.CompareTo(other.ProfName);
            }
            return ProfSurname.CompareTo(other.ProfSurname);
        }
    }
}