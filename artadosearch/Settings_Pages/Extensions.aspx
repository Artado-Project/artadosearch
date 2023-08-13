<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Extensions.aspx.cs" Inherits="artadosearch.Settings_Pages.Extensions" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Settings - Artado Search</title>
    <link rel="stylesheet" href="/css/mdb.min.css" type="text/css" />
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
    <script src="https://unpkg.com/feather-icons"></script>
    <link rel="stylesheet" href="/fonts/ibm-plex-sans/ibm-plex-sans.css"/>
    <script src="/node_modules/feather-icons/dist/feather.min.js"></script>
    <link rel="stylesheet" href="/styles/theme-white.css" />
    <link rel="stylesheet" href="/components/headerbar/headerbar.css" />
    <link rel="stylesheet" href="/components/mainpanel/mainpanel.css" />
    <script src="/components/mainpanel/mainpanel.js" defer></script>
    <link rel="stylesheet" href="/components/accordion/accordion.css" />
    <script src="/components/accordion/accordion.js" defer></script>
    <link rel="stylesheet" href="/components/button/button.css" />
    <link rel="shortcut icon" href="/images/favicon.ico"/>
    <link
      rel="stylesheet"
      href="/components/profile-container/profile-container.css"
    />
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

                    <a href="/" class="button title" role="button"><h1>Artado Search</h1></a>
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
                    <asp:Button runat="server" ID="Basics" Text="<%$Resources:Langs, Basics %>" style="text-align: left" OnClick="Basics_Click"/>
                    <asp:Button runat="server" ID="Themes_Button" Text="<%$Resources:Langs, Themes %>" style="text-align: left" OnClick="Themes_Button_Click"/>
                    <asp:Button runat="server" ID="Extensions_Button" Text="<%$Resources:Langs, Extensions %>" style="text-align: left"/>
                    <asp:Button runat="server" ID="Profiles" Text="<%$Resources:Langs, Profiles %>" style="text-align: left" OnClick="Profiles_Click"/>
                </aside>
            </div>

            <main id="edit" runat="server">
                <div class="content">
                    <section id="extensions_page" runat="server">
                        <div id="custom_extensions" runat="server" class="entry-container">
                            <asp:Label ID="Customtxt" runat="server" Text="<%$Resources:Langs, Extensions %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label1" class="font-label-01" Text="<%$Resources:Langs, CustomExt_exp %>"></asp:Label>
                            <asp:Repeater ID="extensions_list" runat="server" OnItemCommand="extensions_list_ItemCommand">
                                <ItemTemplate>
                                    <div class="theme_row">
                                        <asp:Label ID="text" runat="server" Text="theme" style="vertical-align: middle"></asp:Label>
                                        <asp:ImageButton ID="delete" runat="server" ImageUrl="/images/delete.png" CssClass="delete"/>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <%--<div id="customjs" runat="server" class="entry-container">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:Langs, CustomJS %>" Font-Size="Large"></asp:Label><br />
                            <asp:Label runat="server" ID="Label3" class="font-label-01" Text="<%$Resources:Langs, CustomJS_exp %>"></asp:Label>
                            <textarea id="js" runat="server"></textarea>
                        </div>
                        <asp:Button runat="server" ID="Apply" CssClass="button" Text="<%$Resources:Langs, Apply %>" OnClick="Apply_Click"/>--%>
                    </section>
                </div>
            </main>
        </div>

        <script>
            feather.replace();
        </script>
      </form>
  </body>
</html>