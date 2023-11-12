<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="artadosearch.Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="css/home.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/mdb.min.css" type="text/css" />
    <link rel="stylesheet" href="/css/bootstrap-icons.css" />
    <script src="/js/jquery-3.3.1.slim.min.js"></script>
    <script src="/js/popper.min.js"></script>
    <script src="/js/bootstrap.bundle.min.js"></script>
    <script src="/js/mdb.min.js"></script>
    <script src="/js/tailwind.js"></script>
    <link rel="search" type="application/opensearchdescription+xml" title="Artado Search" href="https://www.artadosearch.com/opensearch.xml" />
    <link rel="shortcut icon" href="/images/favicon.ico" />
    <meta name="keywords" content="open source, open source search engine, linux, foss, foss search engine, arama, arama motoru, yerli, artado, gizlilik, milli, türk yapımı, güvenli, açık kaynak, reklamsız, reklamsız arama motoru, search, search engine, privacy, security, tarayıcı, browser, celer" />
    <meta name="description" content="Open Source, Private and Customizable Search Engine" />
    <meta property="og:title" content="Artado Search" />
    <meta property="og:type" content="website" />
    <meta property="og:url" content="https://www.artadosearch.com" />
    <meta property="og:description" name="description" class="swiftype" content="Open Source, Private and Anonymous Search Engine" />
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
            <div class="flex flex-col items-center">
              <div class="flex items-end" style="margin-top: 150px; margin-bottom: 30px">
                <img class="h-44" id="Image1" runat="server" alt="artado search logo">
              </div>
              <div class="shadow-lg w-[50%] sm:w-[35rem] z-10" style="border-radius: 10px">
                <div class="flex">
                  <asp:TextBox ID="searchinput" runat="server" CssClass="bg-[var(--bg-secondary)] px-4 py-3 rounded-l-lg w-full" placeholder="<%$Resources:Langs, Slogan %>" autocomplete="off" autofocus></asp:TextBox>
                  <button hidden id="search-delete" class="px-5 bg-[var(--bg-secondary)]"><i
                      class="fa-solid fa-close"></i></button>
                  <button id="search-button" class="bg-[var(--bg-tertiary)] px-5 rounded-r-lg"><i
                      class="bi bi-search"></i></button>
                </div>
              </div>
            </div>

            <a class="absolute bottom-0 text-center pb-5" id="up-down" style="color: var(--text); width: 100px" href="#features">
            <i class="text-3xl bi bi-chevron-down"></i></a>
        </div>
        <div class="top">
            <button class="btn btn-success menu" style="margin-top: 10px; height: 35px; background: #5F5F87" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" data-ripple-color="dark" aria-controls="offcanvasRight"><i class="bi-list"></i></button>
            <div class="offcanvas offcanvas-end" style="max-width: 300px; border-top-left-radius: 10px; border-bottom-left-radius: 10px;" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
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
                    <hr class="ince" />
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/Settings">
                        <asp:Label ID="Label7" Style="color: #00b74a;" runat="server" Text="<%$Resources:Langs, Settings %>"></asp:Label><br />
                    </a>
                    <br />
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/workshop">Workshop</a><br />
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://forum.artado.xyz/">
                        <asp:Label Style="color: #00b74a;" ID="Label9" runat="server" Text="<%$Resources:Langs, Forum %>"></asp:Label></a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="/Manifest">
                        <asp:Label Style="color: #00b74a;" ID="Label8" runat="server" Text="<%$Resources:Langs, Manifest %>"></asp:Label></a><br>
                    <a class="btn btn-outline-success mb-3" data-ripple-color="dark" href="https://myacc.artado.xyz/privacy">
                        <asp:Label Style="color: #00b74a;" ID="Label0" runat="server" Text="<%$Resources:Langs, Privacy %>"></asp:Label></a><br>
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
            <asp:Label ID="savetxt" runat="server" Text="Do you want to save the changes?"></asp:Label><br />
            <br />
            <asp:Button ID="yes" runat="server" CssClass="btn button" Text="Yes" OnClick="yes_Click" />
            <asp:Button ID="no" runat="server" CssClass="btn btn-outline-success mb-3" Style="margin-bottom: 0px !important" Text="No" OnClick="no_Click" />
        </div>
    </form>
    <script src="/js/autocomplete.js"></script>
</body>
</html>
