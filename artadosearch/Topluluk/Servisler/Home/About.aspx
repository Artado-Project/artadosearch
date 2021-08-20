<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="Topluluk_Servisler_Home_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="About.css" rel="stylesheet" />
   <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>About Us - Artado Search</title>
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
                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Default, Dikkat %>" Font-Bold="true"></asp:Label> 
            </div>
            <br />
            <asp:Label ID="Label10" runat="server" Text="<%$Resources:Default, Hakkımızda %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Hakkımızda1 %>"></asp:Label> 
            <br />
            <br />


            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Default, ArtadoSearch %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label12" runat="server" Text="<%$Resources:Default, Hakkımızda2 %>"></asp:Label> 
            <br />
            <br />


            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Default, Reklam %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label13" runat="server" Text="<%$Resources:Default, Hakkımızda3 %>"></asp:Label> 
            <br />
            <br />

            <asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, Gizlilik %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label14" runat="server" Text="<%$Resources:Default, Hakkımızda4 %>"></asp:Label> 
            <br />
            <br />

            <asp:Label ID="Label6" runat="server" Text="<%$Resources:Default, Açık %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label15" runat="server" Text="<%$Resources:Default, Hakkımızda5 %>"></asp:Label> 
            <br />
            <br />

            <asp:Label ID="Label7" runat="server" Text="<%$Resources:Default, Özelleştirebilme %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label16" runat="server" Text="<%$Resources:Default, Hakkımızda6 %>"></asp:Label> 
            <br />
            <br />

            <asp:Label ID="Label8" runat="server" Text="<%$Resources:Default, Sonuçlar %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label17" runat="server" Text="<%$Resources:Default, Hakkımızda7 %>"></asp:Label> 
            <br />
            <br />

            <asp:Label ID="Label9" runat="server" Text="<%$Resources:Default, Hedefler %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label18" runat="server" Text="<%$Resources:Default, Hakkımızda8 %>"></asp:Label> 
            <br />
            <br />

            <asp:Label ID="Label11" runat="server" Text="<%$Resources:Default, Özel Teşekkür %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label19" runat="server" Text="<%$Resources:Default, Hakkımızda9 %>"></asp:Label> 
            <br />
            <br />
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
    </form>
</body>
</html>
