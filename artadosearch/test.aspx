<%@ Page Language="C#" Inherits="artadosearch.test" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>test</title>
</head>
<body>
	<form id="form1" runat="server">
       <div>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox><br />
            <asp:TextBox ID="Salt" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="Şifrele" runat="server" Text="Şifrele" OnClick="Şifrele_Click" />
            <asp:Button ID="Çöz" runat="server" Text="Çöz" OnClick="Çöz_Click" /><br />
            <asp:Label ID="Sonuc" runat="server" Text=""></asp:Label>
            <asp:Label ID="Hashed" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Sunucu Test" OnClick="Button1_Click" />
	</form>
</body>
</html>
