<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="work.aspx.cs" Inherits="Lab3.work" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Projektai | Karolis Paulavičius IFF/1-1</title>
    <style>
        body {
            color: #34495e;
            font-family: Trebuchet, Arial, sans-serif;
            background-color: #ecf0f1;
        }
        [type="file"] {
            /* Style the color of the message that says 'No file chosen' */
            color: black;
        }
        [type="file"]::-webkit-file-upload-button {
            border-width: 0;
            outline: none;
            border-radius: 2px;
            box-shadow: 0 1px 4px rgba(0, 0, 0, .6);
  
            background-color: #2ecc71;
            color: #ecf0f1;

            transition: all 1s ease;
        }
        [type="file"]::-webkit-file-upload-button:hover {
            background-color: #27ae60;
        }
        [type="text"] {
            border: 2px solid #ecf0f1;
            border-radius: 4px;
            color: #fff;
            cursor: pointer;
            font-size: 12px;
            outline: none;
            transition: all 1s ease;
        }
        [type="text"]:hover {
            background : #fff;
            border: 2px solid #535353;
            color: #000;
        }

        [type="Submit"] {
            border-width: 0;
            outline: none;
            border-radius: 2px;
            box-shadow: 0 1px 4px rgba(0, 0, 0, .6);
  
            background-color: #2ecc71;
            color: #ecf0f1;
  
            transition: background-color .3s;
        }
        [type="Submit"]:hover, [type="Submit"]:focus {
            background-color: #27ae60;
        }

        tbody {
            margin-bottom: 2rem;
            background-color: #ffffff;
        }
        tr {
            -webkit-transition: all 0.3s ease;
            -o-transition: all 0.3s ease;
            transition: all 0.3s ease;
        }
        tr:hover {
            background-color: rgba(0, 0, 0, 0.12);
        }
        th, td {
            text-align: left;
            padding: 0.5rem;
            vertical-align: top;
            border-top: 0;
            -webkit-transition: all 0.3s ease;
            -o-transition: all 0.3s ease;
            transition: all 0.3s ease;
        }
        tbody > thead > tr > th {
            font-weight: 400;
            color: #757575;
            vertical-align: bottom;
            border-bottom: 1px solid rgba(0, 0, 0, 0.12);
        }

        #Label8 {
            font-weight: bold;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Informacija apie studentų pasirenkamus projektinius darbus:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server"/>
            <br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="Infromacija apie projektinius darbus: "></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <br />
            <br />

            <asp:Label ID="Label3" runat="server" Text="Įveskite ieškoma dėstytoją:"></asp:Label>
            <br />

            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
            <br />
            <br />

            <asp:Label ID="Label5" runat="server" Text="Dėstytojų sąrašas:" Visible="False"></asp:Label>
            <asp:Table ID="Table1" runat="server" Visible="False" BackColor="#FFFF99" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Daugiausiai projektinių darbų turintis dėstytojas:" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
            <br />
            <br />

            <asp:Label ID="Label4" runat="server" Text="Nurodyto dėstytojo projektinių darbų sąrašas:" Visible="False"></asp:Label>
            <asp:Table ID="Table2" runat="server" Visible="False" BackColor="#FFFF99" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="Both">
            </asp:Table>
        </div>

    </form>
</body>
</html>
