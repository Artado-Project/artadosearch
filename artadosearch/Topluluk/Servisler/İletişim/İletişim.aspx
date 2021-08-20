<%@ Page Language="C#" AutoEventWireup="true" CodeFile="İletişim.aspx.cs" Inherits="Topluluk_Servisler_İletişim_İletişim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="İletişim.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>İletişim Adreslerimiz</title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="../../../IMG_074.png" CssClass="image" />
            <br />
            <br />
            <asp:Button ID="Anasayfa" runat="server" Text="Anasayfa" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Anasayfa_Click"/>
            <asp:Button ID="Hakkımızda" runat="server" Text="Hakkımızda" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="İletişim" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="Blog" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="Destek Ol" BackColor="Black" BorderStyle="None" ForeColor="White" Font-Size="Large" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div class="içerik">
            <div style="background-color:antiquewhite; padding: 5px 5px 5px 5px; border-top-left-radius: 5px;  border-top-right-radius: 5px;   border-bottom-left-radius: 5px; border-bottom-right-radius: 5px;">
                <asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, Dikkat %>" Font-Bold="true"></asp:Label> 
            </div>
            <br />
            <h2>İletişim adreslerimiz</h2>
            <br /> 
            Bize sosyal medya üzerinden ulaşabilir ve projelerimiz hakkında son haberlere ulaşabilirsiniz. 
            <br />
            <br />
            <a href="https://www.instagram.com/artadosoftware/">Instagram</a>
            <br />
            <br />
            <a href="https://twitter.com/ArtadoL">Twitter</a>
            <br />
            <br />
            <a href="https://www.facebook.com/profile.php?id=100053288294778">Facebook</a>
            <br />
            <br />
            <a href="https://www.reddit.com/r/ArtadoSearch/">Subreddit</a>
            <br />
            <br />
            <br />
            <a href="https://discord.gg/baj29VBkfp">Discord</a>
            <br />
            <a href="mailto:artadosoftware@protonmail.com">E-mail</a>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <a href="http://artadosearch.com" style="vertical-align:middle;"></a>
        </div>
    </form>
</body>
</html>
