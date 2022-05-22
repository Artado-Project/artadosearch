<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Topluluk_Proxy_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="/text.css" rel="stylesheet" />
<link href="/bootstrap-4.5.3-dist/css/bootstrap.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" /> 
<link rel="shortcut icon" href="/Icons/favicon.ico" />
    <title>Artado Proxy</title>
</head>
<body>
    <form id="form1" runat="server">
        <style>
            @media screen and (min-width: 600px) {
                .auto-style1 {
                    height: 200px !important;
                    margin-top: 50px !important
                }

                #arama_çubugu{
                    width:520px !important
                }

                .top_image{
                    height:50px;
                    margin-left:120px
                }

                .top_search{
                    width: 600px;
                    height: 45px;
                    position:fixed;
                    top:20px;
                    border-top-left-radius: 20px;
                    border-top-right-radius: 20px;
                    border-bottom-left-radius: 20px;
                    border-bottom-right-radius: 20px;
                    margin-left: 300px;
                    padding: 5px 5px 5px 5px;
                    border-style: solid !important;
                }

                #arama_çubugu2 {
                    Height: 29px;
                    width:540px !important
                }
                    #arama_çubugu2:focus {
                        outline: none;
                    }
            }

            @media screen and (min-width: 100px) and (max-width: 600px) {
                .auto-style1 {
                    height: 140px !important;
                    margin-top: 50px !important
                }

                #arama_çubugu{
                    width:240px !important
                }

                .top_image{
                    height:30px;
                    margin-left:0px
                }

                .top_search{
                    width: 260px;
                    height: 45px;
                    position:fixed;
                    top:0px;
                    border-top-left-radius: 20px;
                    border-top-right-radius: 20px;
                    border-bottom-left-radius: 20px;
                    border-bottom-right-radius: 20px;
                    margin-left: 80px;
                    padding: 5px 5px 5px 5px;
                    border-style: solid !important
                }

                #arama_çubugu2 {
                    Height: 29px;
                    width:200px !important
                }
                    #arama_çubugu2:focus {
                        outline: none;
                    }
            }
        </style>

        <div id="Home" runat="server">    
            <div id="arama" class="orta"> 
                    <asp:Panel ID="Panel1" runat="server" BackColor="Transparent">
                    <asp:Image ID="Image1" runat="server" CssClass="auto-style1" src="/Icons/artado_proxy.png"/>
                    <asp:Panel ID="Normal" runat="server" CssClass="arama" BorderStyle="Outset">
                    <asp:TextBox ID="arama_çubugu" type="search" name="s" placeholder="URL girin" runat="server" TextMode="Search"  BorderStyle="None" autofocus AutoCompleteType="Search" MaxLength="100" ValidateRequestMode="Disabled"></asp:TextBox>
                    <asp:ImageButton ID="Search" runat="server" Height="29px" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None" OnClick="Search_Click"/>
                    </asp:Panel>
                    </asp:Panel>
            </div>

            <div style="text-align:center; margin-top:50px;">
                <asp:Label ID="Label1" runat="server" Text="Artado Proxy ile internette tamamen anonim şekilde gezebilirsiniz!"></asp:Label>
            </div>
        </div>

        <div id="Proxy" runat="server">
            <div id="top-bar" style="margin-top:0px; padding:10px 10px 10px 10px">
                <asp:Image ID="Image2" runat="server" CssClass="top_image" src="/Icons/artado_proxy.png"/>
                <asp:Panel ID="Panel2" runat="server" CssClass="top_search" BorderStyle="Outset">
                <asp:TextBox ID="arama_çubugu2" type="search" name="s" placeholder="URL girin" runat="server" TextMode="Search"  BorderStyle="None" autofocus AutoCompleteType="Search" MaxLength="100" ValidateRequestMode="Disabled"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="29px" CssClass="Button1" ImageUrl="~/search.png" Width="29px"  BorderStyle="None" OnClick="ImageButton1_Click"/>
                </asp:Panel>
            </div>
            <iframe id="Web_Page" runat="server" style="width:100vw; height:85vh"></iframe>
        </div>
</form>
</body>
</html>
