<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="artadosearch.Workshop.Defaukt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<link href="/css/panel.css" rel="stylesheet"/>
<link href="/css/home.css" rel="stylesheet"/>
<link href="/css/search.css" rel="stylesheet"/>
<link href="/css/nova.css" rel="stylesheet"/>
<link href="/css/otherresults.css" rel="stylesheet"/>
<link rel="stylesheet" href="/css/mdb.min.css" type="text/css" />
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
<link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com" />
<link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100&family=Quicksand:wght@300&family=Zen+Kaku+Gothic+Antique:wght@300&display=swap" rel="stylesheet"/>
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.1/moment.min.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
<script src="/js/main.js"></script>
<script src="/js/mdb.min.js"></script>
<link rel="shortcut icon" href="/images/favicon.ico"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css" rel="stylesheet"/>
    <title>Artado Workshop</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="middle">
            <div class="form-control form-input searchbar">
                    <a href="/"><img id="Image1" runat="server" class="logo" src="/images/android-chrome-192x192.png"/></a>
                    <asp:TextBox ID="searchinput" runat="server" CssClass="searchinput" placeholder="<%$Resources:Langs, Slogan %>" ></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/search.svg" CssClass="search" OnClick="Search"/>
             </div>
             <div class="top">
                 <asp:Label ID="worktxt" runat="server" Text="Workshop" class=" btn btn-outline-success mb-3 left"></asp:Label>
            </div>

            <div class="classic_tabs" >

            </div>

            <div id="buttons_r" runat="server" class="tabs" style="text-align: center; margin-bottom: 20px">
                <asp:Button ID="Theme" runat="server" Text="<%$Resources:Langs, Themes %>" class="r_div" Font-Size="Small" OnClick="Theme_Click"/>
                <asp:Button ID="Ext" runat="server" Text="<%$Resources:Langs, Extensions %>" class="r_div" Font-Size="Small" OnClick="Ext_Click"/>
                <asp:Button ID="Logo" runat="server" Text="<%$Resources:Langs, Logo %>" class="r_div" Font-Size="Small" OnClick="Logo_Click"/>
            </div>

            <div id="web_results" runat="server">
                <asp:Repeater runat="server" ID="Projects">
                    <ItemTemplate>
                        <a href='/Workshop/<%# Eval("ID") %>' class="pro_link">
                            <div class="product_row">
                                <img src='https://devs.artado.xyz//Upload/Images/<%# Eval("Logo") %>' class="product_logo" />
                                <div class="row_info">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Size="X-Large"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Developer") %>' Font-Size="Medium" ForeColor="Gray"></asp:Label>
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
