<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profiles.aspx.cs" Inherits="artadosearch.Settings_Pages.Profiles" %>

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
    <script src="/js/feather.min.js"></script>
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
                    <asp:Button runat="server" ID="Profiles_Button" Text="<%$Resources:Langs, Profiles %>" Style="text-align: left" OnClick="Profiles_Button_Click" />
                </aside>
            </div>

            <main id="edit" runat="server">
                <div class="content">
                    <section id="profiles_page" runat="server">
                        <div id="profiles_div" runat="server" class="accordions">
                            <asp:Label ID="Customtxt" runat="server" Text="<%$Resources:Langs, Profiles %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label1" class="font-label-01" Text="<%$Resources:Langs, Profiles_exp %>"></asp:Label>
                            <asp:Repeater ID="profiles_list" runat="server">
                                <ItemTemplate>
                                    <div class="accordion-container">
                                        <div class="headerbar" style="display: flex; align-items: center; justify-content: space-between; padding: var(--spcaing-05); min-width: 100%; background: transparent; border: none; font: var(--text-primary); text-align: start;">
                                            <asp:Label ID="title" runat="server" class="title" Text='<%# Eval("profile_name") %>'></asp:Label>
                                            <i class="icon" data-feather="chevron-down"></i>
                                        </div>
                                        <div class="content">
                                            <a href='/?profile=<%# Eval("profile_id") %>'>
                                                <asp:Label ID="url" runat="server" Text="Profile Link" Style="color: blue !important"></asp:Label></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </section>
                    <section>
                        <div class="entry-container">
                            <input id="profilename" runat="server" type="text" name="name" placeholder="<%$Resources:Langs, Profile_Name %>" />
                            <asp:Label ID="err" runat="server" Text="<%$Resources:Langs, EnterName %>"></asp:Label>
                        </div>
                        <asp:Button ID="openprofile" runat="server" Text="<%$Resources:Langs, Create_Profile %>" class="cool_button" OnClick="openprofile_Click" />
                        <asp:Button ID="create_profile" runat="server" Text="<%$Resources:Langs, Create_Profile %>" class="cool_button" OnClick="create_profile_Click" />
                        <br />
                        <asp:Label ID="id_txt" runat="server"></asp:Label>
                        <br />
                        <div class="entry-container">
                            <input id="ID_input" runat="server" type="text" name="name" placeholder="Enter Sync ID" />
                        </div>
                        <asp:Button ID="Sync" runat="server" Text="<%$Resources:Langs, Apply %>" class="cool_button" OnClick="sync_Click" />
                    </section>
                </div>
            </main>
        </div>
    </form>
    <script src="/js/featherrep.js"></script>
</body>
</html>
