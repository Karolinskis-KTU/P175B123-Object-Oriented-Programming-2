using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3.Classes
{
    public class InOut
    {
        /// <summary>
        /// Reads Project data file
        /// </summary>
        /// <param name="fileName">File path to read from</param>
        /// <returns>Returns a sorted ProjectLinkedlist</returns>
        public static LinkList<Project> ReadProjectFile(string fileName)
        {
            LinkList<Project> l = new LinkList<Project>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string Line in Lines)
            {
                string[] data = Line.Split(',');
                string Name = data[0];
                string ProfSurname = data[1];
                string ProfName = data[2];
                int GivenTime = Int32.Parse(data[3]);

                Project temp = new Project(Name, ProfSurname, ProfName, GivenTime);

                l.Add(temp);
                l.Sort();
            }
            return l;
        }

        /// <summary>
        /// Reads Student data file
        /// </summary>
        /// <param name="fileName">File path to read from</param>
        /// <returns>Student linkedList</returns>
        public static LinkList<Student> ReadStudentFile(string fileName)
        {
            LinkList<Student> l = new LinkList<Student>();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                string ProjectName = data[0];
                string Surname = data[1];
                string Name = data[2];
                string Group = data[3];

                Student temp = new Student(ProjectName, Surname, Name, Group);

                l.Add(temp);
            }
            return l;
        }

        /// <summary>
        /// Dumps all Project data to file
        /// </summary>
        /// <param name="fileName">File path to dump to</param>
        /// <param name="list">Project linkedList</param>
        public static void DumpProjectFile(string fileName, LinkList<Project> list)
        {
            string line = new string('-', 98);


            List<String> Lines = new List<string>
            {
                line,
                string.Format($"| {"Project name",-35} | {"Proffesor surname",-20} | {"Proffesor name",-20} | {"Given time",-10} |"),
                line
            };

            foreach (Project project in list)
            {
                Lines.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            Lines.Add(line);
            File.WriteAllLines(fileName, Lines);
        }

        /// <summary>
        /// Dumps all Student data to file
        /// </summary>
        /// <param name="fileName">File path to dump to</param>
        /// <param name="list">Student linkedList</param>
        public static void DumpStudentFile(string fileName, LinkList<Student> list)
        {
            string line = new string('-', 81);

            List<String> Lines = new List<string>
            {
                line,
                string.Format($"| {"Project name",-20} | {"Surname",-20} | {"Name",-20} | {"Group",-8} |"),
                line
            };

            foreach (var item in list)
            {
                Lines.Add(string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,8} |", item.Name, item.Surname, item.Name, item.Group));
            }


            Lines.Add(line);
            File.WriteAllLines(fileName, Lines);
        }
    }
}