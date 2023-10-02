<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="priimimasis.aspx.cs" Inherits="LDD_22.priimimasis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Priėmimų aplankalas:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Seimo narių budėjimo grafikas:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <br />
            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įrašyti duomenis" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Skaičiuoti" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Priėmimai" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" Visible="False">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Seimo narių budėjimo grafikas" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Seimo narių informacija" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server" Visible="False">
            </asp:Table>
        </div>
    </form>
</body>
</html>
