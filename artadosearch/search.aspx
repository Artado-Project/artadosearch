<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="artadosearch.search" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="css/home.css" rel="stylesheet" />
    <link href="css/search.css" rel="stylesheet" />
    <link href="css/otherresults.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/mdb.min.css" type="text/css" />
    <link rel="stylesheet" href="/css/bootstrap-icons.css" />
    <script src="/js/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="/js/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="/js/mdb.min.js"></script>
    <link rel="shortcut icon" href="/images/favicon.ico" />
    <title></title>
</head>
<body id="bdy1" runat="server">
    <form id="form1" runat="server">
        <div class="middle">
            <div class="form-control form-input searchbar">
                <a href="/">
                    <img id="Image1" runat="server" class="logo" /></a>
                <asp:TextBox ID="searchinput" runat="server" CssClass="searchinput" placeholder="<%$Resources:Langs, Slogan %>"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/search.svg" CssClass="search" OnClick="Search" />
            </div>

            <div class="classic_tabs">
                <div id="classic_tabs" runat="server">
                    <a id="w1" runat="server" class="tab" style="display: inline"><i class="bi bi-globe" style="margin-right: 10px;"></i>
                        <asp:Label ID="web" runat="server" Text="Web"></asp:Label></a>
                    <a id="i1" runat="server" class="tab" style="display: inline"><i class="bi bi-card-image" style="margin-right: 10px;"></i>
                        <asp:Label ID="image" runat="server" Text="<%$Resources:Langs, Image %>"></asp:Label></a>
                    <a id="v1" runat="server" class="tab" style="display: inline"><i class="bi bi-play" style="margin-right: 10px;"></i>
                        <asp:Label ID="video" runat="server" Text="<%$Resources:Langs, Video %>"></asp:Label></a>
                    <a id="n1" runat="server" class="tab" style="display: inline"><i class="bi bi-newspaper" style="margin-right: 10px;"></i>
                        <asp:Label ID="news" runat="server" Text="<%$Resources:Langs, News %>"></asp:Label></a>
                    <a id="in1" runat="server" class="tab" style="display: inline"><i class="bi bi-info-circle" style="margin-right: 10px;"></i>
                        <asp:Label ID="info" runat="server" Text="<%$Resources:Langs, Info %>"></asp:Label></a>
                    <a id="m1" runat="server" class="tab" style="display: inline"><i class="bi bi-film" style="margin-right: 10px;"></i>
                        <asp:Label ID="movie" runat="server" Text="<%$Resources:Langs, Film %>"></asp:Label></a>
                    <a id="it1" runat="server" class="tab" style="display: inline"><i class="bi bi-code-slash" style="margin-right: 10px;"></i>
                        <asp:Label ID="it" runat="server" Text="<%$Resources:Langs, IT %>"></asp:Label></a>
                    <a id="a1" runat="server" class="tab" style="display: inline"><i class="bi bi-journals" style="margin-right: 10px;"></i>
                        <asp:Label ID="academic" runat="server" Text="<%$Resources:Langs, Academic %>"></asp:Label></a>
                </div>
            </div>

            <div id="right_tabs" class="right_tabs" runat="server">
                <a id="w2" runat="server" class="tab" style="display: block;"><i class="bi bi-globe" style="margin-right: 10px;"></i></a>
                <a id="i2" runat="server" class="tab" style="display: block"><i class="bi bi-card-image" style="margin-right: 10px;"></i></a>
                <a id="v2" runat="server" class="tab" style="display: block"><i class="bi bi-play" style="margin-right: 10px;"></i></a>
                <a id="n2" runat="server" class="tab" style="display: block"><i class="bi bi-newspaper" style="margin-right: 10px;"></i></a>
                <a id="in2" runat="server" class="tab" style="display: block"><i class="bi bi-info-circle" style="margin-right: 10px;"></i></a>
                <a id="m2" runat="server" class="tab" style="display: block"><i class="bi bi-film" style="margin-right: 10px;"></i></a>
                <a id="it2" runat="server" class="tab" style="display: block"><i class="bi bi-code-slash" style="margin-right: 10px;"></i></a>
                <a id="a2" runat="server" class="tab" style="display: block"><i class="bi bi-journals" style="margin-right: 10px;"></i></a>
            </div>

            <div id="left_tabs" class="left_tabs" runat="server">
                <a id="w3" runat="server" class="tab" style="display: block;"><i class="bi bi-globe" style="margin-right: 10px;"></i></a>
                <a id="i3" runat="server" class="tab" style="display: block"><i class="bi bi-card-image" style="margin-right: 10px;"></i></a>
                <a id="v3" runat="server" class="tab" style="display: block"><i class="bi bi-play" style="margin-right: 10px;"></i></a>
                <a id="n3" runat="server" class="tab" style="display: block"><i class="bi bi-newspaper" style="margin-right: 10px;"></i></a>
                <a id="in3" runat="server" class="tab" style="display: block"><i class="bi bi-info-circle" style="margin-right: 10px;"></i></a>
                <a id="m3" runat="server" class="tab" style="display: block"><i class="bi bi-film" style="margin-right: 10px;"></i></a>
                <a id="it3" runat="server" class="tab" style="display: block"><i class="bi bi-code-slash" style="margin-right: 10px;"></i></a>
                <a id="a3" runat="server" class="tab" style="display: block"><i class="bi bi-journals" style="margin-right: 10px;"></i></a>
            </div>

            <div id="bottom_tabs" class="bottom_tabs" runat="server">
                <a id="A" runat="server" class="tab" style="display: inline;"><i class="bi bi-globe" style="margin-right: 5px; margin-left: 20px"></i></a>
                <a id="A4" runat="server" class="tab" style="display: inline"><i class="bi bi-card-image" style="margin-right: 5px;"></i></a>
                <a id="A5" runat="server" class="tab" style="display: inline"><i class="bi bi-play" style="margin-right: 5px;"></i></a>
                <a id="A6" runat="server" class="tab" style="display: inline"><i class="bi bi-newspaper" style="margin-right: 5px;"></i></a>
                <a id="A7" runat="server" class="tab" style="display: inline"><i class="bi bi-info-circle" style="margin-right: 5px;"></i></a>
                <a id="A8" runat="server" class="tab" style="display: inline"><i class="bi bi-film" style="margin-right: 5px;"></i></a>
                <a id="A9" runat="server" class="tab" style="display: inline"><i class="bi bi-code-slash" style="margin-right: 5px;"></i></a>
                <a id="a10" runat="server" class="tab" style="display: inline"><i class="bi bi-journals"></i></a>
            </div>

            <div id="buttons_r" runat="server" class="tabs" style="text-align: center; margin-bottom: 20px">
                <asp:Button ID="Google_B" runat="server" Text="Google" class="r_div" Font-Size="Small" OnClick="Google_B_Click" />
                <asp:Button ID="Button1" runat="server" Text="Artado" class="r_div" Font-Size="Small" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Bing" class="r_div" Font-Size="Small" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="Yahoo!" class="r_div" Font-Size="Small" OnClick="Button3_Click" />
                <asp:Button ID="Button5" runat="server" Text="Youtube" class="r_div" Font-Size="Small" OnClick="Button5_Click" />
                <asp:Button ID="Button6" runat="server" Text="Izlesene" class="r_div" Font-Size="Small" OnClick="Button6_Click" />
                <asp:Button ID="Button8" runat="server" Text="Google Scholar" class="r_div" Font-Size="Small" OnClick="Button8_Click" />
                <asp:Button ID="Button9" runat="server" Text="BASE" class="r_div" Font-Size="Small" OnClick="Button9_Click" />
                <asp:Button ID="Button10" runat="server" Text="News" class="r_div" Font-Size="Small" OnClick="Button10_Click" />
            </div>

            <div id="infocard" runat="server" class="info">
                <asp:Label ID="title" runat="server" Font-Size="Larger" Font-Bold="true"></asp:Label>
                <asp:Image ID="Img" runat="server" CssClass="infoimage" />
                <br />
                <asp:Label ID="Category" runat="server" Font-Size="Small"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Summary" runat="server" Font-Size="Medium"></asp:Label>
                <br />
                <a id="more" runat="server" style="text-decoration: none;" target="_blank" rel="nofollow">
                    <asp:Label ID="Label9" runat="server" Text="Daha fazla" Font-Size="Small"></asp:Label></a>
            </div>

            <div id="artado" runat="server" class="results">
                <asp:DropDownList ID="languageDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="languageDropDown_SelectedIndexChanged" class="form-select mb-3" Style="width: 200px; display: inline-block">
                    <asp:ListItem Text="<%$Resources:Langs, Lang %>" disabled="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="English" Value="en" />
                    <asp:ListItem Text="Spanish" Value="es" />
                    <asp:ListItem Text="French" Value="fr" />
                    <asp:ListItem Text="German" Value="de" />
                    <asp:ListItem Text="Chinese" Value="zh" />
                    <asp:ListItem Text="Japanese" Value="ja" />
                    <asp:ListItem Text="Korean" Value="ko" />
                    <asp:ListItem Text="Russian" Value="ru" />
                    <asp:ListItem Text="Arabic" Value="ar" />
                    <asp:ListItem Text="Hindi" Value="hi" />
                    <asp:ListItem Text="Portuguese" Value="pt" />
                    <asp:ListItem Text="Italian" Value="it" />
                    <asp:ListItem Text="Dutch" Value="nl" />
                    <asp:ListItem Text="Swedish" Value="sv" />
                    <asp:ListItem Text="Norwegian" Value="no" />
                    <asp:ListItem Text="Danish" Value="da" />
                    <asp:ListItem Text="Finnish" Value="fi" />
                    <asp:ListItem Text="Turkish" Value="tr" />
                    <asp:ListItem Text="Greek" Value="el" />
                    <asp:ListItem Text="Polish" Value="pl" />
                    <asp:ListItem Text="Czech" Value="cs" />
                    <asp:ListItem Text="Hungarian" Value="hu" />
                    <asp:ListItem Text="Romanian" Value="ro" />
                    <asp:ListItem Text="Bulgarian" Value="bg" />
                    <asp:ListItem Text="Swahili" Value="sw" />
                    <asp:ListItem Text="Vietnamese" Value="vi" />
                    <asp:ListItem Text="Thai" Value="th" />
                    <asp:ListItem Text="Hebrew" Value="he" />
                    <asp:ListItem Text="Urdu" Value="ur" />
                    <asp:ListItem Text="Persian" Value="fa" />
                    <asp:ListItem Text="Malay" Value="ms" />
                    <asp:ListItem Text="Indonesian" Value="id" />
                    <asp:ListItem Text="Bengali" Value="bn" />
                    <asp:ListItem Text="Tamil" Value="ta" />
                    <asp:ListItem Text="Telugu" Value="te" />
                    <asp:ListItem Text="Marathi" Value="mr" />
                    <asp:ListItem Text="Gujarati" Value="gu" />
                    <asp:ListItem Text="Slovak" Value="sk" />
                    <asp:ListItem Text="Slovenian" Value="sl" />
                    <asp:ListItem Text="Croatian" Value="hr" />
                    <asp:ListItem Text="Serbian" Value="sr" />
                    <asp:ListItem Text="Macedonian" Value="mk" />
                    <asp:ListItem Text="Bosnian" Value="bs" />
                    <asp:ListItem Text="Albanian" Value="sq" />
                    <asp:ListItem Text="Estonian" Value="et" />
                    <asp:ListItem Text="Latvian" Value="lv" />
                    <asp:ListItem Text="Lithuanian" Value="lt" />
                    <asp:ListItem Text="Ukrainian" Value="uk" />
                    <asp:ListItem Text="Belarusian" Value="be" />
                    <asp:ListItem Text="Georgian" Value="ka" />
                    <asp:ListItem Text="Armenian" Value="hy" />
                    <asp:ListItem Text="Azerbaijani" Value="az" />
                    <asp:ListItem Text="Kazakh" Value="kk" />
                    <asp:ListItem Text="Uzbek" Value="uz" />
                    <asp:ListItem Text="Turkmen" Value="tk" />
                    <asp:ListItem Text="Kyrgyz" Value="ky" />
                    <asp:ListItem Text="Tajik" Value="tg" />
                    <asp:ListItem Text="Mongolian" Value="mn" />
                    <asp:ListItem Text="Nepali" Value="ne" />
                    <asp:ListItem Text="Sinhala" Value="si" />
                    <asp:ListItem Text="Burmese" Value="my" />
                    <asp:ListItem Text="Khmer" Value="km" />
                    <asp:ListItem Text="Lao" Value="lo" />
                    <asp:ListItem Text="Tibetan" Value="bo" />
                    <asp:ListItem Text="Mongolian" Value="mn" />
                    <asp:ListItem Text="Nepali" Value="ne" />
                    <asp:ListItem Text="Sinhala" Value="si" />
                    <asp:ListItem Text="Burmese" Value="my" />
                    <asp:ListItem Text="Khmer" Value="km" />
                    <asp:ListItem Text="Lao" Value="lo" />
                    <asp:ListItem Text="Tibetan" Value="bo" />
                </asp:DropDownList>
                <asp:DropDownList ID="SafeSearch" runat="server" AutoPostBack="true" class="form-select mb-3" Style="margin-bottom: 20px; width: 200px; display: inline-block" OnSelectedIndexChanged="SafeSearch_SelectedIndexChanged">
                    <asp:ListItem Text="Safe Search" disabled="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="On" Value="On"></asp:ListItem>
                    <asp:ListItem Text="Off" Value="Off"></asp:ListItem>
                </asp:DropDownList>
                <asp:Repeater ID="suggestions" runat="server">
                    <ItemTemplate>
                        <a id="artado_r" href='<%# Eval("URL") %>' class="result-item">
                            <div class="result-refs">
                                <div class="result-badge">
                                    <img class="result-icon" src='/api/favicon?q=<%# Eval("URL") %>' />
                                    <asp:Label ID="url" runat="server" class="result-web font-assistant" Text='<%# Eval("URL") %>'></asp:Label>
                                </div>
                            </div>
                            <small class="result-box">
                                <div class="result-title font-assistant">
                                    <asp:Label ID="title" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                </div>
                                <div class="result-desc text-desc font-assistant">
                                    <asp:Label ID="desc" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </div>
                            </small>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="artado_results" runat="server">
                    <ItemTemplate>
                        <a href='<%# Eval("url") %>' class="result-item">
                            <div class="result-refs">
                                <div class="result-badge">
                                    <img class="result-icon" src='https://www.google.com/s2/favicons?domain=<%# Eval("url") %>&sz=16' />
                                    <asp:Label ID="url" runat="server" class="result-web font-assistant" Text='<%# Eval("url") %>'></asp:Label>
                                </div>
                            </div>
                            <small class="result-box">
                                <div class="result-title font-assistant">
                                    <asp:Label ID="title" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                                </div>
                                <div class="result-desc text-desc font-assistant">
                                    <asp:Label ID="desc" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                </div>
                            </small>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="att">
                    <asp:Label ID="betatext" runat="server" Text="Artado results may be insufficient since it is still in beta. You can use the results of Google or other search engines by selecting them from the panel above."></asp:Label>
                </div>
            </div>

            <div id="web_results" runat="server">
                <div id="google" runat="server">
                    <script async src="/js/google.js"></script>
                    <div class="gcse-searchresults-only" enablehistory="false" runat="server"></div>
                </div>
                <div id="others" runat="server">
                    <asp:Label ID="otherstxt" runat="server" />
                </div>
            </div>

            <div id="image_results" runat="server">
                <script async src="https://cse.google.com/cse.js?cx=85361f53908d000b2"></script>
                <div class="gcse-searchresults-only" id="GoogleImage" runat="server"></div>
            </div>
        </div>
    </form>
</body>
</html>
