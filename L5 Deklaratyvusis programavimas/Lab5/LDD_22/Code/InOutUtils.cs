using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;

namespace LDD_22.Code
{
    public static class InOutUtils
    {
        /// <summary>
        /// Gets all valid parlament members in a file
        /// </summary>
        /// <param name="fileName">name of the file to read</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws if a line doesn't have the correct ammount of data for ParlamentMember class</exception>
        public static List<ParlamentMember> GetParlamentMembers(string fileName)
        {
            List<ParlamentMember> parlamentMembers = new List<ParlamentMember>();

            foreach (var line in File.ReadLines(fileName, Encoding.UTF8))
            {
                string[] parts = line.Split(';');
                if (parts.Length != 5)
                {
                    throw new Exception($"Invalid parlament member line '{line}'");
                }
                string surname = parts[0].Trim();
                string name = parts[1].Trim();
                DateTime date = DateTime.Parse(parts[2]);
                DateTime onCallStart = DateTime.Parse(parts[3]);
                DateTime onCallEnd = DateTime.Parse(parts[4]);

                parlamentMembers.Add(new ParlamentMember(surname, name, date, onCallStart, onCallEnd));
            }

            return parlamentMembers;
        }

        /// <summary>
        /// Gets all valid admissions in a file.
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws if a line doesn't have the correct ammount of data for Admission class</exception>
        private static List<Consultation> GetConsultations(string fileName)
        {
            List<Consultation> consultations = new List<Consultation>();

            var lines = File.ReadAllLines(fileName, Encoding.UTF8);

            DateTime consultationsDate = DateTime.Parse(lines.First()); // LINQ <---

            foreach (var line in lines.Skip(1)) // LINQ <----
            {
                string[] parts = line.Split(';');
                if (parts.Length != 4)
                {
                    throw new Exception($"Neteisinga priėmimo eilutė: '{line}' {parts.Length}");
                }

                string surname = parts[0].Trim();
                string name = parts[1].Trim();
                DateTime arrivalTime = DateTime.Parse(parts[2]);
                DateTime consultationTime = DateTime.Parse(parts[3]);

                consultations.Add(new Consultation(consultationsDate, surname, name, arrivalTime, consultationTime));

            }

            return consultations;
        }

        /// <summary>
        /// Gets all filenames in consultation folder.
        /// </summary>
        /// <param name="folder">Folder to read</param>
        /// <param name="pattern">File extension to find</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws if <paramref name="folder"/> is not found</exception>
        public static List<List<Consultation>> GetConsultationsDir(string folder, string pattern = "*.txt")
        {
            if (!Directory.Exists(folder))
            {
                throw new Exception($"Nerastas aplankalas: '{folder}'");
            }

            var consultations = new List<List<Consultation>>();
            foreach (var fileName in Directory.GetFiles(folder, pattern))
            {
                consultations.Add(GetConsultations(fileName));
            }

            return consultations;
        }

        /// <summary>
        /// Writes all <paramref name="consultations"/> to txt file
        /// </summary>
        /// <param name="fileName">File to write to</param>
        /// <param name="consultations">Consultations to write</param>
        public static void WriteConsultationsToTxtFile(string fileName, List<Consultation> consultations)
        {
            string spacing = "| {0, -20} | {1, -20} | {2, -20} | {3, -20} |";
            string dashes = new string('-', 93);
            
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("Data: {0}", consultations.First().Date.ToString("MM-dd")); // LINQ <---
                writer.WriteLine(dashes);
                writer.WriteLine(spacing, "Pavardė", "Vardas", "Atvykimo laikas", "Konsultacijos laikas");
                writer.WriteLine(dashes);
                foreach (var consultation in consultations)
                {
                    string arrivalTime = consultation.ArrivalTime.ToString("HH:mm");
                    string consultationTime = consultation.ConsultationTime.ToString("HH:mm");

                    writer.WriteLine(spacing, consultation.Surname, consultation.Name, arrivalTime, consultationTime);
                }
                writer.WriteLine(dashes);
            }
        }

        /// <summary>
        /// Writes all <paramref name="parlamentMembers"/> to txt file
        /// </summary>
        /// <param name="fileName">File to write to</param>
        /// <param name="parlamentMembers">Parlament members to write</param>
        public static void WriteParlamentMemberToTxtFile(string fileName, List<ParlamentMember> parlamentMembers)
        {
            string spacing = "| {0, -20} | {1, -20} | {2, -20} | {3, -20} | {4, -20} |";
            string dashes = new string('-', 116);

            using (var writter = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writter.WriteLine(dashes);
                writter.WriteLine(spacing, "Pavardė", "Vardas", "Dienos data", "Budėjimo pradžia", "Budėjimo pabaiga");
                writter.WriteLine(dashes);

                foreach (var parlamentMember in parlamentMembers)
                {
                    string date = parlamentMember.Date.ToString("MM-dd");
                    string onCallStart = parlamentMember.OnCallStart.ToString("HH:mm");
                    string onCallEnd = parlamentMember.OnCallEnd.ToString("HH:mm");

                    writter.WriteLine(spacing, parlamentMember.Surname, parlamentMember.Name, date, onCallStart, onCallEnd);
                }
                writter.WriteLine(dashes);
            }
        }

       /// <summary>
       /// Creates row for table
       /// </summary>
       /// <param name="list">List to append to cells</param>
       /// <returns>Created row</returns>
        public static TableRow MakeRow(List<string> list)
        {
            TableRow row = new TableRow();

            foreach (var item in list)
            {
                row.Cells.Add(new TableCell { Text = item });
            }

            return row;
        }

        /// <summary>
        /// Makes a TableRow with a cell <paramref name="data"/>
        /// </summary>
        /// <param name="data">Data to add to row</param>
        /// <returns>Returns a TableRow with <paramref name="data"/></returns>
        public static TableRow MakeRow(string data)
        {
            TableRow row = new TableRow();

            row.Cells.Add(new TableCell { Text = data });

            return row;
        }

        /// <summary>
        /// Makes a TableRow with cells containing all provided <paramref name="data"/>
        /// </summary>
        /// <param name="data1">Data to add to first cell</param>
        /// <param name="data2">Data to add to second cell</param>
        /// <param name="data3">Data to add to third cell</param>
        /// <param name="data4">Data to add to fourth cell</param>
        /// <returns>Returns a TableRow with all provided <paramref name="data"/></returns>
        public static TableRow MakeRow(string data1, string data2, string data3, string data4)
        {
            TableRow row = new TableRow();

            row.Cells.Add(new TableCell { Text = data1 });
            row.Cells.Add(new TableCell { Text = data2 });
            row.Cells.Add(new TableCell { Text = data3 });
            row.Cells.Add(new TableCell { Text = data4 });

            return row;
        }
    }
}