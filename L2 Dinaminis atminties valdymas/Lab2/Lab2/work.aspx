<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="work.aspx.cs" Inherits="Lab2.work" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
