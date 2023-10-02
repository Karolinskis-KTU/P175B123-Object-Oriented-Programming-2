<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Varzybos.aspx.cs" Inherits="Lab1.Varzybos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:Label ID="Label1" runat="server" Text="Pradiniai duomenys:"></asp:Label>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:CustomValidator>
            <br />
            <asp:Table ID="Table1" runat="server" BackColor="#FFFF99" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="Both" Height="58px" Width="87px">
            </asp:Table>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" BackColor="#FFFF99" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="2" CellSpacing="2" GridLines="Both" Height="58px" Width="427px">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
