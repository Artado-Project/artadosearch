using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace artadosearch.Settings_Pages
{
    public partial class Proxy : System.Web.UI.Page
    {
        //Connection Strings
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Basics.Attributes.Add("class", "sidebar-item");
            Themes_Button.Attributes.Add("class", "sidebar-item");
            Extensions.Attributes.Add("class", "sidebar-item");
            ProxyButton.Attributes.Add("class", "sidebar-item active");
            Profiles.Attributes.Add("class", "sidebar-item");
            Ads.Attributes.Add("class", "sidebar-item");

            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Custom Theme
            HttpCookie custom = HttpContext.Current.Request.Cookies["CustomTheme"];
            if (custom != null && custom.Value != null)
            {
                foreach (string item in custom.Values)
                {
                    string path = custom.Values[item];
                    Page.Header.Controls.Add(
                         new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\" />"));
                }
            }

            //Extension
            HttpCookie ext = HttpContext.Current.Request.Cookies["Extension"];
            if (ext != null && ext.Value != null)
            {
                foreach (string item in ext.Values)
                {
                    string path = ext.Values[item];
                    bdy1.Controls.Add(
                             new System.Web.UI.LiteralControl("<script src=\"" + ResolveUrl("https://devs.artado.xyz/" + path) + "\"></script>"));
                }
            }

            //Custom CSS
            HttpCookie customcss = HttpContext.Current.Request.Cookies["CustomCSS"];
            if (customcss != null && customcss != null)
            {
                Page.Header.Controls.Add(
                         new System.Web.UI.LiteralControl("<style>" + Server.UrlDecode(customcss.Value) + "</style>"));
            }

            ////Custom JS
            //HttpCookie customjs = HttpContext.Current.Request.Cookies["CustomJS"];
            //if (customjs != null && customjs != null)
            //{
            //    Page.Header.Controls.Add(
            //             new System.Web.UI.LiteralControl("<script>" + Server.UrlDecode(customjs.Value) + "</script>"));
            //}
        }

        protected override void InitializeCulture()
        {
            Lang.Culture();

            base.InitializeCulture();
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Normal Themes
            HttpCookie cookie0 = HttpContext.Current.Request.Cookies["Theme"];
            if (cookie0 != null && cookie0.Value != null)
            {
                Page.Theme = cookie0.Value;
            }
            else
            {
                Page.Theme = "Default";
            }
        }

        protected void Basics_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings");
        }

        protected void Themes_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Themes");
        }

        protected void Extensions_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Extensions");
        }

        protected void Profiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Profiles");
        }

        protected void Proxy_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Proxy");
        }

        protected void Ads_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Ads");
        }

        protected void create_proxy_Click(object sender, EventArgs e)
        {

        }

        protected async void Add_Click(object sender, EventArgs e)
        {
            Uri url = new Uri(URL.Value);

            if (Allow.Checked && !CheckIfUrlExists(con, URL.Value))
            {
                string statusUrl = url.AbsoluteUri + "status";
                string status = await GetStatusAsync(statusUrl);

                string apiUrl = url.AbsoluteUri + "api?q=artado&number=10&source=google";
                bool apiResult = await CheckApiResponseAsync(apiUrl);

                if (status == "OK" && apiResult)
                {
                    string query = "INSERT INTO Proxies (Url, Status, LastChecked) VALUES (@Url, @Status, @LastChecked)";
                    SqlConnection connection = new SqlConnection(con);
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Url", url.AbsoluteUri);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@LastChecked", DateTime.Now);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            HttpCookie old = HttpContext.Current.Request.Cookies["Proxy"];
            if (old != null && old.Value != null)
            {
                old.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(old);
                Session.Abandon();

                HttpCookie cookie = new HttpCookie("Proxy");
                cookie.Value = url.AbsoluteUri;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Proxy");
                cookie.Value = url.AbsoluteUri;
                cookie.Expires = DateTime.UtcNow.AddDays(360);
                Response.Cookies.Add(cookie);
            }
        }

        static bool CheckIfUrlExists(string connectionString, string url)
        {
            Uri newurl = new Uri(url);
            string query = "SELECT * FROM Proxies WHERE URL = @Url";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Url", newurl.AbsoluteUri);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        static async Task<string> GetStatusAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    return content.Trim();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        static async Task<bool> CheckApiResponseAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();

                    // Check if the response is valid JSON
                    try
                    {
                        JToken.Parse(content);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}