<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Topluluk_Forum_Forum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/bootstrap-4.5.3-dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="Forum.css" rel="stylesheet" />
<link rel="shortcut icon" href="https://www.artadosearch.com/Icons/favicon.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>Artado Forum</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="açılış">
            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="image" OnClick="ImageButton1_Click" ImageUrl="/Icons/android-chrome-192x192.png" />
            <asp:Panel ID="LogIn" runat="server">
                <asp:Button ID="Button2" runat="server" Text="<%$Resources:Default, Oturum %>" class="button2" OnClick="Button2_Click" BorderStyle="None"/>
            </asp:Panel>
            <asp:HyperLink ID="Label3" runat="server" Text='' Font-Size="Small" ForeColor="White"></asp:HyperLink>
        </div>

        <div class="panel" style="color:white; margin-top:20px;">
            <h6>Merhaba, Artado Forum'a hoşgeldin! Burada Artado ürünleri için görüş ve önerilerinizi yazabilir, yaşadığınız sorunları bildirebilirsiniz.</h6> 
        </div>

        <asp:Button ID="Button1" runat="server" Text="Gönderi Oluştur" BackColor="#1a1a2e" CssClass="panel" BorderStyle="None" ForeColor="white" OnClick="Button1_Click1"/>

        <asp:Panel ID="Post" runat="server" CssClass="panel">
            <asp:TextBox ID="TitleText" runat="server" placeholder="Başlık" BackColor="Transparent" Width="300px" ForeColor="White" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox><br /><br />
            <asp:TextBox ID="TextBox5" runat="server" placeholder="Bir şeyler yaz..." BackColor="Transparent" Width="300px" ForeColor="White" TextMode="MultiLine" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" Text="Paylaş" BackColor="#1a1a2e" ForeColor="White" OnClick="Button5_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="iptal" runat="server" Text="İptal" BackColor="#1a1a2e" ForeColor="White" OnClick="iptal_Click"/>
            <asp:Label ID="Label5" runat="server" Text='' Font-Size="Small"></asp:Label>
        </asp:Panel>

        <asp:Panel ID="SorularPanel" runat="server">
            <asp:Repeater ID="Sorular" runat="server">
                <ItemTemplate>
                    <div class="panel" style="width:800px; max-height:115px;">
                        <div style="float:right;">
                            <asp:Label ID="View" runat="server" Text='Görüntülenme: ' Font-Size="Small"></asp:Label>
                            <asp:Label ID="View2" runat="server" Text='<%# Eval("Views") %>' Font-Size="Small"></asp:Label><br />
                            <asp:Label ID="Answers" runat="server" Text='Cevap: ' Font-Size="Small"></asp:Label>
                            <asp:Label ID="Answers2" runat="server" Text='<%# Eval("Answers") %>' Font-Size="Small"></asp:Label>
                        </div>
                        <a href='/Forum?id=<%# Eval("ID") %>'><asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a> <br />
                        <a href='/Forum?userid=<%# Eval("UserID") %>'><asp:Label ID="Username" runat="server" Text='<%# Eval("Username") %>' Font-Size="Small"></asp:Label></a> &nbsp&nbsp&nbsp
                        <asp:Label ID="Date" runat="server" Text='<%# Eval("Date") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Detail" runat="server" Text='<%# Eval("Detail") %>' Font-Size="Small"></asp:Label>    
                    </div>
                </ItemTemplate>
            </asp:Repeater>
              <div style="text-align:center; margin-top:50px;">
                <asp:Panel ID="PageSelect" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label"></asp:Label>            
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server">Önceki Sayfa</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink2" runat="server">Sonraki Sayfa</asp:HyperLink>
                </asp:Panel>
            </div>
        </asp:Panel>

        <asp:Panel ID="Soru" runat="server">
            <div class="panel">
                <div style="float:right;">
                    <asp:Label ID="View" runat="server" Text='' Font-Size="Small"></asp:Label>
                    <asp:Label ID="Answers" runat="server" Text='' Font-Size="Small"></asp:Label>
                </div>
                <asp:Label ID="Title" runat="server" Text="" Font-Size="Large"></asp:Label><br />
                <asp:Label ID="Username" runat="server" Text='' Font-Size="Small"></asp:Label>&nbsp&nbsp&nbsp
                <asp:Label ID="Date" runat="server" Text="" Font-Size="Small"></asp:Label><br />
                <asp:Label ID="Detail" runat="server" Text="" Font-Size="Medium"></asp:Label>
            </div>
            <asp:Button ID="Button4" runat="server" Text="Cevapla" BackColor="#1a1a2e" OnClick="Button4_Click" CssClass="panel" BorderStyle="None" ForeColor="white"></asp:Button>

            <asp:Panel ID="Yanıt" runat="server" CssClass="panel">
                <asp:TextBox ID="TextBox7" runat="server" placeholder="Bir şeyler yaz..." BackColor="Transparent" Width="300px" ForeColor="White" TextMode="MultiLine" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button10" runat="server" Text="Paylaş" BackColor="#1a1a2e" ForeColor="White" OnClick="Button10_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button11" runat="server" Text="İptal" BackColor="#1a1a2e" ForeColor="White" OnClick="Button11_Click"/>
                <asp:Label ID="Label6" runat="server" Text='' Font-Size="Small"></asp:Label>
            </asp:Panel>

            <asp:Repeater ID="Cevaplar" runat="server">
                <ItemTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                        <a href='/Forum?user=<%# Eval("Username") %>'><asp:Label ID="Username" runat="server" Text='<%# Eval("Username") %>' Font-Size="Small"></asp:Label></a> &nbsp&nbsp&nbsp
                        <asp:Label ID="Date" runat="server" Text='<%# Eval("Date") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Detail" runat="server" Text='<%# Eval("Answer") %>' Font-Size="Small"></asp:Label>  
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>

            <div style="text-align:center; margin-top:50px;">
                <asp:Panel ID="Panel2" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label"></asp:Label>            
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server">Önceki Sayfa</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink4" runat="server">Sonraki Sayfa</asp:HyperLink>
            </asp:Panel>
            </div>
        </asp:Panel>

        <asp:Panel ID="Profil" runat="server" CssClass="panel">
            <asp:Label ID="User" runat="server" Text="" Font-Size="Large"></asp:Label><br />
            <asp:Label ID="Bio" runat="server" Text="" Font-Size="Medium"></asp:Label>
        </asp:Panel>

        <asp:Repeater ID="Profil_Questions" runat="server">
                <ItemTemplate>
                    <div class="panel" style="width:800px; max-height:115px;">
                        <div style="float:right;">
                            <asp:Label ID="View" runat="server" Text='Görüntülenme: ' Font-Size="Small"></asp:Label>
                            <asp:Label ID="View2" runat="server" Text='<%# Eval("Views") %>' Font-Size="Small"></asp:Label><br />
                            <asp:Label ID="Answers" runat="server" Text='Cevap: ' Font-Size="Small"></asp:Label>
                            <asp:Label ID="Answers2" runat="server" Text='<%# Eval("Answers") %>' Font-Size="Small"></asp:Label>
                        </div>
                        <a href='/Forum?id=<%# Eval("ID") %>'><asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a> <br />
                        <a href='/Forum?userid=<%# Eval("UserID") %>'><asp:Label ID="Username" runat="server" Text='<%# Eval("Username") %>' Font-Size="Small"></asp:Label></a> &nbsp&nbsp&nbsp
                        <asp:Label ID="Date" runat="server" Text='<%# Eval("Date") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Detail" runat="server" Text='<%# Eval("Detail") %>' Font-Size="Small"></asp:Label>    
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </form>
</body>
</html>
