<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Topluluk_MyAccount_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" /> 
<link href="Default.css" rel="stylesheet" />
<meta name="robots" content="noindex" />
<link rel="shortcut icon" href="/Icons/favicon.ico" />
    <title>Artado My Account</title>
</head>
<body style="-webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">
        <div class="container">
            <div id="all" runat="server" class="panel">
                <div id="main_signin" runat="server">
                    <div id="signin" runat="server" class="panel2">
                        <asp:Label ID="LoginTxt" runat="server" Text="Kayıt Ol" Font-Size="XX-Large"></asp:Label>
                        <br />
                        <asp:TextBox ID="Username" placeholder="Kullanıcı Adı" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="Mail" placeholder="E-Posta" runat="server" CssClass="textbox" TextMode="Email"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="Password" placeholder="Şifre" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:Label ID="Uyarı" runat="server" Text="" Font-Size="Small" ForeColor="Red" CssClass="Uyarı"></asp:Label>
                        <asp:Button ID="Button1" runat="server" Text="Onayla" CssClass="buttons" OnClick="Button1_Click"/>
                        <asp:Button ID="login" runat="server" Text="Giriş Yap" OnClick="login_Click"/>
                    </div>
                    <div id="Mail_Onay" runat="server" class="panel2">
                        <asp:Label ID="Label6" runat="server" Text="E-posta hesabınızı onaylayın." Font-Size="Large"></asp:Label><br />
                        <asp:Label ID="Label60" runat="server" Text="E-postanıza gönderilen 6 haneli onay kodunu girin. Eğer kodu bulamazsanız Spam kutunuzu kontrol etmeyi unutmayın!" Font-Size="Small"></asp:Label>
                        <br />
                        <asp:TextBox ID="CodeTxt" placeholder="Kodu girin" runat="server" CssClass="textbox" MaxLength="5" TextMode="Number"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="" Font-Size="Small" ForeColor="Red" CssClass="Uyarı"></asp:Label>
                        <asp:Button ID="Button6" runat="server" Text="Onayla" CssClass="buttons" OnClick="Button6_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button7" runat="server" Text="Tekrar Gönder" CssClass="buttons" OnClick="Button7_Click"/>
                    </div>
                    <div id="signin2" runat="server" class="panel2">
                        <asp:Label ID="Label2" runat="server" Text="İsterseniz hesabınıza bir biyografi ekleyebilirsiniz!" Font-Size="Large"></asp:Label>
                        <br />
                        <textarea id="Bio" runat="server" class="textbox" maxlength="50"></textarea>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="" Font-Size="Small" ForeColor="Red" CssClass="Uyarı"></asp:Label>
                        <asp:Button ID="Button2" runat="server" Text="Onayla" CssClass="buttons" OnClick="Button2_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="Geç" CssClass="buttons" OnClick="Button3_Click"/>
                    </div>
                    <div id="signin3" runat="server" class="panel2">
                        <asp:Label ID="Label4" runat="server" Text="İsterseniz hesabınızın güvenliği için bir kurtarma e-postası veya ikinci bir şifre ekleyebilirsiniz." Font-Size="Small"></asp:Label>
                        <br />
                        <asp:TextBox ID="Mail2" placeholder="Kurtarma E-Postası" runat="server" CssClass="textbox" TextMode="Email"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="Pass2" placeholder="İkincil Şifre" runat="server" CssClass="textbox" TextMode="Password" MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="" Font-Size="Small" ForeColor="Red" CssClass="Uyarı"></asp:Label>
                        <asp:Button ID="Button4" runat="server" Text="Onayla" CssClass="buttons" OnClick="Button4_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button5" runat="server" Text="Geç" CssClass="buttons" OnClick="Button5_Click"/>
                    </div>
                </div>

                <div id="main_login" runat="server">
                    <div id="login1" runat="server" class="panel2">
                        <asp:Label ID="Label8" runat="server" Text="Giriş Yap" Font-Size="XX-Large"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox1" placeholder="Kullanıcı Adı" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox3" placeholder="Şifre" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="" Font-Size="Small" ForeColor="Red" CssClass="Uyarı"></asp:Label>
                        <asp:Button ID="Button8" runat="server" Text="Onayla" CssClass="buttons" OnClick="Button8_Click"/>
                    </div>
                    <div id="login2" runat="server" class="panel2">
                        <asp:Label ID="Label10" runat="server" Text="E-posta hesabınızı onaylayın." Font-Size="Large"></asp:Label><br />
                        <asp:Label ID="Label11" runat="server" Text="E-postanıza gönderilen 6 haneli onay kodunu girin." Font-Size="Small"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox4" placeholder="Kodu girin" runat="server" CssClass="textbox" MaxLength="5" TextMode="Number"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="" Font-Size="Small" ForeColor="Red" CssClass="Uyarı"></asp:Label>
                        <asp:Button ID="Button10" runat="server" Text="Onayla" CssClass="buttons" OnClick="Button10_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button11" runat="server" Text="Tekrar Gönder" CssClass="buttons" OnClick="Button11_Click"/>
                    </div>
                </div>

                <div id="main_profile" runat="server" class="panel2" style="text-align:center">
                    <img id="ProfilePic" runat="server" src="/images/image.png" style="width:150px; height:150px; margin-left:58px; margin-right:75px"/><br />
                    <asp:Label ID="Label13" runat="server" Text="Username" Font-Size="X-Large"></asp:Label><br />
                    <asp:Label ID="Label14" runat="server" Text="Mail" Font-Size="Small"></asp:Label><br />
                    <asp:Label ID="Label15" runat="server" Text="Biyografi: " Font-Size="Small"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text="[Bio]" Font-Size="Small"></asp:Label><br /><br />
                    <asp:Button ID="Button9" runat="server" Text="Hesaptan çık" class="buttons2" OnClick="Button9_Click"/><br />
                    <asp:Button ID="Button18" runat="server" Text="Hesabı sil" class="buttons2" OnClick="Button18_Click"/>
                </div>
                <div id="goodbye" runat="server" class="panel2">
                    <asp:Label ID="Label17" runat="server" Text="Gidiyor musun? =(" Font-Size="X-Large"></asp:Label>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="Gitmek istediğine emin misin? Bu eylem hiç bir şekilde geri alınamaz. Eğer gitmek istediğinden eminsen istersen tüm verilerini silebilirsin. Tüm verilerini sildiğinde paylaştığın gönderiler dahil Artado veri tabanlarında seninle ilgili olan tüm veriler silinecek.." Font-Size="Medium"></asp:Label>
                    <br />
                    <asp:Button ID="Button12" runat="server" Text="Sadece hesabımı sil." CssClass="buttons2" OnClick="Button12_Click"/><br />
                    <asp:Button ID="Button13" runat="server" Text="Tüm verilerimi sil" CssClass="buttons2" OnClick="Button13_Click"/><br />
                    <asp:Button ID="Button14" runat="server" Text="Geri dön" CssClass="buttons2" OnClick="Button14_Click"/>
                </div>

                <div id="about" runat="server">
                    <img src="/Icons/android-chrome-192x192.png"/>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Artado My Account, kullanıcı gizliliğine saygı duyar ve olabildiğince az kişisel veri toplar. Artado My Account, sayesinde Artado servislerini ve diğer bağlantılı servisleri tek hesap ile kullanabilirsiniz. Artado My Account, şu anda sadece Türkçe dilinde hizmet vermektedir."></asp:Label>
                </div>
            </div>         
        </div>
    </form>
</body>
</html>
