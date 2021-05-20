<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Topluluk_Servisler_Home_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Home.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Software - Anasayfa</title>
</head>
<body>
    <form id="form1" runat="server">
           <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="../../../IMG_074.png" CssClass="image" />
            <br />
            <br />
            <asp:Button ID="Anasayfa" runat="server" Text="Anasayfa" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Anasayfa_Click"/>
            <asp:Button ID="Hakkımızda" runat="server" Text="Hakkımızda" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="İletişim" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="Blog" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="Destek Ol" BackColor="Transparent" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div class="banner">
        </div>

        <div>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Oyunlarımız.png" CssClass="games" OnClick="ImageButton1_Click"/>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Servislerimiz.png" CssClass="ser" OnClick="ImageButton2_Click"/>


        </div>

            <asp:Panel ID="Panel1" runat="server" CssClass="ads">
                <asp:Label ID="Label1" runat="server" Text="Reklam Alanı"></asp:Label>
            </asp:Panel>
                
        <div id="kreosus" data-id="1736" class="destek"></div>

       <script>(function(d, s, id) {
var js, kjs = d.getElementsByTagName(s)[0];
if (d.getElementById(id)) return;
js = d.createElement(s);
js.id = id;
js.src = 'https://kreosus.com/public/iframe/js/iframe-api.js';
kjs.parentNode.insertBefore(js, kjs);
}(document, 'script', 'kreosus-iframe-api'));</script>

        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="dwn" >
            <a href="http://artadosearch.com" style="position: relative; top: 50%; transform: perspective(1px) translateY(-50%);">Artado Search</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="/İletişim" style="position: relative; top: 50%; transform: perspective(1px) translateY(-50%);">İletişim</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="/DestekOl" style="position: relative; top: 50%; transform: perspective(1px) translateY(-50%);">Destek Ol</a>
        </div>
    </form>
</body>
</html>
