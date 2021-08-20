<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Soon.aspx.cs" Inherits="Topluluk_Servisler_Yakında_Soon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Soon.css" rel="stylesheet" />
    <link rel="shortcut icon" href="/Icons/favicon.ico" />
    <link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bu sayfa çok yakında aktif olacaktır.</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <asp:Label ID="Label2" runat="server" Text=":(" Font-Bold="true" Font-Size="X-Large" width="500px"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Üzgünüz bu servisimiz hala geliştirme aşamasındadır. Lütfen daha sonra tekrar gelin." Font-Bold="true" Font-Size="X-Large" width="500px"></asp:Label>
        </div>
    </form>
</body>
</html>
