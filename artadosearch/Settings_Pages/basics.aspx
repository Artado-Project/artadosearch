<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basics.aspx.cs" Inherits="artadosearch.settings1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Settings - Artado Search</title>
    <link rel="stylesheet" href="/css/mdb.min.css" type="text/css" />
    <link rel="stylesheet" href="/css/bootstrap-icons.css" />
    <script src="/js/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="/js/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="/js/mdb.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/feather-icons/4.29.1/feather.min.js"></script>
    <link rel="stylesheet" href="/fonts/ibm-plex-sans/ibm-plex-sans.css" />
    <link rel="stylesheet" href="/styles/theme-white.css" />
    <link rel="stylesheet" href="/components/headerbar/headerbar.css" />
    <link rel="stylesheet" href="/components/mainpanel/mainpanel.css" />
    <script src="/components/mainpanel/mainpanel.js" defer></script>
    <link rel="stylesheet" href="/components/accordion/accordion.css" />
    <script src="/components/accordion/accordion.js" defer></script>
    <link rel="stylesheet" href="/components/button/button.css" />
    <link rel="shortcut icon" href="/images/favicon.ico" />
    <link
        rel="stylesheet"
        href="/components/profile-container/profile-container.css" />
    <link rel="stylesheet" href="/components/entry/entry.css" />
    <link rel="stylesheet" href="/styles/home.css" />
</head>
<body id="bdy1" runat="server" style="overflow-x: hidden;">
    <form runat="server" id="form1">
        <div class="headerbar-container">
            <header>
                <div class="left">
                    <a href="#" class="icon mainpanel-toggle mobile" role="button">
                        <i data-feather="menu"></i>
                    </a>

                    <a href="/" class="button title" role="button">
                        <h1 style="font-size: 1rem;">Artado Search</h1>
                    </a>
                </div>
                <div class="right">
                    <a href="https://www.artadosearch.com/Donate" class="icon button" role="button">
                        <asp:Label runat="server" ID="Label13" class="font-body-01 greeting" Text="<%$Resources:Langs, Donate %>"></asp:Label>
                    </a>
                </div>
            </header>
        </div>
        <div class="main">
            <div class="mainpanel-container">
                <aside>
                    <asp:Button runat="server" ID="Basics" Text="<%$Resources:Langs, Basics %>" Style="text-align: left" OnClick="Basics_Click" />
                    <asp:Button runat="server" ID="Themes_Button" Text="<%$Resources:Langs, Themes %>" Style="text-align: left" OnClick="Themes_Button_Click" />
                    <asp:Button runat="server" ID="Extensions" Text="<%$Resources:Langs, Extensions %>" Style="text-align: left" OnClick="Extensions_Click" />
                    <asp:Button runat="server" ID="Profiles" Text="<%$Resources:Langs, Profiles %>" Style="text-align: left" OnClick="Profiles_Click" />
                </aside>
            </div>

            <main id="edit" runat="server">
                <div class="content">
                    <section id="basics_page" runat="server">
                        <div id="themes" runat="server" class="entry-container">
                            <asp:Label ID="ThemeTxt" runat="server" Text="<%$Resources:Langs, Themes %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label1" class="font-label-01" Text="<%$Resources:Langs, Theme_exp %>"></asp:Label>
                            <a href="/workshop/">
                                <asp:Label runat="server" ID="Label2" class="font-label-01" ForeColor="#9147ff" Text="<%$Resources:Langs, GoStore %>"></asp:Label></a><br />
                            <asp:DropDownList ID="select_themes" runat="server" AutoPostBack="True" class="form-select mb-3" OnSelectedIndexChanged="Themes_SelectedIndexChanged">
                                <asp:ListItem Text="<%$Resources:Langs, Themes %>" disabled="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Classic %>" Value="Default"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Night %>" Value="Night"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div id="Langs" runat="server" class="entry-container">
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Langs, Lang %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label4" class="font-label-01" Text="<%$Resources:Langs, Lang_exp %>"></asp:Label><br />
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
                        </div>

                        <div id="Icons" runat="server" class="entry-container">
                            <asp:Label ID="Label5" runat="server" Text="<%$Resources:Langs, Logo %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label6" class="font-label-01" Text="<%$Resources:Langs, Logo_exp %>"></asp:Label>
                            <a href="/workshop/">
                                <asp:Label runat="server" ID="Label7" class="font-label-01" ForeColor="#9147ff" Text="<%$Resources:Langs, GoStore %>"></asp:Label></a><br />
                            <asp:DropDownList ID="Logos" runat="server" AutoPostBack="True" class="form-select mb-3" OnSelectedIndexChanged="Logos_SelectedIndexChanged">
                                <asp:ListItem Text="<%$Resources:Langs, Default %>" Value="default"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Colorful %>" Value="colorful"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Old %>" Value="old"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Custom %>" Value="custom" disabled=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div id="Categories" runat="server" class="entry-container">
                            <asp:Label ID="Label8" runat="server" Text="<%$Resources:Langs, Categories %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label9" class="font-label-01" Text="<%$Resources:Langs, Cat_exp %>"></asp:Label>
                            <asp:DropDownList ID="position" runat="server" AutoPostBack="True" class="form-select mb-3" OnSelectedIndexChanged="position_SelectedIndexChanged">
                                <asp:ListItem Text="<%$Resources:Langs, Top %>" Value="top"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Left %>" Value="left"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Right %>" Value="right"></asp:ListItem>
                                <asp:ListItem Text="<%$Resources:Langs, Bottom %>" Value="bottom"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div id="background" runat="server" class="entry-container">
                            <asp:Label ID="Label10" runat="server" Text="<%$Resources:Langs, Background %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label11" class="font-label-01" Text="<%$Resources:Langs, Back_exp %>"></asp:Label>
                            <input id="url" runat="server" type="text" name="name" />
                        </div>
                        <asp:Button runat="server" ID="Button1" CssClass="button" Text="<%$Resources:Langs, Apply %>" OnClick="Button1_Click" />
                    </section>
                </div>
            </main>
        </div>
    </form>
    <script src="/js/featherrep.js"></script>
</body>
</html>
