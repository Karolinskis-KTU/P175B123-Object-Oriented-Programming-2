using System;
using System.Collections.Generic;

namespace Lab3.Classes
{
    public class Student : IEquatable<Student>, IComparable<Student>
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

        public int CompareTo(Student other)
        {
            return this.Surname.CompareTo(other.Surname);
        }

        public bool Equals(Student student)
        {
            return ProjectName == student.ProjectName &&
                   Surname == student.Surname &&
                   Name == student.Name &&
                   Group == student.Group;
        }

        public override int GetHashCode()
        {
            int hashCode = -1095595683;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProjectName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Group);
            return hashCode;
        }
    }
}