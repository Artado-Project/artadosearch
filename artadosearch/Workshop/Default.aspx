<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="artadosearch.Workshop.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="/css/panel.css?v=2" rel="stylesheet" />
    <link href="/css/home.css" rel="stylesheet" />
    <link href="/css/search.css" rel="stylesheet" />
    <link href="/css/otherresults.css" rel="stylesheet" />
    <link rel="stylesheet" href="/css/mdb.min.css" type="text/css" />
    <link rel="stylesheet" href="/css/bootstrap-icons.css" />
    <script src="/js/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="/js/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="/js/mdb.min.js"></script>
    <link rel="shortcut icon" href="/images/favicon.ico" />
    <title>Artado Workshop</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="middle">
            <div class="searchbar">
                <a href="/">
                    <img src="/images/android-chrome-192x192.png" id="Image1" runat="server" class="logo" /></a>
                <asp:TextBox ID="searchinput" runat="server" CssClass="searchinput" placeholder="<%$Resources:Langs, Slogan %>"></asp:TextBox>
                <button id="searchbutton" runat="server" onserverclick="Search" class="search"><i
                        class="bi bi-search"></i></button>
            </div>
            <div class="top">
                <a href="https://devs.artado.xyz/" class="right_b btn" type="button">
                    <asp:Label ID="devs" runat="server" Text="Share Your Project"></asp:Label></a>
            </div>

            <div class="classic_tabs">
            </div>

            <div id="buttons_r" runat="server" class="tabs" style="margin-left: 170px; margin-bottom: 20px">
                <asp:Button ID="Theme" runat="server" Text="<%$Resources:Langs, Themes %>" class="r_div" Font-Size="Small" OnClick="Theme_Click" />
                <asp:Button ID="Ext" runat="server" Text="<%$Resources:Langs, Extensions %>" class="r_div" Font-Size="Small" OnClick="Ext_Click" />
                <asp:Button ID="Logo" runat="server" Text="<%$Resources:Langs, Logo %>" class="r_div" Font-Size="Small" OnClick="Logo_Click" />
            </div>
            <hr />

            <div id="web_results" runat="server">
                <asp:Repeater runat="server" ID="Projects">
                    <ItemTemplate>
                        <a href='/Workshop/<%# Eval("ID") %>' class="pro_link">
                            <div class="product_row">
                                <img src='https://devs.artado.xyz//Upload/Images/<%# Eval("Logo") %>' class="product_logo" />
                                <div class="row_info">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Size="X-Large"></asp:Label><br />
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Developer") %>' Font-Size="Medium" ForeColor="Gray"></asp:Label><br />
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Genre") %>' Font-Size="Small" ForeColor="Gray"></asp:Label>
                                </div>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
