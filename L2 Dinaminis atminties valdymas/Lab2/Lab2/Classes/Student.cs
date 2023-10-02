using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Classes
{
    public class Student
    {
        /// <summary>
        /// Student's chosen project name
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Student's surname 
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Student's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Student's academic group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Constructor to create Student class
        /// </summary>
        /// <param name="projectName">Student's chosen project name</param>
        /// <param name="surname">Student's surname</param>
        /// <param name="name">Student's name</param>
        /// <param name="group">Student's academic group</param>
        public Student(string projectName = "", string surname = "", string name = "", string group = "")
        {
            this.ProjectName = projectName;
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
        }
    }
}