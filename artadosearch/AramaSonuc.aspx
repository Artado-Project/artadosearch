<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AramaSonuc.aspx.cs" Inherits="AramaSonuc" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="AramaSonuc.css" rel="stylesheet" />
<link href="bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<link rel="shortcut icon" href="/Icons/favicon.ico" />
<script type="text/javascript" src="/js/default.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta charset="utf-8"/>
<link rel="apple-touch-icon" href="/Icons/apple-touch-icon.png"/>
<link rel="apple-touch-startup-image" href="/Icons/apple-touch-icon.png"/>
<link rel="icon" sizes="192x192" href="/Icons/android-chrome-192x192.png"/>
<meta name="theme-color" content="#517BBA"/>
<link rel="search" type="application/opensearchdescription+xml" title="Artado Search" href="https://www.artadosearch.com/opensearch.xml"/>
<meta name="apple-mobile-web-app-capable" content="yes"/>
<meta name="apple-mobile-web-app-status-bar-style" content="black-translucent"/>
<link rel="manifest" href="js/manifest.json"/>
<script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
<meta name="keywords" content="arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, sade, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, türkiye" />
<meta name="description" content="Open Source, Safe and Anonymous Search Engine" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div style= "margin-bottom:20px" class="üstkısım">
            <asp:Panel ID="Panel2" runat="server" CssClass="arama2" BorderStyle="Outset">
                 <asp:TextBox ID="arama_çubugu2" runat="server" CssClass="textbox" BorderStyle="None" TextMode="Search" ValidateRequestMode="Disabled"></asp:TextBox>
        <asp:ImageButton ID="Search" runat="server" Height="29px" OnClick="Button1_Click" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None"/>
                </asp:Panel>
            <asp:ImageButton ID="Image1" runat="server" CssClass="image" ImageUrl="Icons/android-chrome-192x192.png" OnClick="Image1_Click1"  /> 
            <br />
            <br />
            <asp:Button ID="Web" runat="server" Text="Web" CssClass="web" BorderStyle="None" BackColor="Transparent" OnClick="Web_Click"/>
            <asp:Button ID="Görsel" runat="server" Text="<%$Resources:Default, Görsel %>" CssClass="görsel" BorderStyle="None" BackColor="Transparent" OnClick="Görsel_Click"/>
            <asp:Button ID="Sözlük" runat="server" Text="<%$Resources:Default, Sözlük %>" CssClass="sözlük" BorderStyle="None" BackColor="Transparent" OnClick="Sözlük_Click"/>
            <asp:Button ID="Müzik" runat="server" Text="<%$Resources:Default, Film %>" CssClass="müzik" BorderStyle="None" BackColor="Transparent" OnClick="Müzik_Click"/>
            <asp:Button ID="Akademik" runat="server" Text="<%$Resources:Default, Akademik %>" CssClass="akademik" BorderStyle="None" BackColor="Transparent" OnClick="Akademik_Click"/>
             </div>

        <div id="con"> </div>

        <div id="Showcase" runat="server" class="vitrin">
            <asp:Label ID="Label12" runat="server" Text="Vitrin" Font-Size="X-Large" Font-Bold="true"></asp:Label>&nbsp;
            <asp:Label ID="Label189" runat="server" Text="Beta" Font-Size="Small" Font-Bold="true"></asp:Label>
            <br />
            <div style="overflow:scroll; overflow-y:hidden" id="scroll">
                 <asp:DataList runat="server" ID="Ürünler">
                    <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="ürün">
                        <asp:Image ID="Image3" runat="server" src='<%# Eval("Pic") %>' CssClass="ürün_image"/> <br />
                        <div class="ürün_txt">
                            <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Label4" runat="server" Text='<%# Eval("Title") %>' Font-Size="Small"></asp:Label></a><br />
                        </div>
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("Source") %>' Font-Size="X-Small" ForeColor="Green"></asp:Label><br />
                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("Price") %>' Font-Size="Small"></asp:Label>
                    </asp:Panel>
                </ItemTemplate>
                </asp:DataList>
            </div>
            <br />
        </div>
        <div style="height:20px;"></div>
        <div id="News" runat="server">
            <asp:Label ID="Label4" runat="server" Text='Haberler' Font-Size="X-Large"></asp:Label>
            <asp:Repeater ID="News_Results" runat="server">
                <ItemTemplate>
                    <div id="news_result" style="background: url('<%# Eval("Image") %>') no-repeat center center fixed; background-size: cover;">
                        <div id="news_text">
                            <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Label4" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a><br />
                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("Date") %>' Font-Size="Small" ForeColor="White"></asp:Label>
                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("Link") %>' Font-Size="Small" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" CssClass="panel2">
                <asp:Image ID="Image2" runat="server" CssClass="panelimage"/>
                <asp:Label ID="Ad" runat="server" Text="" Font-Bold="true"></asp:Label>
                <br />
                <asp:Label ID="Meslek" runat="server" Text="" Font-Size="Small"></asp:Label>
                <br />
                <asp:Label ID="Doğum" runat="server" Text=""></asp:Label>
            <br />
            </asp:Panel>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" GroupingText="Hesap Makinesi" CssClass="hesap"
                Width="280px">
                <table class="style1">
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="TextBox1" runat="server" Height="60px" Width="250px"
                                CssClass="kutu"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button16" runat="server" Height="60px" Text="C" Width="60px" OnClick="Button16_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="Button10" runat="server" Height="60px" 
                                Text="/" Width="60px" OnClick="B10_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button11" runat="server" Height="60px" 
                                Text="*" Width="60px" OnClick="B11_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button12" runat="server" Height="60px" 
                                Text="-" Width="60px" OnClick="B12_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button7" runat="server" Height="60px" 
                                Text="7" Width="60px" OnClick="B7_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button8" runat="server" Height="60px" 
                                Text="8" Width="60px" OnClick="B8_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button9" runat="server" Height="60px" 
                                Text="9" Width="60px" OnClick="B9_Click" />
                        </td>
                        <td rowspan="2">
                            <asp:Button ID="Button13" runat="server" Height="120px" 
                                Text="+" Width="60px" OnClick="B13_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button4" runat="server" Height="60px" 
                                Text="4" Width="60px" OnClick="B4_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" Height="60px" 
                                Text="5" Width="60px" OnClick="B5_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button6" runat="server" Height="60px" 
                                Text="6" Width="60px" OnClick="B6_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Height="60px" 
                                Text="1" Width="60px" OnClick="B1_Click1" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Height="60px" 
                                Text="2" Width="60px" OnClick="B2_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" Height="60px" 
                                Text="3" Width="60px" OnClick="B3_Click" />
                        </td>
                        <td rowspan="2">
                            <asp:Button ID="Button14" runat="server" Height="120px"
                                Text="=" Width="60px" OnClick="B14_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="Button15" runat="server" Height="60px" 
                                Text="0" Width="199px" OnClick="B15_Click" />
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button7" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button8" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button9" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button11" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button12" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button13" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button14" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button15" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Button16" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

        
        <asp:Panel ID="Panel4" runat="server" CssClass="ınfo" BorderStyle="Groove">
            <asp:DataList ID="InfoBox" runat="server">
                <ItemTemplate>
                        <asp:Panel ID="Onay" runat="server">
                            <asp:Label ID="OnayTxt" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                        </asp:Panel>
                        <asp:Label ID="title" runat="server" Text='<%# Eval("InfoTitle") %>' Font-Size="Larger" Font-Bold="true"></asp:Label>
                        <asp:Image ID="Pic" runat="server" src='<%# Eval("Pic") %>' CssClass="ınfoimage"/>
                        <br />
                        <asp:Label ID="Label17" runat="server" Text='<%# Eval("Category") %>' Font-Size="Small"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Info") %>' Font-Size="Medium"></asp:Label>
                        <br /> 
                        <a href='<%# Eval("InfoLink") %>' style="text-decoration:none;" target="_blank" rel="nofollow"><asp:Label ID="Label9" runat="server" Text="Daha fazla" Font-Size="Small"></asp:Label></a>
                        <br />
                        <br />
                        <asp:Label ID="Label19" runat="server" Text='<%$Resources:Default, Kaynaklar %>' Font-Size="Larger"></asp:Label>
                        <br />
                        <br />
                        <a id="Link1a" href='<%# Eval("Link1") %>' class="link" style="text-decoration:none;" target="_blank" rel="nofollow"><asp:Label ID="Link1" runat="server" Text='<%# Eval("Link1Name") %>' Font-Size="Small"></asp:Label></a>
                        <a href='<%# Eval("Link2") %>' class="link" style="text-decoration:none;" target="_blank" rel="nofollow"><asp:Label ID="Link2" runat="server" Text='<%# Eval("Link2Name") %>' Font-Size="Small"></asp:Label></a>
                        <a href='<%# Eval("Link3") %>' class="link" style="text-decoration:none;" target="_blank" rel="nofollow"><asp:Label ID="Link3" runat="server" Text='<%# Eval("Link3Name") %>' Font-Size="Small"></asp:Label></a>
                        <br />
                        <br />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
         
        <asp:Panel ID="Panel10" runat="server">
            <asp:Label ID="Label3" runat="server" Text='Benzer Sonuçlar' Font-Size="X-Large"></asp:Label>
            <asp:DataList ID="Suggestions" runat="server">
                <ItemTemplate>
                        <asp:Panel ID="Sonuclar" runat="server" CssClass="suggest" BorderStyle="Groove">
                            <asp:Image ID="Image3" runat="server" src='<%# Eval("Pic") %>' CssClass="suggest_image"/> <br />
                            <a href="/search?i=<%# Eval("InfoTitle") %>" rel="nofollow"> <asp:Label ID="Label4" runat="server" Text='<%# Eval("InfoTitle") %>' Font-Size="Large"></asp:Label></a><br />
                        </asp:Panel>
                        <br />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>

       <asp:Panel ID="HavaDurumu" runat="server" CssClass="ınfo" BorderStyle="Groove"> 
             <asp:DropDownList ID="Ülkeler" runat="server" AutoPostBack="True">
                 <asp:ListItem>Türkiye</asp:ListItem>
                 <asp:ListItem>İngiltere</asp:ListItem>
                 <asp:ListItem>Fransa</asp:ListItem>
                 <asp:ListItem>Almanya</asp:ListItem>
                 <asp:ListItem>Azerbaycan</asp:ListItem>
                 <asp:ListItem>KKTC</asp:ListItem>
             </asp:DropDownList>
             <br />
             <br />
             <asp:DropDownList ID="İllerTR" runat="server" AutoPostBack="True">
                 <asp:ListItem>Ankara</asp:ListItem>
                 <asp:ListItem>Adana</asp:ListItem>
                 <asp:ListItem>Adıyaman</asp:ListItem>
                 <asp:ListItem>Afyonkarahisar</asp:ListItem>
                 <asp:ListItem>Ağrı</asp:ListItem>
                 <asp:ListItem>Aksaray</asp:ListItem>
                 <asp:ListItem>Amasya</asp:ListItem>
                 <asp:ListItem>Antalya</asp:ListItem>
                 <asp:ListItem>Ardahan</asp:ListItem>
                 <asp:ListItem>Artvin</asp:ListItem>
                 <asp:ListItem>Aydın</asp:ListItem>
                 <asp:ListItem>Balıkesir</asp:ListItem>
                 <asp:ListItem>Bartın</asp:ListItem>
                 <asp:ListItem>Batman</asp:ListItem>
                 <asp:ListItem>Bayburt</asp:ListItem>
                 <asp:ListItem>Bilecik</asp:ListItem>
                 <asp:ListItem>Bingöl</asp:ListItem>
                 <asp:ListItem>Bitlis</asp:ListItem>
                 <asp:ListItem>Bolu</asp:ListItem>
                 <asp:ListItem>Burdur</asp:ListItem>
                 <asp:ListItem>Bursa</asp:ListItem>
                 <asp:ListItem>Çanakkale</asp:ListItem>
                 <asp:ListItem>Çankırı</asp:ListItem>
                 <asp:ListItem>Çorum</asp:ListItem>
                 <asp:ListItem>Denizli</asp:ListItem>
                 <asp:ListItem>Diyarbakır</asp:ListItem>
                 <asp:ListItem>Düzce</asp:ListItem>
                 <asp:ListItem>Edirne</asp:ListItem>
                 <asp:ListItem>Elazığ</asp:ListItem>
                 <asp:ListItem>Erzincan</asp:ListItem>
                 <asp:ListItem>Erzurum</asp:ListItem>
                 <asp:ListItem>Eskişehir</asp:ListItem>
                 <asp:ListItem>Gaziantep</asp:ListItem>
                 <asp:ListItem>Giresun</asp:ListItem>
                 <asp:ListItem>Gümüşhane</asp:ListItem>
                 <asp:ListItem>Hakkari</asp:ListItem>
                 <asp:ListItem>Hatay</asp:ListItem>
                 <asp:ListItem>Iğdır</asp:ListItem>
                 <asp:ListItem>Isparta</asp:ListItem>
                 <asp:ListItem>İstanbul</asp:ListItem>
                 <asp:ListItem>İzmir</asp:ListItem>
                 <asp:ListItem>Kahramanmaraş</asp:ListItem>
                 <asp:ListItem>Karabük</asp:ListItem>
                 <asp:ListItem>Karaman</asp:ListItem>
                 <asp:ListItem>Kars</asp:ListItem>
                 <asp:ListItem>Kastamonu</asp:ListItem>
                 <asp:ListItem>Kayseri</asp:ListItem>
                 <asp:ListItem>Kırıkkale</asp:ListItem>
                 <asp:ListItem>Kırşehir</asp:ListItem>
                 <asp:ListItem>Kilis</asp:ListItem>
                 <asp:ListItem>Kocaeli</asp:ListItem>
                 <asp:ListItem>Konya</asp:ListItem>
                 <asp:ListItem>Kütahya</asp:ListItem>
                 <asp:ListItem>Malatya</asp:ListItem>
                 <asp:ListItem>Manisa</asp:ListItem>
                 <asp:ListItem>Mardin</asp:ListItem>
                 <asp:ListItem>Mersin</asp:ListItem>
                 <asp:ListItem>Muğla</asp:ListItem>
                 <asp:ListItem>Muş</asp:ListItem>
                 <asp:ListItem>Nevşehir</asp:ListItem>
                 <asp:ListItem>Niğde</asp:ListItem>
                 <asp:ListItem>Ordu</asp:ListItem>
                 <asp:ListItem>Osmaniye</asp:ListItem>
                 <asp:ListItem>Rize</asp:ListItem>
                 <asp:ListItem>Sakarya</asp:ListItem>
                 <asp:ListItem>Siirt</asp:ListItem>
                 <asp:ListItem>Sinop</asp:ListItem>
                 <asp:ListItem>Sivas</asp:ListItem>
                 <asp:ListItem>Şanlıurfa</asp:ListItem>
                 <asp:ListItem>Şırnak</asp:ListItem>
                 <asp:ListItem>Tekirdağ</asp:ListItem>
                 <asp:ListItem>Tokat</asp:ListItem>
                 <asp:ListItem>Trabzon</asp:ListItem>
                 <asp:ListItem>Tunceli</asp:ListItem>
                 <asp:ListItem>Uşak</asp:ListItem>
                 <asp:ListItem>Van</asp:ListItem>
                 <asp:ListItem>Yalova</asp:ListItem>
                 <asp:ListItem>Yozgat</asp:ListItem>
                 <asp:ListItem>Zonguldak</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerEN" runat="server" AutoPostBack="True">
                 <asp:ListItem>London</asp:ListItem>
                 <asp:ListItem>Belfast</asp:ListItem>
                 <asp:ListItem>Belvedere</asp:ListItem>
                 <asp:ListItem>Bexley</asp:ListItem>
                 <asp:ListItem>Bournemouth</asp:ListItem>
                 <asp:ListItem>Bromley</asp:ListItem>
                 <asp:ListItem>Brighton</asp:ListItem>
                 <asp:ListItem>Cambridge</asp:ListItem>
                 <asp:ListItem>Cardiff</asp:ListItem>
                 <asp:ListItem>Cheltenham</asp:ListItem>
                 <asp:ListItem>Coventry</asp:ListItem>
                 <asp:ListItem>Doncaster</asp:ListItem>
                 <asp:ListItem>Dover</asp:ListItem>
                 <asp:ListItem>Durham</asp:ListItem>
                 <asp:ListItem>Edinburgh</asp:ListItem>
                 <asp:ListItem>Edmonton</asp:ListItem>
                 <asp:ListItem>Exeter</asp:ListItem>
                 <asp:ListItem>Fyfield</asp:ListItem>
                 <asp:ListItem>Glasgow</asp:ListItem>
                 <asp:ListItem>Greenwich</asp:ListItem>
                 <asp:ListItem>Grimsby</asp:ListItem>
                 <asp:ListItem>Harpenden</asp:ListItem>
                 <asp:ListItem>Inverness</asp:ListItem>
                 <asp:ListItem>Leeds</asp:ListItem>
                 <asp:ListItem>Lincoln</asp:ListItem>
                 <asp:ListItem>Newham</asp:ListItem>
                 <asp:ListItem>Longford</asp:ListItem>
                 <asp:ListItem>Luton</asp:ListItem>
                 <asp:ListItem>Manchester</asp:ListItem>
                 <asp:ListItem>Merthyr Tydfil</asp:ListItem>
                 <asp:ListItem>Oldham</asp:ListItem>
                 <asp:ListItem>Oxford</asp:ListItem>
                 <asp:ListItem>Peterborough</asp:ListItem>
                 <asp:ListItem>Poole</asp:ListItem>
                 <asp:ListItem>Reading</asp:ListItem>
                 <asp:ListItem>Southampton</asp:ListItem>
                 <asp:ListItem>Southend-on-Sea</asp:ListItem>
                 <asp:ListItem>Southgate</asp:ListItem>
                 <asp:ListItem>St Albans</asp:ListItem>
                 <asp:ListItem>Stansted</asp:ListItem>
                 <asp:ListItem>Stoke-on-Trent</asp:ListItem>
                 <asp:ListItem>Stratford-upon-Avon</asp:ListItem>
                 <asp:ListItem>Swanscombe</asp:ListItem>
                 <asp:ListItem>Wallington</asp:ListItem>
                 <asp:ListItem>Waltham Cross</asp:ListItem>
                 <asp:ListItem>Waltham Forest</asp:ListItem>
                 <asp:ListItem>Watford</asp:ListItem>
                 <asp:ListItem>Welling</asp:ListItem>
                 <asp:ListItem>Wembley</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerFR" runat="server" AutoPostBack="True">
                 <asp:ListItem>Paris</asp:ListItem>
                 <asp:ListItem>Marsilya</asp:ListItem>
                 <asp:ListItem>Lyon</asp:ListItem>
                 <asp:ListItem>Toulouse</asp:ListItem>
                 <asp:ListItem>Nice</asp:ListItem>
                 <asp:ListItem>Nantes</asp:ListItem>
                 <asp:ListItem>Strasbourg</asp:ListItem>
                 <asp:ListItem>Montpellier</asp:ListItem>
                 <asp:ListItem>Bordeaux</asp:ListItem>
                 <asp:ListItem>Lille</asp:ListItem>
                 <asp:ListItem>Rennes</asp:ListItem>
                 <asp:ListItem>Reims</asp:ListItem>
                 <asp:ListItem>Le Havre</asp:ListItem>
                 <asp:ListItem>Saint-Étienne</asp:ListItem>
                 <asp:ListItem>Toulon</asp:ListItem>
                 <asp:ListItem>Grenoble</asp:ListItem>
                 <asp:ListItem>Dijon</asp:ListItem>
                 <asp:ListItem>Angers</asp:ListItem>
                 <asp:ListItem>Villeurbanne</asp:ListItem>
                 <asp:ListItem>Saint-Denis</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerDE" runat="server" AutoPostBack="True">
                 <asp:ListItem>Berlin</asp:ListItem>
                 <asp:ListItem>Bayern</asp:ListItem>
                 <asp:ListItem>Baden-Württemberg</asp:ListItem>
                 <asp:ListItem>Nordrhein-Westfalen</asp:ListItem>
                 <asp:ListItem>Hessen</asp:ListItem>
                 <asp:ListItem>Sachsen</asp:ListItem>
                 <asp:ListItem>Niedersachsen</asp:ListItem>
                 <asp:ListItem>Rheinland-Pfalz</asp:ListItem>
                 <asp:ListItem>Thüringen</asp:ListItem>
                 <asp:ListItem>Brandenburg</asp:ListItem>
                 <asp:ListItem>Sachsen-Anhalt</asp:ListItem>
                 <asp:ListItem>Mecklenburg-Vorpommern</asp:ListItem>
                 <asp:ListItem>Schleswig-Holstein</asp:ListItem>
                 <asp:ListItem>Saarland</asp:ListItem>
                 <asp:ListItem>Bremen</asp:ListItem>
                 <asp:ListItem>Hamburg</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerAZ" runat="server" AutoPostBack="True">
                 <asp:ListItem>Bakü</asp:ListItem>
                 <asp:ListItem>Ağdam</asp:ListItem>
                 <asp:ListItem>Ağdaş</asp:ListItem>
                 <asp:ListItem>Ağstafa</asp:ListItem>
                 <asp:ListItem>Ağsu</asp:ListItem>
                 <asp:ListItem>Astara</asp:ListItem>
                 <asp:ListItem>Aran</asp:ListItem>
                 <asp:ListItem>Naxçıvan</asp:ListItem>
                 <asp:ListItem>Şuşa</asp:ListItem>
             </asp:DropDownList>

             <asp:DropDownList ID="İllerKKTC" runat="server" AutoPostBack="True">
                 <asp:ListItem>Lefkoşa</asp:ListItem>
                 <asp:ListItem>Gazimağusa</asp:ListItem>
                 <asp:ListItem>Girne</asp:ListItem>
             </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Image ID="HavaImg" runat="server" CssClass="ınfoimage" Width="100px" Height="100px"/>
             <asp:Label ID="SıcaklıkTxt" runat="server" Text='' Font-Size="Larger" Font-Bold="true"></asp:Label>&nbsp;
             <asp:Label ID="DurumTxt" runat="server" Text='' Font-Size="Medium"></asp:Label>
             <br />
             <asp:Label ID="Min" runat="server" Text='' Font-Size="Medium"></asp:Label>
             <br />
             <asp:Label ID="Max" runat="server" Text='' Font-Size="Medium"></asp:Label>
             <br />
             <asp:Label ID="Hissedilen" runat="server" Text='' Font-Size="Medium"></asp:Label>
             <br />
             <asp:Label ID="Doğuş" runat="server" Text='' Font-Size="Medium"></asp:Label>
             <br />
             <asp:Label ID="Batış" runat="server" Text='' Font-Size="Medium"></asp:Label>
        </asp:Panel>

       <asp:Panel ID="Panel8" runat="server" BorderStyle="Solid" CssClass="panel2" style="padding: 10px 10px 10px 10px;">
             <asp:Image ID="WeatherImg" runat="server" CssClass="ınfoimage" Width="100px" Height="100px"/>
             <asp:Label ID="City" runat="server" Text='' Font-Size="Larger" Font-Bold="true"></asp:Label><br />
             <asp:Label ID="Weathertext" runat="server" Text='' Font-Size="Larger" Font-Bold="true"></asp:Label>
             <asp:Label ID="Weathertext2" runat="server" Text='' Font-Size="Larger" Font-Bold="true"></asp:Label><br />
             <asp:Label ID="Feels_Like" runat="server" Text='' Font-Size="Medium"></asp:Label>
        </asp:Panel>

       <asp:Panel ID="Translate" runat="server" CssClass="translate" BorderStyle="Groove">
             <asp:DropDownList ID="Diller1" runat="server" AutoPostBack="True">
                <asp:ListItem Text="<%$Resources:Default, İngilizce %>" Value="en-US"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Türkçe %>" Value="tr-TR"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Fransızca %>" Value="fr-FR"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Almanca %>" Value="de-DE"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, AzeriTR %>" Value="en-AU"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, İtalyanca %>" Value="it-IT"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Rusça %>" Value="ru-RU"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Çince %>" Value="zh-CHS"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, İspanyolca %>" Value="es-ES"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Portekizce %>" Value="pt-PT"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Korece %>" Value="ko-KR"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Japonca %>" Value="ja-JP"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Macarca %>" Value="hu-HU"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Bulgarca %>" Value="bg-BG"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Boşnakça %>" Value="en-BZ"></asp:ListItem>
             </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Diller2" runat="server" AutoPostBack="True">
                <asp:ListItem Text="<%$Resources:Default, Türkçe %>" Value="tr-TR"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, İngilizce %>" Value="en-US"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Fransızca %>" Value="fr-FR"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Almanca %>" Value="de-DE"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, AzeriTR %>" Value="en-AU"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, İtalyanca %>" Value="it-IT"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Rusça %>" Value="ru-RU"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Çince %>" Value="zh-CHS"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, İspanyolca %>" Value="es-ES"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Portekizce %>" Value="pt-PT"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Korece %>" Value="ko-KR"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Japonca %>" Value="ja-JP"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Macarca %>" Value="hu-HU"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Bulgarca %>" Value="bg-BG"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Default, Boşnakça %>" Value="en-BZ"></asp:ListItem>
             </asp:DropDownList><br />
            <asp:TextBox ID="Input" runat="server" BackColor="Transparent" placeholder="Metin girin" Width="300px" BorderStyle="Outset" ForeColor="White" TextMode="MultiLine" ValidateRequestMode="Enabled" ViewStateMode="Enabled"></asp:TextBox>&nbsp;&nbsp;
            <asp:TextBox ID="Output" runat="server" BackColor="Transparent" placeholder="Sonuç" Width="300px" BorderStyle="Outset" ForeColor="White" TextMode="MultiLine" ValidateRequestMode="Enabled" ViewStateMode="Enabled" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="Button17" runat="server" Text="Çevir" OnClick="Button17_Click" />
        </asp:Panel>

        <asp:Panel ID="Panel6" runat="server" CssClass="sözlüköneri" BorderStyle="None">
            <asp:DataList ID="SozlukOneri" runat="server">
                <ItemTemplate>
                   <asp:Panel ID="Sonuclar" runat="server">
                       <asp:Label ID="title" runat="server" Text='<%# Eval("Kelime") %>' Font-Size="Larger" Font-Bold="true"></asp:Label> 
                       <br />
                       <br />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Anlam") %>' Font-Size="Medium"></asp:Label>
                   </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
            <br />        
        </asp:Panel>

        <asp:Panel ID="IPPanel" runat="server" CssClass="sözlüköneri" BorderStyle="None">
            <asp:Label ID="title" runat="server" Text='<%$Resources:Default, IP %>' Font-Size="Larger" Font-Bold="true"></asp:Label> 
            <br />
            <br />
            <asp:Label ID="IP" runat="server" Text='' Font-Size="Medium"></asp:Label> &nbsp &nbsp
            <asp:Label ID="Label9" runat="server" Text='<%$Resources:Default, Uyarı %>' Font-Size="Small"></asp:Label>
            <br />
            <br />
        </asp:Panel>

        <div id="Filtre_Main" style="margin-left:50px; margin-top:10px;">
            <div id="Results" runat="server" style="display: inline">
                <asp:Label ID="Label15" runat="server" Text="<%$Resources:Default, Artado1 %>" CssClass="label"></asp:Label> &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="Google">Google</asp:ListItem>
                    <asp:ListItem Value="Artado">Artado</asp:ListItem>
                    <asp:ListItem Value="Bing">Bing</asp:ListItem>
                    <asp:ListItem Value="Yahoo">Yahoo</asp:ListItem>
                    <asp:ListItem Value="Baidu">Baidu</asp:ListItem>
                    <asp:ListItem Value="Github">Github</asp:ListItem>
                    <asp:ListItem Value="Scholar">Google Scholar</asp:ListItem>
                    <asp:ListItem Value="Base">BASE</asp:ListItem>
                </asp:DropDownList>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <div id="Filtre" runat="server">
                <asp:Label ID="Sort" runat="server" Text="<%$Resources:Default, Sırala %>" CssClass="label"></asp:Label> 
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Text="<%$Resources:Default, Alakaya %>" Value="Puan"></asp:ListItem>                    
                    <asp:ListItem Text="<%$Resources:Default, Eski %>" Value="Alaka"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Yeni %>" Value="Tarih"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Lang" runat="server" Text="<%$Resources:Default, Lang %>"></asp:Label>
                <asp:DropDownList ID="ScholarFiltre" runat="server" AutoPostBack="True">
                    <asp:ListItem Text="<%$Resources:Default, Türkçe %>" Value="tr-TR"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, İngilizce %>" Value="en-US"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Fransızca %>" Value="fr-FR"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Almanca %>" Value="de-DE"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, AzeriTR %>" Value="en-AU"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, İtalyanca %>" Value="it-IT"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Rusça %>" Value="ru-RU"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Çince %>" Value="zh-CHS"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, İspanyolca %>" Value="es-ES"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Portekizce %>" Value="pt-PT"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Korece %>" Value="ko-KR"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Japonca %>" Value="ja-JP"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Macarca %>" Value="hu-HU"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Bulgarca %>" Value="bg-BG"></asp:ListItem>
                    <asp:ListItem Text="<%$Resources:Default, Boşnakça %>" Value="en-BZ"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Panel ID="Text" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="label"></asp:Label> <br />
            </asp:Panel>
        </div>

        <asp:Panel ID="Panel3" runat="server" BorderStyle="Groove" class="iletişim">
            <asp:Label ID="İletişimBaşlık" runat="server" Text="Teşekkür ederiz!" Font-Size="Larger" Font-Bold="true" ForeColor="#517BBA"></asp:Label>
            <br />
            <asp:Label ID="İletişimAçıklama" runat="server" Text="ArtadoSearch'ı ilk kullanan kişilerden birisiniz. Bize neleri beğenip neleri beğenmediğinizi anlatırsanız size daha iyi bir hizmet sunmamızda katkı sağlarsınız." Font-Size="Medium" ForeColor="#517BBA"></asp:Label>
            <br /> 
            <asp:TextBox ID="Mail" runat="server" PlaceHolder="E-posta" BackColor="White" BorderStyle="Outset" ViewStateMode="Disabled"></asp:TextBox>
            <br />
            <br />
            <textarea id="Deneyim" runat="server" placeholder="Deneyiminizi anlatın" cols="20" rows="2" maxlenght="500"></textarea>
            <asp:Button ID="Gönder" runat="server" Text="Gönder" OnClick="Gönder_Click" />
            <asp:Label ID="Sonuc" runat="server" Text="" Font-Size="Small" Font-Bold="true"></asp:Label>
            </asp:Panel>

            <!--Web Arama-->
             <asp:Panel ID="WebArama" runat="server" class="sonuclar">
                <asp:Repeater runat="server" ID="rptAramaSonuclari" OnItemCommand="rptAramaSonuclari_ItemCommand">
                    <ItemTemplate> 
                        <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                            <asp:Panel ID="Popular" runat="server">
                                <asp:Label ID="Label11" runat="server" Text="Popüler" Font-Size="Small"></asp:Label>
                                <br />
                            </asp:Panel>
                            <asp:Image ID="Image4" runat="server" ImageUrl='<%# Eval("favicon") %>' CssClass="danger"/>
                            <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a> &nbsp;
                            <a href="https://www.translatetheweb.com/?ref=SERP&br=ro&mkt=tr-TR&dl=en&lp=Auto_TR&a=<%# Eval("Link") %>" rel="nofollow" target="_blank"> <asp:Label ID="Label6" runat="server" Text='Bu sayfayı çevir' Font-Size="Small"></asp:Label></a> <br/>
                            <asp:Image ID="danger" runat="server" ImageUrl="/tehlıke.png" CssClass="danger"/>
                            <asp:Label ID="Link" runat="server" FontSize="Small" Text='<%# Eval("Link") %>' Font-Size="Small" CssClass="linktxt" ForeColor="Green"></asp:Label> <br />
                            <asp:Label ID="Content" runat="server" FontSize="Small" Text='<%# Eval("Content1") %>' Font-Size="Small"></asp:Label><br />
                       </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater> 
                 <div id="Google" runat="server">
                     <script async src="https://cse.google.com/cse.js?cx=160e826a9c5ebe821"></script>
                     <div class="gcse-searchresults-only" enablehistory="false" runat="server"></div>
                 </div>

                 <div id="OtherResults" runat="server">
                     <asp:Label ID="ResultsTxt" runat="server" Text="Label"></asp:Label>
                     <div style="text-align:center;">
                        <asp:Panel ID="Panel7" runat="server">
                            <asp:HyperLink ID="HyperLink5" runat="server"><-- Önceki Sayfa</asp:HyperLink>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="HyperLink6" runat="server">Sonraki Sayfa --></asp:HyperLink>
                        </asp:Panel>
                     </div>
                 </div>

                <div style="text-align:center;">
                <asp:Panel ID="PageSelect" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="label"></asp:Label>            
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server"><-- Önceki Sayfa</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink2" runat="server">Sonraki Sayfa --></asp:HyperLink>
                </asp:Panel>
              </div>
        </asp:Panel>

        <!--Görsel Arama-->
        <asp:Panel ID="GörselArama" runat="server" class="webarama">
            <asp:DataList runat="server" ID="GorselSonuclar">
                <ItemTemplate> 
                <asp:Panel ID="Sonuclar" runat="server" CssClass="görselsonuc">
                    <asp:Image ID="Image3" runat="server" src='<%# Eval("GörselLink") %>' CssClass="gorsel"/> <br />
                    <a href="url.aspx?Link=<%# Eval("AsılLink") %>" rel="nofollow"> <asp:Label ID="Label4" runat="server" Text='<%# Eval("GorselTitle") %>' Font-Size="Small"></asp:Label></a>
                </asp:Panel>
            </ItemTemplate>
            </asp:DataList>
            <br />
            <script async src="https://cse.google.com/cse.js?cx=85361f53908d000b2"></script>
            <div class="gcse-searchresults-only" id="GoogleImage" runat="server"></div>
        </asp:Panel>

        <!--Sözlük Arama-->
        <asp:Panel ID="SözlükArama" runat="server" class="sonuclar">
                <asp:Repeater runat="server" ID="sözlüksonuc" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <%# Eval("Kelime") %> <br />
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Kullanıcı") %>' Font-Size="X-Small"/>
                        <asp:Label ID="Labe20" runat="server" Text=' tarafından ' Font-Size="X-Small"/>
                        <asp:Label ID="Labe21" runat="server" Text='<%# Eval("Tarih") %>' Font-Size="X-Small"/> 
                        <asp:Label ID="Labe22" runat="server" Text='tarihinde eklendi' Font-Size="X-Small"/><br />
                        <%# Eval("Anlam") %><br />
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                   </asp:Panel>
            

        <!--Film Arama-->
        <asp:Panel ID="MüzikArama" runat="server" class="sonuclar">
                <asp:Repeater runat="server" ID="Filmler" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="sonuc">
                        <asp:Image ID="Image2" runat="server" CssClass="panelimage" ImageUrl='<%# Eval("Pic") %>'/>
                        <asp:Label ID="Title" runat="server" Text='<%# Eval("Name") %>' Font-Size="Large"></asp:Label> &nbsp;
                        <asp:Label ID="Year" runat="server" FontSize="Small" Text='<%# Eval("Year") %>' Font-Size="Small" CssClass="linktxt" ForeColor="Green"></asp:Label> <br />
                        <asp:Label ID="Actors" runat="server" FontSize="Small" Text='<%# Eval("Actors") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Score" runat="server" FontSize="Small" Text='<%# Eval("Score") %>' Font-Size="Medium"></asp:Label><br />
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
          </asp:Panel>


        <!--Akademik Arama-->
             <asp:Panel ID="Makaleler" runat="server" class="sonuclar">
            <asp:Repeater runat="server" ID="AkademikSonuçlar" OnItemCommand="rptAramaSonuclari_ItemCommand">
                <ItemTemplate> 
                    <asp:Panel ID="Sonuclar" runat="server" CssClass="akademiksonuc">
                        <a href="url.aspx?Link=<%# Eval("Link") %>" rel="nofollow"> <asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>' Font-Size="Large"></asp:Label></a> &nbsp;
                        <a href="https://www.translatetheweb.com/?ref=SERP&br=ro&mkt=tr-TR&dl=en&lp=Auto_TR&a=<%# Eval("Link") %>" rel="nofollow" target="_blank"> <asp:Label ID="Label6" runat="server" Text='Bu sayfayı çevir' Font-Size="Small"></asp:Label></a> <br/>
                        <asp:Label ID="Link" runat="server" FontSize="Small" Text='<%# Eval("Link") %>' Font-Size="Small" CssClass="linktxt" ForeColor="Green"></asp:Label> <br />
                        <asp:Label ID="Desc" runat="server" FontSize="Small" Text='<%# Eval("Description") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Label7" runat="server" FontSize="Small" Text='Yazarlar: ' Font-Size="Small"></asp:Label>
                        <asp:Label ID="Label4" runat="server" FontSize="Small" Text='<%# Eval("Author") %>' Font-Size="Small"></asp:Label><br />
                        <asp:Label ID="Label10" runat="server" FontSize="Small" Text='Yıl: ' Font-Size="Small"></asp:Label>
                   </asp:Panel>
                </ItemTemplate>
            </asp:Repeater> 
                 <div style="text-align:center;">
                  <asp:Panel ID="Panel9" runat="server">
                     <asp:Label ID="Label5" runat="server" Text="Label" CssClass="label"></asp:Label>            
                     <br />
                     <asp:HyperLink ID="HyperLink3" runat="server">Önceki Sayfa</asp:HyperLink>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:HyperLink ID="HyperLink4" runat="server">Sonraki Sayfa</asp:HyperLink>
                 </asp:Panel>
           </div>
            </asp:Panel> 
        <footer class="page-footer">
	            <div class="footer">
                    <hr class="çizgi"/>
                    <a href="/About" style="text-decoration:none;"><asp:Label ID="Label6" runat="server" Text="<%$Resources:Default, Hakkımızda %>"></asp:Label></a>
                    &nbsp;&nbsp;&nbsp;
                    <a href="/Contact" style="text-decoration:none;"><asp:Label ID="Label10" runat="server" Text="<%$Resources:Default, İletişim %>"></asp:Label></a>
                    &nbsp;&nbsp;&nbsp;
                    <a href="/Manifest" style="text-decoration:none;"><asp:Label ID="Manifest" runat="server" Text="<%$Resources:Default, Manifesto %>"></asp:Label></a>
                    &nbsp;&nbsp;&nbsp;
                    <a href="/Forum" style="text-decoration:none;"><asp:Label ID="Label8" runat="server" Text="<%$Resources:Default, Blog %>"></asp:Label></a>
                    &nbsp;&nbsp;&nbsp;
                    <a href="/Photon" style="text-decoration:none;"><asp:Label ID="Label13" runat="server" Text="Artado Photon"></asp:Label></a>
	            </div>
            </footer>
    </form>
</body>
</html>
