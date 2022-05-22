<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bot.aspx.cs" Inherits="ArtadoBot_Bot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Link" runat="server" Text="Link"></asp:Label><br />
            <asp:Label ID="Title" runat="server" Text="Title"></asp:Label><br />
            <asp:Label ID="Desc" runat="server" Text="Desc"></asp:Label><br />
            <asp:Label ID="Keywords" runat="server" Text="Keywords"></asp:Label><br />
            <asp:Label ID="Lang" runat="server" Text="Lang"></asp:Label><br />
            <asp:Image ID="Favicon" runat="server" /><br />
            <br />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>
    </form>
</body>
</html>
