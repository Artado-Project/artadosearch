<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Privacy.aspx.cs" Inherits="artadosearch.Settings_Pages.Privacy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%= Resources.Langs.PageTitle %></title>
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
                    <a href="/donate" class="icon button" role="button">
                        <asp:Label runat="server" ID="Label13" class="font-body-01 greeting" Text="<%$Resources:Langs, Donate %>"></asp:Label>
                    </a>
                </div>
            </header>
        </div>
        <div class="main">
            <div class="mainpanel-container">
                <aside>
                    <asp:Button runat="server" ID="Privacy_Button" Text="<%$Resources:Langs, Privacy %>" Style="text-align: left" OnClick="Privacy_Click" />
                </aside>
            </div>

            <main id="edit" runat="server">
                <div class="content">
                    <section id="extensions_page" runat="server">
                        <div id="custom_extensions" runat="server" class="entry-container">
                            <div>
                                <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Langs, Title %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblLastUpdated" runat="server" Text="<%$ Resources:Langs, LastUpdated %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblIntro" runat="server" Text="<%$ Resources:Langs, Intro %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblInfoWeCollect" runat="server" Text="<%$ Resources:Langs, InfoWeCollect %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblUserProvidedInfo" runat="server" Text="<%$ Resources:Langs, UserProvidedInfo %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblAnonymousInfo" runat="server" Text="<%$ Resources:Langs, AnonymousInfo %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblUseOfInfo" runat="server" Text="<%$ Resources:Langs, UseOfInfo %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblUseUserProvidedInfo" runat="server" Text="<%$ Resources:Langs, UseUserProvidedInfo %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblUseAnonymousInfo" runat="server" Text="<%$ Resources:Langs, UseAnonymousInfo %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblSearchData" runat="server" Text="<%$ Resources:Langs, SearchData %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblNoStorageByArtado" runat="server" Text="<%$ Resources:Langs, NoStorageByArtado %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblThirdPartyCollection" runat="server" Text="<%$ Resources:Langs, ThirdPartyCollection %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblAdvertising" runat="server" Text="<%$ Resources:Langs, Advertising %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblUniqueUserId" runat="server" Text="<%$ Resources:Langs, UniqueUserId %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblDataProtection" runat="server" Text="<%$ Resources:Langs, DataProtection %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblSecurityMeasures" runat="server" Text="<%$ Resources:Langs, SecurityMeasures %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblUserRights" runat="server" Text="<%$ Resources:Langs, UserRights %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblRightsExplanation" runat="server" Text="<%$ Resources:Langs, RightsExplanation %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblAccessRight" runat="server" Text="<%$ Resources:Langs, AccessRight %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblCorrectionRight" runat="server" Text="<%$ Resources:Langs, CorrectionRight %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblDeletionRight" runat="server" Text="<%$ Resources:Langs, DeletionRight %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblObjectionRight" runat="server" Text="<%$ Resources:Langs, ObjectionRight %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblContactRights" runat="server" Text="<%$ Resources:Langs, ContactRights %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblPolicyChanges" runat="server" Text="<%$ Resources:Langs, PolicyChanges %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblPolicyChangesDetails" runat="server" Text="<%$ Resources:Langs, PolicyChangesDetails %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblContactUs" runat="server" Text="<%$ Resources:Langs, ContactUs %>"></asp:Label>
                                <br />
                                <asp:Label ID="lblContactDetails" runat="server" Text="<%$ Resources:Langs, ContactDetails %>"></asp:Label>
                                <br /><br />
                                <asp:Label ID="lblAgreement" runat="server" Text="<%$ Resources:Langs, Agreement %>"></asp:Label>
                            </div>
                        </div>
                    </section>
                </div>
            </main>
        </div>
    </form>
    <script src="/js/featherrep.js"></script>
</body>
</html>
