using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lab2;

namespace Lab2.Classes
{
    public class DataOutput
    {

        /// <summary>
        /// Creates row for table
        /// </summary>
        /// <param name="cell1">Info for first cell</param>
        /// <param name="cell2">Info for second cell</param>
        /// <param name="cell3">Info for third cell</param>
        /// <returns>Created cell</returns>
        public static TableRow MakeRow(string cell1, string cell2, string cell3)
        {
            TableRow row = new TableRow();

            TableCell Cell1 = new TableCell();
            Cell1.Text = cell1;
            row.Cells.Add(Cell1);

            TableCell Cell2 = new TableCell();
            Cell2.Text = cell2;
            row.Cells.Add(Cell2);

            TableCell Cell3 = new TableCell();
            Cell3.Text = cell3;
            row.Cells.Add(Cell3);

            return row;
        }

        /// <summary>
        /// Creates row for table
        /// </summary>
        /// <param name="cell1">Info for first cell</param>
        /// <param name="cell2">Info for second cell</param>
        /// <returns>Created row</returns>
        public static TableRow MakeRow(string cell1, string cell2)
        {
            TableRow row = new TableRow();

            TableCell Cell1 = new TableCell();
            Cell1.Text = cell1;
            row.Cells.Add(Cell1);

            TableCell Cell2 = new TableCell();
            Cell2.Text = cell2;
            row.Cells.Add(Cell2);

            return row;
        }

        /// <summary>
        /// Creates row for table
        /// </summary>
        /// <param name="cell1">Info for first cell</param>
        /// <returns>Created row</returns>
        public static TableRow MakeRow(string cell1)
        {
            TableRow row = new TableRow();

            TableCell Cell1 = new TableCell();
            Cell1.Text = cell1;
            row.Cells.Add(Cell1);

            return row;
        }

        /// <summary>
        /// Create empty row for table
        /// </summary>
        /// <returns>Created row</returns>
        public static TableRow MakeRow()
        {
            TableRow row = new TableRow();

            row.Height = 20;

            return row;
        }
    }
}