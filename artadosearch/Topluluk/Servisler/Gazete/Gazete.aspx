<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gazete.aspx.cs" Inherits="Topluluk_Servisler_Gazete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
     <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
        <link href="Gazete.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Photon</title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="~/Icons/Photon_Banner.png" CssClass="image" /><br />
            <asp:Button ID="Hakkımızda" runat="server" Text="<%$Resources:Default, Hakkımızda %>" BackColor="Transparent" BorderStyle="None"  Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="<%$Resources:Default, İletişim %>" BackColor="Transparent" BorderStyle="None"  Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="<%$Resources:Default, Blog %>" BackColor="Transparent" Font-Size="Large" BorderStyle="None" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="<%$Resources:Default, Destek %>" BackColor="Transparent" Font-Size="Large" BorderStyle="None" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:20px; max-width:1000px;">
            <asp:Label ID="Label1" runat="server" Text="Güvenli ve hızlı gezinti" Font-Bold="true" Font-Size="X-Large" ></asp:Label>
           <br />
           <br />
            <asp:Label ID="Açıklama" runat="server" Text="Gizliliğinize ve anonimliğinize saygılı tarayıcı Artado Photon yakında sizlerle olacak! Artado Photon'u ilk deneyen kişilerden biri olmak için bekleme listesine kaydolun." Font-Bold="true" Font-Size="Large" cssclass="label"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Normal" runat="server" CssClass="arama" BorderStyle="Solid">
                <asp:TextBox ID="arama_çubugu" placeholder="E-posta" runat="server" TextMode="Email" BackColor="white" BorderStyle="None" AutoCompleteType="Search" MaxLength="100" ValidateRequestMode="Disabled"></asp:TextBox>
            </asp:Panel>
           <br />
            <asp:Button ID="Button1" runat="server"  style="margin-left: 0px; margin-top: 0px" Text="Bekleme listesine kayıt ol"  BorderStyle="None" OnClick="Button1_Click"  CssClass="Button1" ForeColor="White" Font-Size="Large" />
           <br />
           <br />
           <asp:Label ID="Sonuc" runat="server" Text="" Font-Bold="true" Font-Size="Small" width="500px"></asp:Label>
        </div>

    </form>
</body>
</html>
