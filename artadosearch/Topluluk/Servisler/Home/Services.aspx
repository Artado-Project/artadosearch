<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Topluluk_Servisler_Home_Services" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Services.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Servislerimiz</title>
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

        <div class="içerik">
            <h2>Servilerimiz</h2>
            <br /> 
            <a href= "http://artadosearch.com">Artado Search</a>
            <br />
            <br />
            Artado Search sizi reklamsız ve en güvenli şekilde bilgiye ulaştırmayı hedefler. Artado Search geliştirilmeye 2020 Mayıs ayında başlanmış, 2020 sonuna doğruda test aşamasına geçmiştir. Artado Search hala test aşamasındadır. Yakında test aşaması bitecek ve Beta aşamasına geçilecektir. Test aşaması halka açık bir şekilde yürütülmektedir böylece kullanıcılar canlı olarak gelişmeyi görebilmektedir. Herhangi bir aksaklık olmazsa Artado Search Beta aşamasına 2021 Şubat ayında geçilecekti
            <br />
            <br />
            <br />

            <a href="../Mail/Mail.aspx">Artado Mail</a>
            <br />
            Artado Mail ile güvenli ve gizli bir şekilde e-posta gönderip alabilirsiniz. Artado Mail, çok yakında kullanıma sunulacaktır.

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
