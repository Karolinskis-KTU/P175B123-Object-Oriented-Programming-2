using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Diagnostics;

using U4_22.Classes;
using U4_22;

namespace U4_22.Code
{
    public class InOutUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Reads a file and returns the content as a string.
        /// </summary>
        /// <param name="fileName">File to read</param>
        /// <returns>Returns file content as a string</returns>
        private static List<string> ReadLines (string fileName)
        {
            List<string> lines = new List<string>();

            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > 0) // If line is not empty
                    {
                        lines.Add(line);
                    }

                }
            }
            
            return lines;
        }

        /// <summary>
        /// Reads store data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static Store ReadDevices(string fileName)
        {
            var lines = ReadLines(fileName);

            var store = new Store();

            var shopName = lines.First().Trim();
            var adress = lines.Skip(1).First().Trim();
            var phoneNumber = lines.Skip(2).First().Trim();

            store.Name = shopName;
            store.Adress = adress;
            store.Phone = phoneNumber;

            foreach (var line in lines.Skip(3))
            {
                string[] parts = line.Split(';');

                string manufacturer = parts[1].Trim();
                string model = parts[2].Trim();
                string energyClass = parts[3].Trim();
                string color = parts[4].Trim();
                int price = int.Parse(parts[5].Trim());

                string type = parts[0]; // Device type

                switch (type)
                {
                    case "OVEN":
                        int power = int.Parse(parts[6].Trim());
                        int programCount = int.Parse(parts[7].Trim());

                        store.Add(new Oven(manufacturer, model, energyClass, color, price, power, programCount));

                        break;

                    case "KETTLE":
                        int power2 = int.Parse(parts[6].Trim());
                        int volume = int.Parse(parts[7].Trim());

                        store.Add(new Kettle(manufacturer, model, energyClass, color, price, power2, volume));

                        break;

                    case "FRIDGE":
                        decimal capacity = decimal.Parse(parts[6].Trim());
                        string mountingType = parts[7].Trim();
                        Enum.TryParse(parts[8].Trim(), out Freezer hasFreezer);
                        int height = int.Parse(parts[9].Trim());
                        int width = int.Parse(parts[10].Trim());
                        int depth = int.Parse(parts[11].Trim());

                        store.Add(new Fridge(manufacturer, model, energyClass, color, price, capacity, mountingType, hasFreezer, height, width, depth));

                        break;
                    
                    default:
                        throw new Exception($"Invalid device type given: '{type}'");
                }

            }

            return store;
        }

        /// <summary>
        /// Reads all Stores in the given directory
        /// </summary>
        /// <param name="directory">Directory to read</param>
        /// <param name="pattern">file type to find</param>
        /// <returns>List of all stores in directory</returns>
        /// <exception cref="Exception"><paramref name="directory"/> not found</exception>
        public static Store ReadDevicesDir(string directory, string pattern = "*.csv")
        {
            if (!Directory.Exists(directory))
            {
                throw new Exception(string.Format("Directory '{0}' not found", directory));
            }

            Store merge = new Store(); // Merges all directory files data in to one List<>

            int count = 0;
            foreach (var filename in Directory.GetFiles(directory, pattern))
            {
                Store store = ReadDevices(filename);

                string path = HttpContext.Current.Server.MapPath("App_Data/OutFiles");

                string dir = string.Format("{0}/Store{1}.txt", path, count);
                WriteStoreToTxtFile(dir, store);



                merge.Add(ReadDevices(filename));
                count++;
            }

            return merge;
        }

        /// <summary>
        /// Prints all <paramref name="devices"/> to .csv file
        /// </summary>
        /// <param name="fileName">File to print to</param>
        /// <param name="devices">Devices to print</param>
        /// <exception cref="Exception">Unknown device</exception>
        public static void PrintDevicesCSV(string fileName, List<Device> devices)
        {
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (var device in devices)
                {
                    switch (device.GetType().Name)
                    {
                        case "Oven":
                            Oven oven = device as Oven;
                            writer.WriteLine(oven.ToCSVString());
                            break;
                        case "Kettle":
                            Kettle kettle = device as Kettle;
                            writer.WriteLine(kettle.ToCSVString());
                            break;
                        case "Fridge":
                            Fridge fridge = device as Fridge;
                            writer.WriteLine(fridge.ToCSVString());
                            break;
                        default:
                            throw new Exception(string.Format("Invalid device type: {0}", device.GetType().Name));
                    }
                }
            }
        }


        /// <summary>
        /// Writes all store data to txt file
        /// </summary>
        /// <param name="fileName">file to wrrite to</param>
        /// <param name="store"><paramref name="store"/> data to write</param>
        public static void WriteStoreToTxtFile(string fileName, Store store)
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";
            string dashes = new string('-', 228);

            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("\nPavadinimas: {0}, Adresas: {1}, Telefono numeris: {2}", store.Name, store.Adress, store.Phone);
                writer.WriteLine(dashes);
                writer.WriteLine(spacing, "Produktas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Šaldiklis?", "Aukštis", "Plotis", "Gylis", "Galingumas", "Programų skaičius");
                writer.WriteLine(dashes);

                for (int i = 0; i < store.Count(); i++)
                {
                    Device device = store.Get(i);

                    switch (device.GetType().Name)
                    {
                        case "Fridge":
                            Fridge fridge = device as Fridge;

                            writer.WriteLine(fridge.ToString());
                            break;

                        case "Oven":
                            Oven oven = device as Oven;

                            writer.WriteLine(oven.ToString());

                            break;
                        case "Kettle":
                            Kettle kettle = device as Kettle;

                            writer.WriteLine(kettle.ToString());

                            break;
                        default:    // Type not found
                            break;
                    }
                }
                writer.WriteLine(dashes);
            }
        }
    }
}