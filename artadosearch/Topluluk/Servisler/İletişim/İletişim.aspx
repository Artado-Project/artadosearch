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
            <h2>İletişim adreslerimiz</h2>
            <br /> 
            Bize sosyal medya üzerinden ulaşabilir ve projelerimiz hakkında son haberlere ulaşabilirsiniz. 
            <br />
            <br />
            <a href="https://www.instagram.com/artadosoftware/">Instagram hesabımız</a>
            <br />
            <br />
            <a href="https://twitter.com/ArtadoL">Twitter hesabımız</a>
            <br />
            <br />
            <a href="https://www.facebook.com/profile.php?id=100053288294778">Facebook hesabımız</a>
            <br />
            <br />
            <a href="https://www.reddit.com/r/ArtadoSearch/">Subreddit adresimiz</a>
            <br />
            <br />
            <br />
            <a href="https://discord.gg/baj29VBkfp">Discord Sunucumuz</a>
            <br />
            <a href="mailto:artadoyazilim@gmail.com">E-posta Adresimiz</a>
            <br />
            <br />
            <br />
             <asp:Panel ID="Panel1" runat="server" CssClass="ads">
                <asp:Label ID="Label1" runat="server" Text="Reklam Alanı"></asp:Label>
            </asp:Panel>
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
