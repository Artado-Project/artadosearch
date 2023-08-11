<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="artadosearch.search" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<link href="css/home.css" rel="stylesheet"/>
<link href="css/search.css" rel="stylesheet"/>
<link href="css/nova.css" rel="stylesheet"/>
<link href="css/otherresults.css" rel="stylesheet"/>
<link rel="stylesheet" href="css/mdb.min.css" type="text/css" />
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com" />
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&family=Quicksand:wght@300&family=Zen+Kaku+Gothic+Antique:wght@300&display=swap" rel="stylesheet"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.1/moment.min.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
<script src="js/main.js"></script>
<script src="js/mdb.min.js"></script>
<link rel="shortcut icon" href="/images/favicon.ico"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css" rel="stylesheet"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="middle">
            <div class="form-control form-input searchbar">
                <a href="/"><img id="Image1" runat="server" class="logo"/></a>
                <asp:TextBox ID="searchinput" runat="server" CssClass="searchinput" placeholder="<%$Resources:Langs, Slogan %>" ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/search.svg" CssClass="search" OnClick="Search"/>
         </div>
         <div class="top">
             <a href="https://myacc.artado.xyz/account"><img id="pfp" runat="server" class="login" /></a>
             <asp:Button ID="SignIn" runat="server" Text="<%$Resources:Langs, Sign %>" class="btn login" OnClick="SignIn_Click"/>
             <button class="btn btn-success menu" style="margin-top: 10px; height: 35px; background: #5F5F87" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" data-ripple-color="dark" aria-controls="offcanvasRight"><i class="bi-list"></i></button>
              <div class="offcanvas offcanvas-end" style="max-width: 300px; border-top-left-radius:10px; border-bottom-left-radius:10px;" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
                <style>
                    ::-webkit-scrollbar {
                        width: 4px;
                        color: #3c3c3c;
                    }
                </style>
                <div class="offcanvas-header">
                    <asp:Label ID="offcanvasRightLabel" runat="server" Text="<%$Resources:Langs, Menu %>" Font-Size="X-Large"></asp:Label>
                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">
                    <asp:DropDownList ID="Themes" runat="server" AutoPostBack="True" class="form-select mb-3" OnSelectedIndexChanged="Themes_SelectedIndexChanged">
                        <asp:ListItem Text="<%$Resources:Langs, Themes %>" disabled="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Classic %>" Value="Default"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Night %>" Value="Night"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="Languages" runat="server" AutoPostBack="True" class="form-select mb-3" OnSelectedIndexChanged="Languages_SelectedIndexChanged">
                        <asp:ListItem Text="<%$Resources:Langs, Lang %>" disabled="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, English %>" Value="en"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Turkish %>" Value="tr"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, French %>" Value="fr"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, German %>" Value="de"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Italian %>" Value="it"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Russian %>" Value="ru"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Chinese %>" Value="zh"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Spanish %>" Value="es"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Portuguese %>" Value="pt"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Korean %>" Value="ko"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Japanese %>" Value="ja"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Hungarian %>" Value="hu"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Bulgarian %>" Value="bg"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Bosnian %>" Value="bs"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Serbian %>" Value="sr"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Macedonian %>" Value="mk"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Greek %>" Value="el"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Ukrainian %>" Value="uk"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Azer %>" Value="az"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Turkmen %>" Value="tk"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Kazakh %>" Value="kk"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Kyrgyz %>" Value="ky"></asp:ListItem>
                        <asp:ListItem Text="<%$Resources:Langs, Uzbek %>" Value="uz"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="Results" runat="server" AutoPostBack="True" class="form-select mb-3" OnSelectedIndexChanged="Results_SelectedIndexChanged">
                        <asp:ListItem Text="<%$Resources:Langs, Results %>" disabled="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Google" Value="Google"></asp:ListItem>
                        <asp:ListItem Text="Artado" Value="Artado"></asp:ListItem>
                        <asp:ListItem Text="Bing" Value="Bing"></asp:ListItem>
                        <asp:ListItem Text="Yahoo!" Value="Yahoo"></asp:ListItem>
                        <asp:ListItem Text="Youtube" Value="Youtube"></asp:ListItem>
                        <asp:ListItem Text="Izlesene" Value="Izlesene"></asp:ListItem>
                        <asp:ListItem Text="Scholar" Value="Google Scholar"></asp:ListItem>
                        <asp:ListItem Text="Bing News" Value="News"></asp:ListItem>
                    </asp:DropDownList>
                    <hr class="ince"/>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/Settings"><asp:Label ID="Label7" runat="server" Text="<%$Resources:Langs, Settings %>"></asp:Label><br /></a><br/>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/workshop">Workshop</a><br />
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/Manifest">Manifesto</a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://github.com/Artado-Project/artadosearch">Github</a><br>
                    <hr class="ince">
                    <div class="col-md-12">
                        <h3 class="text-center fontlu">Artado Search</h3>
                        <p class="text-center mb-3">Artado Search'te aramalarınız kaydedilmez. Kimse sizin kim olduğunuzu bilemez. Artado Search ile tamamen anonim olarak internetin sınırlarını keşfedebilirsiniz!</p>
                    </div>
                </div>
            </div>
        </div>
            
            <div class="classic_tabs" >
                <div id="classic_tabs" runat="server">
                    <a id="w1" runat="server" class="tab" style="display: inline"><i class="bi bi-globe" style="margin-right: 10px;"></i><asp:Label ID="web" runat="server" Text="Web"></asp:Label></a>
                    <a id="i1" runat="server" class="tab" style="display: inline"><i class="bi bi-card-image" style="margin-right: 10px;"></i><asp:Label ID="image" runat="server" Text="<%$Resources:Langs, Image %>"></asp:Label></a>
                    <a id="v1" runat="server" class="tab" style="display: inline"><i class="bi bi-play" style="margin-right: 10px;"></i><asp:Label ID="video" runat="server" Text="<%$Resources:Langs, Video %>"></asp:Label></a>
                    <a id="n1" runat="server" class="tab" style="display: inline"><i class="bi bi-newspaper" style="margin-right: 10px;"></i><asp:Label ID="news" runat="server" Text="<%$Resources:Langs, News %>"></asp:Label></a>
                    <a id="in1" runat="server" class="tab" style="display: inline"><i class="bi bi-info-circle" style="margin-right: 10px;"></i><asp:Label ID="info" runat="server" Text="<%$Resources:Langs, Info %>"></asp:Label></a>
                    <a id="m1" runat="server" class="tab" style="display: inline"><i class="bi bi-film" style="margin-right: 10px;"></i><asp:Label ID="movie" runat="server" Text="<%$Resources:Langs, Film %>"></asp:Label></a>
                    <a id="it1" runat="server" class="tab" style="display: inline"><i class="bi bi-code-slash" style="margin-right: 10px;"></i><asp:Label ID="it" runat="server" Text="<%$Resources:Langs, IT %>"></asp:Label></a>
                    <a id="a1" runat="server" class="tab" style="display: inline"><i class="bi bi-journals" style="margin-right: 10px;"></i><asp:Label ID="academic" runat="server" Text="<%$Resources:Langs, Academic %>"></asp:Label></a>
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
                <asp:Button ID="Google_B" runat="server" Text="Google" class="r_div" Font-Size="Small" OnClick="Google_B_Click"/>
                <asp:Button ID="Button1" runat="server" Text="Artado" class="r_div" Font-Size="Small" OnClick="Button1_Click"/>
                <asp:Button ID="Button2" runat="server" Text="Bing" class="r_div" Font-Size="Small" OnClick="Button2_Click"/>
                <asp:Button ID="Button3" runat="server" Text="Yahoo!" class="r_div" Font-Size="Small" OnClick="Button3_Click"/>
                <asp:Button ID="Button5" runat="server" Text="Youtube" class="r_div" Font-Size="Small" OnClick="Button5_Click"/>
                <asp:Button ID="Button6" runat="server" Text="Izlesene" class="r_div" Font-Size="Small" OnClick="Button6_Click"/>
                <asp:Button ID="Button8" runat="server" Text="Google Scholar" class="r_div" Font-Size="Small" OnClick="Button8_Click"/>
                <asp:Button ID="Button9" runat="server" Text="BASE" class="r_div" Font-Size="Small" OnClick="Button9_Click" />
                <asp:Button ID="Button10" runat="server" Text="News" class="r_div" Font-Size="Small" OnClick="Button10_Click"/>
           </div>

            <div id="infocard" runat="server" class="info">
                <asp:Label ID="title" runat="server" Font-Size="Larger" Font-Bold="true"></asp:Label>
                <asp:Image ID="Img" runat="server" CssClass="infoimage"/>
                <br />
                <asp:Label ID="Category" runat="server" Font-Size="Small"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Summary" runat="server" Font-Size="Medium"></asp:Label>
                <br /> 
                <a id="more" runat="server" style="text-decoration:none;" target="_blank" rel="nofollow"><asp:Label ID="Label9" runat="server" Text="Daha fazla" Font-Size="Small"></asp:Label></a>
            </div>

            <div id="artado" runat="server">
                <img src="/images/Artado%20Vectors/construction%20helmet%20artado/_d8a1256b-f19e-4d7a-a372-0f41e514683d.png" alt="Dinosaur Logo" class="dino">
                <div class="att">
                    <i class="bi bi-exclamation-octagon" style="font-size: 30px; margin-right: 10px; margin-left: 10px"></i>
                    <asp:Label id="Label1" runat="server" Text="<%$Resources:Langs, Beta %>" />
                </div>
            </div>

            <div id="web_results" runat="server">
                <div id="google" runat="server">
                    <script async src="https://cse.google.com/cse.js?cx=160e826a9c5ebe821"></script>
                    <div class="gcse-searchresults-only" enablehistory="false" runat="server"></div>
                </div>
                <div id="others" runat="server">
                    <asp:Label id="otherstxt" runat="server" />
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
