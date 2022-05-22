<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gazete.aspx.cs" Inherits="Topluluk_Servisler_Gazete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="/Icons/Celer/icons/icon.ico" />
     <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
        <link href="Gazete.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Celer Browser</title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="~/Icons/Celer/icons/icon.png" CssClass="image" /><br />
            <asp:Button ID="Hakkımızda" runat="server" Text="<%$Resources:Default, Hakkımızda %>" BackColor="Transparent" BorderStyle="None"  Font-Size="Large" CssClass="button" OnClick="Hakkımızda_Click"/>
            <asp:Button ID="İletişim" runat="server" Text="<%$Resources:Default, İletişim %>" BackColor="Transparent" BorderStyle="None"  Font-Size="Large" CssClass="button" OnClick="İletişim_Click"/>
            <asp:Button ID="Blog" runat="server" Text="<%$Resources:Default, Blog %>" BackColor="Transparent" Font-Size="Large" BorderStyle="None" CssClass="button" OnClick="Blog_Click"/>
            <asp:Button ID="DestekOl" runat="server" Text="<%$Resources:Default, Destek %>" BackColor="Transparent" Font-Size="Large" BorderStyle="None" CssClass="button" OnClick="DestekOl_Click"/>
        </div>

        <%--<div id="download_beta" class="download">
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Celer Browser Beta" Font-Bold="true" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Default, Celer1 %>" Font-Bold="true" Font-Size="Large" cssclass="label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server"  style="margin-left: 0px; margin-top: 0px" Text="<%$Resources:Default, Download_Win %>"  BorderStyle="None"  CssClass="Button1" ForeColor="White" Font-Size="Large" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="" Font-Bold="true" Font-Size="Large" cssclass="label"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, Download_num %>" Font-Bold="true" Font-Size="Large" cssclass="label"></asp:Label>
        </div>--%>

        <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:20px; max-width:1000px;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Newsletter %>" Font-Bold="true" Font-Size="X-Large" ></asp:Label>
           <br />
           <br />
            <asp:Label ID="Açıklama" runat="server" Text="<%$Resources:Default, Newsletter2 %>" Font-Bold="true" Font-Size="Large" cssclass="label"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Normal" runat="server" CssClass="arama" BorderStyle="Solid">
                <asp:TextBox ID="arama_çubugu" placeholder="E-mail" runat="server" TextMode="Email" BackColor="white" BorderStyle="None" AutoCompleteType="Search" ValidateRequestMode="Disabled"></asp:TextBox>
            </asp:Panel>
           <br />
            <asp:Button ID="Button1" runat="server"  style="margin-left: 0px; margin-top: 0px" Text="<%$Resources:Default, Kayıt %>"  BorderStyle="None" OnClick="Button1_Click"  CssClass="Button1" ForeColor="White" Font-Size="Large" />
           <br />
           <br />
           <asp:Label ID="Sonuc" runat="server" Text="" Font-Bold="true" Font-Size="Small" width="500px"></asp:Label>
        </div>

        <div id="screenshots" style="margin-left:auto; margin-right:auto; text-align:center; margin-top:20px; max-width:1000px; margin-bottom:100px;">
            <asp:Label ID="Ss" runat="server" Text="<%$Resources:Default, Screenshots %>" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Beta 1.6.0" Font-Size="Large"></asp:Label>
            <br />
            <br />
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(411).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(411).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(412).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(412).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(413).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(413).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(414).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(414).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(415).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(415).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(416).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(416).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(418).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(418).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(419).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(419).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(421).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(421).png" class="screenshots" /></a><br />
            </div>
            <div style="margin-bottom:50px;">
                <a href="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(423).png"><img src="../../../Icons/Celer/B1.6/Ekran%20Görüntüsü%20(423).png" class="screenshots" /></a><br />
            </div>
        </div>

    </form>
</body>
</html>
