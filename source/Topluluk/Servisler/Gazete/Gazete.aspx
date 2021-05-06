<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gazete.aspx.cs" Inherits="Topluluk_Servisler_Gazete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Gazete.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Gazete</title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="~/AdsızGazete.png" CssClass="image" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Gazete" Font-Bold="true" Font-Size="X-Large" ></asp:Label>
           <br />
           <br />
            <asp:Label ID="Açıklama" runat="server" Text="En son gelişmelerden haberdar olmak için gazetemize abone olun. Düzenli olarak gelişmeler hakkında e-posta alacaksınız." Font-Bold="true" Font-Size="Large" cssclass="label"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Ad Soyad"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="arama_çubugu" CssClass="textbox" placeholder="E-posta adresinizi girin" runat="server"  BorderStyle="Outset"></asp:TextBox>
           <br />
           <asp:Label ID="Not" runat="server" Text="UYARI: Abone olarak düzenli e-posta alacağınızı kabul edersiniz." Font-Bold="true" Font-Size="Small" cssclass="label"></asp:Label>
           <br />
           <br />
            <asp:Button ID="Button1" runat="server"  style="margin-left: 0px; margin-top: 0px" Text="Abone Ol!"  BorderStyle="None" OnClick="Button1_Click"  CssClass="Button1" ForeColor="White" Font-Size="Larger" />
           <br />
           <br />
           <asp:Label ID="Sonuc" runat="server" Text="" Font-Bold="true" Font-Size="Small" width="500px"></asp:Label>
        </div>

    </form>
</body>
</html>
