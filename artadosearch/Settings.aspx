<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/bootstrap-4.5.3-dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="/Settings.css" rel="stylesheet" />
<link rel="shortcut icon" href="/Icons/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Ayarlar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="image" ImageUrl="/Icons/android-chrome-192x192.png" OnClick="ImageButton1_Click" />
        </div>
        <asp:Panel ID="Post" runat="server" CssClass="panel">
            <asp:Label ID="Label10" runat="server" Text="<%$Resources:Default, Logo %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Default, Logo2 %>" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:Default, Logo3 %>" Font-Size="X-Small"></asp:Label>
            <br />
            <div class="button2">  
                <asp:ImageButton ID="ImageButton2" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/android-chrome-192x192.png" OnClick="ImageButton2_Click" />
                <asp:Button ID="Button1" runat="server" Text="<%$Resources:Default, Varsayılan %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton3" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/artadov3-colorful-icon.png" OnClick="ImageButton3_Click" />
                <asp:Button ID="Button2" runat="server" Text="<%$Resources:Default, Renkli %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton4" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/LGBT/artadov3-lgbt.png" OnClick="ImageButton4_Click" />
                <asp:Button ID="Button3" runat="server" Text="<%$Resources:Default, Gökkuşağı %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton5" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/tr/artadov3_tr2.png" OnClick="ImageButton5_Click" />
                <asp:Button ID="Button4" runat="server" Text="<%$Resources:Default, Tr %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton6" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/fr/artado_fr.png" OnClick="ImageButton6_Click" />
                <asp:Button ID="Button5" runat="server" Text="<%$Resources:Default, Fr %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton7" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/de/artado_de.png" OnClick="ImageButton7_Click" />
                <asp:Button ID="Button6" runat="server" Text="<%$Resources:Default, De %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton8" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/uk/artado-uk.png" OnClick="ImageButton8_Click" />
                <asp:Button ID="Button7" runat="server" Text="<%$Resources:Default, Uk %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
            <div class="button2">  
                <asp:ImageButton ID="ImageButton9" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/islam/artado_islam.png" OnClick="ImageButton9_Click" />
                <asp:Button ID="Button8" runat="server" Text="<%$Resources:Default, Islam %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
             <div class="button2">  
                <asp:ImageButton ID="ImageButton10" runat="server" style="width:80px; height:80px; float:left; outline:none;" ImageUrl="/Icons/oldies/old-icon.png" OnClick="ImageButton10_Click" />
                <asp:Button ID="Button9" runat="server" Text="<%$Resources:Default, Old %>" BackColor="Transparent" ForeColor="White" CssClass="button" BorderStyle="None"/>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel1" runat="server" CssClass="panel">
            <asp:Label ID="Label9" runat="server" Text="<%$Resources:Default, Arkaplan %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Default, Arkaplan2 %>" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="<%$Resources:Default, Arkaplan3 %>" Font-Size="X-Small"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="arama_çubugu" runat="server" placeholder="<%$Resources:Default, Arkaplan4 %>" ></asp:TextBox> 
            <asp:Button ID="Button10" runat="server" Text="<%$Resources:Default, Uygula %>" OnClick="Button10_Click" />
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" CssClass="panel">
            <h4>Artado Journal</h4>
            <asp:Label ID="Label6" runat="server" Text="<%$Resources:Default, Journal %>" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"/>
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" CssClass="panel">
            <asp:Label ID="Label7" runat="server" Text="<%$Resources:Default, Varsayılan1 %>" Font-Size="X-Large" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text="<%$Resources:Default, Varsayılan2 %>" Font-Size="Small"></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button11" runat="server" Text="<%$Resources:Default, Varsayılan3 %>" OnClick="Button11_Click" />
        </asp:Panel>

        <div style="min-height:30px;">

        </div>
        <footer class="page-footer">
	<div class="footer">
        <hr class="çizgi"/>
        <a href="/Contact" style="text-decoration:none;"><asp:Label ID="Label18" runat="server" Text="<%$Resources:Default, İletişim %>"></asp:Label></a>
        &nbsp;&nbsp;&nbsp;
        <a href="/Manifest" style="text-decoration:none;"><asp:Label ID="Label19" runat="server" Text="<%$Resources:Default, Manifesto %>"></asp:Label></a>
        &nbsp;&nbsp;&nbsp;
        <a href="/Forum" style="text-decoration:none;"><asp:Label ID="Label20" runat="server" Text="<%$Resources:Default, Blog %>"></asp:Label></a>
        &nbsp;&nbsp;&nbsp;
        <a href="/Photon" style="text-decoration:none;"><asp:Label ID="Label21" runat="server" Text="Artado Photon"></asp:Label></a>
	</div>
</footer>
    </form>
</body>
</html>
