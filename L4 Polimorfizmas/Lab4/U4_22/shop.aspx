<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="U4_22.shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server" Text="Duomenų aplankalas:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server">App_Data/InFiles</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Škaičiuoti" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Rastos šaldytuvų spalvos:" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="FridgeColorsTable" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Rastos elektrinių virdulių spalvos:" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="KettleColorsTable" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Pigiausias A+ klasės šaldytuvas:" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="CheapestFridgeTable" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Pigiausia A+ klasės mikrobangų krosnelė: " Visible="False"></asp:Label>
            <br />
            <asp:Table ID="CheapestOvenTable" runat="server">
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Pigiausias A+ klasės virdulys:" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="CheapestKettleTable" runat="server">
            </asp:Table>
            
        </div>
    </form>
</body>
</html>
