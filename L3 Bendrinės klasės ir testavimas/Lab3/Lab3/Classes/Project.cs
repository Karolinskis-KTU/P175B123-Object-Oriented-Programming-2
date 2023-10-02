using System;
using System.Collections.Generic;

namespace Lab3.Classes
{
    public class Project : IComparable<Project>, IEquatable<Project>
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

        /// <summary>
        /// Checks if two project objects are equal
        /// </summary>
        /// <param name="obj">Project object to compare to</param>
        /// <returns>True if both Projects are equal | False if not</returns>
        public bool Equals(Project obj)
        {
            if (obj == null)
                return false;

            return obj is Project project &&
                   Name == project.Name &&
                   ProfSurname == project.ProfSurname &&
                   ProfName == project.ProfName &&
                   GivenTime == project.GivenTime;
        }

        /// <summary>
        /// Gets the hash code of the object
        /// </summary>
        /// <returns>Returns the object as a hash code</returns>
        public override int GetHashCode()
        {
            int hashCode = -929970343;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProfSurname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProfName);
            hashCode = hashCode * -1521134295 + GivenTime.GetHashCode();
            return hashCode;
        }



    }
}