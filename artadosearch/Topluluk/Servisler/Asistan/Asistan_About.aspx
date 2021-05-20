<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Asistan_About.aspx.cs" Inherits="Topluluk_Servisler_Asistan_Asistan_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Asistan_About.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
        <link href="bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Asistan - Hakkında</title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="açılış">
            <img src="/Icons/artado_searchv2.png" class="image" />
            <asp:Button ID="Button1" runat="server" Text="Artado Search" class="button" OnClick="Button1_Click" BorderStyle="None"/>
            <asp:Button ID="Button2" runat="server" Text="Hakkında" class="button2" OnClick="Button2_Click" BorderStyle="None"/>
            <asp:Button ID="Button3" runat="server" Text="Destek Ol" class="button2" OnClick="Button3_Click" BorderStyle="None"/>
        </div>

        <div class="içerik">
            <h1>Artado Asistan</h1>
            <h3>Genel</h3>
            Artado Asistan, Artado Search için tasarlanmışdır. Artado Asistan ile aramalar yapabilir, hava durumuna bakabilir, kurların durumunu öğrenebilirsiniz.
            <br />
            <br />
            <h3>Türkçe Dil Desteği</h3>
            Artado Asistan, Türkçe dil desteği içerir. Böylece sizi iyi bir şekilde anlayabilmektedir. 
            <br />
            <br />
            <h3>Çıkış Zamanı</h3>
            Artado Asistan, 2021 veya 2022 yılları içinde Artado Search üzerinden kullanıma sunulacaktır. Asistan geliştikten sonra mobil cihazlara uygun hale gelecek ve mobil uygulama yayınlanacaktır. Artado Asistan şu an yolun başındadır ama yakın bir dönemde sizlerle olacaktır.
        </div>
    </form>
</body>
</html>
