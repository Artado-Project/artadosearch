<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="artadosearch.Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<link href="css/home.css" rel="stylesheet"/>
<link href="css/nova.css" rel="stylesheet"/>
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
<link rel="search" type="application/opensearchdescription+xml" title="Artado Search" href="https://www.artadosearch.com/opensearch.xml"/>
<link rel="shortcut icon" href="/images/favicon.ico"/>
<meta name="keywords" content="open source, open source search engine, linux, foss, foss search engine, arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, açık kaynak, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, tarayıcı, browser, celer" />
<meta name="description" content="Open Source, Private and Customizable Search Engine" />
<meta property="og:title" content="Artado Search" />
<meta property="og:type" content="website" />
<meta property="og:url" content="https://www.artadosearch.com" />
<meta property="og:description" name="description" class="swiftype" content="Open Source, Private and Anonymous Search Engine"/>
<meta name="twitter:card" content="summary_large_image" />
<meta name="twitter:title" content="Artado Search" />
<meta name="twitter:description" content="Open Source, Private and Anonymous Search Engine" />
<meta name="twitter:url" content="https://www.artadosearch.com/" />
<meta name="twitter:image" content="https://www.artadosearch.com/images/privacy.jpg" />
    <title>Artado Search</title>
</head>
<body id="bdy1" runat="server">
    <form id="form1" runat="server">
        <div class="middle">
            <asp:Panel ID="searchpanel" runat="server" class="form-control form-input searchbar">
                <img id="Image1" runat="server" class="logo"/>
                <asp:TextBox ID="searchinput" runat="server" CssClass="searchinput" placeholder="<%$Resources:Langs, Slogan %>" autocomplete="off" autofocus></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/search.svg" CssClass="search" OnClick="Search"/>
            </asp:Panel>

            <div class="row" style="max-width: 90%; justify-content: center; margin: 0 auto; margin-top: 50px; ">
              <div class="col-md-4" style="width: 300px; text-align:center">
                <div class="btn card" style="border: 1px solid #bdbdbd; text-transform: none">
                   <a href="#" style="text-decoration: none; color: #4f4f4f">
                     <div class="card-body">
                        <div style="font-size: 50px; margin-bottom: 5px"><i class="bi bi-lock-fill"></i></div>
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="X-Large" Text="<%$Resources:Langs, Privacy %>"></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Langs, Home_Privacy %>"></asp:Label>
                      </div>
                 </a>
                </div>
              </div>
              <div class="col-md-4" style="width: 300px; text-align:center">
                <div class="btn card" style="border: 1px solid #bdbdbd; text-transform: none">
                   <a href="#" style="text-decoration: none; color: #4f4f4f">
                      <div class="card-body">
                          <div style="font-size: 50px; margin-bottom: 5px"><i class="bi bi-bag-fill"></i></div>
                          <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="X-Large" Text="<%$Resources:Langs, Customization %>"></asp:Label><br />
                          <asp:Label ID="Label4" runat="server" Text="<%$Resources:Langs, Home_Custom %>"></asp:Label>
                      </div>
                  </a>
                </div>
              </div>
              <div class="col-md-4" style="width: 300px; text-align:center">
                <div class="btn card" style="border: 1px solid #bdbdbd; text-transform: none">
                   <a href="#" style="text-decoration: none; color: #4f4f4f">
                      <div class="card-body">
                        <div style="font-size: 50px; margin-bottom: 5px"><i class="bi bi-three-dots"></i></div>
                        <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="X-Large" Text="<%$Resources:Langs, Projects %>"></asp:Label><br />
                        <asp:Label ID="Label6" runat="server" Text="<%$Resources:Langs, Home_Projects %>"></asp:Label>
                      </div>
                   </a>
                </div>
              </div>
            </div>
        </div>
        <div class="top">
             <div id="Beta" runat="server" class="btn btn-outline-success mb-3 beta"><span id="beta_text" style="color: #00b74a;">Beta</span></div>
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
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/Settings"><asp:Label ID="Label7" style="color: #00b74a;" runat="server" Text="<%$Resources:Langs, Settings %>"></asp:Label><br /></a><br/>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/workshop">Workshop</a><br />
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://forum.artado.xyz/"><asp:Label style="color: #00b74a;" ID="Label9" runat="server" Text="<%$Resources:Langs, Forum %>"></asp:Label></a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/Manifest"><asp:Label style="color: #00b74a;" ID="Label8" runat="server" Text="<%$Resources:Langs, Manifest %>"></asp:Label></a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://myacc.artado.xyz/privacy"><asp:Label style="color: #00b74a;" ID="Label0" runat="server" Text="<%$Resources:Langs, Privacy %>"></asp:Label></a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://devs.artado.xyz/">Developers</a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://github.com/Artado-Project/artadosearch">Github</a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://discord.gg/WXCsr8zTN6">Discord</a><br>
                    <hr class="ince">
                    <div class="col-md-12">
                        <h3 class="text-center fontlu">Artado Search</h3>
                        <asp:Label ID="manifest" runat="server" class="text-center mb-3" Text="<%$Resources:Langs, Manifesto2 %>"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div id="save" runat="server" class="save">
            <asp:Label ID="savetxt" runat="server" Text="Do you want to save the changes?"></asp:Label><br /><br />
            <asp:Button id="yes" runat="server" CssClass="btn button" Text="Yes" OnClick="yes_Click"/>
            <asp:Button id="no" runat="server" CssClass="btn btn-outline-success mb-3" style="margin-bottom: 0px !important" Text="No" OnClick="no_Click"/>
        </div>
    </form>
    <script src="/js/autocomplete.js"></script>
</body>
</html>
