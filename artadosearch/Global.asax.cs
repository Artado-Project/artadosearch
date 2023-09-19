using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace artadosearch
{
    public class Global : System.Web.HttpApplication
    {

        void paths(RouteCollection url)
        {
            url.MapPageRoute("default", "Home", "~/default.aspx");
            url.MapPageRoute("search", "search", "~/search.aspx");
            url.MapPageRoute("news", "news/search", "~/search.aspx");
            url.MapPageRoute("settings", "settings", "~/Settings_Pages/basics.aspx");
            url.MapPageRoute("themes", "settings/themes", "~/Settings_Pages/themes.aspx");
            url.MapPageRoute("ext", "settings/extensions", "~/Settings_Pages/Extensions.aspx");
            url.MapPageRoute("profiles", "settings/profiles", "~/Settings_Pages/Profiles.aspx");
            url.MapPageRoute("stats", "settings/stats", "~/settings.aspx");
            url.MapPageRoute("workshop", "workshop", "~/Workshop/Default.aspx");
            url.MapPageRoute("product", "workshop/{id}", "~/Workshop/ProductPage.aspx");
            url.MapPageRoute("manifest", "manifest", "~/Manifest.aspx");
            url.MapPageRoute("autocomplete", "api/autocomplete", "~/autocomplete/autocomplete.aspx");
            url.MapPageRoute("favicon", "api/favicon", "~/FaviconAPI.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            paths(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}