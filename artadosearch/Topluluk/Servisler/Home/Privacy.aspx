<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Privacy.aspx.cs" Inherits="Topluluk_Servisler_Home_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="About.css" rel="stylesheet" />
   <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Privacy Policy</title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="../../../IMG_074.png" CssClass="image" />
            <br />
            <br />
            <asp:Button ID="Anasayfa" runat="server" Text="Artado Search" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Anasayfa_Click"/>
            <asp:Button ID="Hakkımızda" runat="server" Text="<%$Resources:Default, Hakkımızda %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="<%$Resources:Default, İletişim %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="<%$Resources:Default, Blog %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="<%$Resources:Default, Destek %>" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div class="içerik">
            <div style="background-color:antiquewhite; padding: 5px 5px 5px 5px; border-top-left-radius: 5px;  border-top-right-radius: 5px;   border-bottom-left-radius: 5px; border-bottom-right-radius: 5px;">
                <asp:Label ID="Label15" runat="server" Text="<%$Resources:Default, Dikkat %>" Font-Bold="true"></asp:Label> 
            </div>
            <br />
            <asp:Label ID="Label10" runat="server" Text="<%$Resources:Default, Politika %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Politika1 %>"></asp:Label> 
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Default, Politika2 %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Default, Politika3 %>"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="ID"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, Aranan %>"></asp:Label>&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="<%$Resources:Default, Lang %>"></asp:Label><br />
            <img src="/Icons/ss.png"/>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="<%$Resources:Default, ID1 %>"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="<%$Resources:Default, Aranan2 %>"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text="<%$Resources:Default, Dil2 %>"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label11" runat="server" Text="<%$Resources:Default, Politika4 %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label12" runat="server" Text="<%$Resources:Default, Politika5 %>"></asp:Label> 
            <br />
            <br />
            <asp:Label ID="Label13" runat="server" Text="<%$Resources:Default, Çerezler1 %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label14" runat="server" Text="<%$Resources:Default, Çerezler2 %>"></asp:Label> 
            <br />
            <br />
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
    </form>
</body>
</html>
