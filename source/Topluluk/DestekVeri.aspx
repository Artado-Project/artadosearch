<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DestekVeri.aspx.cs" Inherits="DestekVeri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="DestekVeri.css" rel="stylesheet" />
    <link href="../bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
     <link rel= shortcut icon href= favicon.ico />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Search Topluluk</title>
</head>
<body style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">
        <div class="top">
            <asp:Image ID="Artado" runat="server" ImageUrl="~/Adsız.png" class="image" />
            <h2 style="color:white">Sonuç Ekle</h2>
            <br />
        </div>

        <div class="sonucekle">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Ad Soyad"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="E-Posta"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="URL girin"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click1" />
            <br />
            <asp:Label ID="SonucMesajı" runat="server" Text="" ForeColor="White"></asp:Label>
        </div>
         
    </form>
</body>
</html>
