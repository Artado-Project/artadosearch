<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Soon.aspx.cs" Inherits="Topluluk_Servisler_Yakında_Soon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Soon.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bu sayfa çok yakında aktif olacaktır.</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <asp:Image ID="Image" runat="server" ImageUrl="~/AdsızBlog.png" CssClass="image" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Üzgünüz bu sayfa şu anda aktif değildir. Yakında tekrar geliniz. ArtadoSearch hakkında haberleri ilk olarak almak için Gazetemize abone olabilirsiniz." Font-Bold="true" Font-Size="X-Large" width="500px"></asp:Label>
        </div>
    </form>
</body>
</html>
