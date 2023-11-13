<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="artadosearch.Workshop.ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="/css/panel.css" rel="stylesheet" />
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
            <hr />

            <div id="product_details" runat="server" class="product_page">
                <img id="img" runat="server" class="product_img" />
                <asp:Label ID="nametxt" runat="server" Text="Name" CssClass="p_name"></asp:Label><br />
                <br />
                <a id="dev_a" runat="server">
                    <asp:Label ID="devtxt" runat="server" Text="Developer" CssClass="p_dev"></asp:Label></a>
                <a id="a_use" runat="server" class="use btn">
                    <asp:Label ID="Label1" runat="server" Text="Use"></asp:Label></a><br />
                <div class="slider">
                    <img id="img_1" runat="server" alt="Image 1" />
                    <img id="img_2" runat="server" alt="Image 2" />
                    <img id="img_3" runat="server" alt="Image 3" />
                    <img id="img_4" runat="server" alt="Image 4" />
                    <img id="img_5" runat="server" alt="Image 5" />
                </div>
                <div class="navigation-button">
                    <span id="dot1" runat="server" class="dot active" onclick="changeSlide(0)"></span>
                    <span id="dot2" runat="server" class="dot" onclick="changeSlide(1)"></span>
                    <span id="dot3" runat="server" class="dot" onclick="changeSlide(2)"></span>
                    <span id="dot4" runat="server" class="dot" onclick="changeSlide(3)"></span>
                    <span id="dot5" runat="server" class="dot" onclick="changeSlide(4)"></span>
                </div>
                <a id="source_a" runat="server" class="btn btn-outline-success mb-3">
                    <asp:Label ID="sourcetxt" runat="server" Text="Source Code"></asp:Label></a>
                <div class="btn card" style="border: 1px solid #bdbdbd; text-transform: none; max-width: 100% !important">
                    <asp:Label ID="desctxt" runat="server" Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."></asp:Label>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        var imgs = document.querySelectorAll('.slider img');
        var dots = document.querySelectorAll('.dot');
        var currentImg = 0; // index of the first image 
        const interval = 3000; // duration(speed) of the slide

        function changeSlide(n) {
            for (var i = 0; i < imgs.length; i++) { // reset
                imgs[i].style.opacity = 0;
                dots[i].className = dots[i].className.replace(' active', '');
            }

            currentImg = n;

            imgs[currentImg].style.opacity = 1;
            dots[currentImg].className += ' active';
        }
    </script>
</body>
</html>
