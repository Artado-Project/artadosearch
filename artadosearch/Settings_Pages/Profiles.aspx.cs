using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace artadosearch.Settings_Pages
{
    public partial class Profiles : System.Web.UI.Page
    {
        //Connection Strings
        string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();

        //Passwords
        string api_pass = Configs.api_pass;
        string pass = Configs.enc_pass;
        string api = Configs.api_url;

        protected void Page_Load(object sender, EventArgs e)
        {
            Basics.Attributes.Add("class", "sidebar-item");
            Themes_Button.Attributes.Add("class", "sidebar-item");
            Extensions.Attributes.Add("class", "sidebar-item");
            Profiles_Button.Attributes.Add("class", "sidebar-item active");

            create_profile.Visible = false;
            profilename.Visible = false;
            err.Visible = false;

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

            if (!IsPostBack)
            {
                HttpCookie id = HttpContext.Current.Request.Cookies["id"];
                HttpCookie profile_id = HttpContext.Current.Request.Cookies["anonid"];

                if (id != null && id.Value != null)
                {
                    HttpCookie deviceid = HttpContext.Current.Request.Cookies["device"];
                    string key = EncryptClass.Encrypt(Request.Browser.Browser + Request.UserHostAddress + deviceid.Value, pass);

                    string pure_id = EncryptClass.Decrypt(id.Value, key);
                    SqlDataAdapter adp = new SqlDataAdapter("select * from Profiles where userid='" + pure_id + "'", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    profiles_list.DataSource = dt;
                    profiles_list.DataBind();
                }
                else if (profile_id != null && profile_id.Value != null)
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select * from Profiles where userid='" + profile_id.Value + "'", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    profiles_list.DataSource = dt;
                    profiles_list.DataBind();
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

        protected void Profiles_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Settings/Profiles");
        }

        protected void create_profile_Click(object sender, EventArgs e)
        {
            if(profilename.Value != string.Empty)
            {
                HttpCookie icon = HttpContext.Current.Request.Cookies["Icon"];
                HttpCookie customicon = HttpContext.Current.Request.Cookies["CustomIcon"];
                HttpCookie customtheme = HttpContext.Current.Request.Cookies["CustomTheme"];
                HttpCookie customcss = HttpContext.Current.Request.Cookies["CustomCSS"];
                HttpCookie ext = HttpContext.Current.Request.Cookies["Extension"];
                HttpCookie customjs = HttpContext.Current.Request.Cookies["CustomJS"];
                HttpCookie img = HttpContext.Current.Request.Cookies["background"];
                HttpCookie categories = HttpContext.Current.Request.Cookies["Categories"];
                HttpCookie id = HttpContext.Current.Request.Cookies["id"];
                HttpCookie anonid = HttpContext.Current.Request.Cookies["anonid"];

                SqlConnection connection = new SqlConnection(con);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string istek = "insert into Profiles(profile_id, icon, custom_icon, theme, custom_themes, custom_css, extensions, custom_js, background_image, categories, profile_name, userid) values (@profile_id, @icon, @custom_icon, @theme, @custom_themes, @custom_css, @extensions, @custom_js, @background_image, @categories, @profile_name, @userid)";
                SqlCommand cmd = new SqlCommand(istek, connection);
                cmd.Parameters.AddWithValue("@profile_id", Guid.NewGuid().ToString());
                //Icon
                if (icon != null)
                    cmd.Parameters.AddWithValue("@icon", icon.Value);
                else
                    cmd.Parameters.AddWithValue("@icon", DBNull.Value);
                //Custom Icon
                if (customicon != null)
                    cmd.Parameters.AddWithValue("@custom_icon", customicon.Value);
                else
                    cmd.Parameters.AddWithValue("@custom_icon", DBNull.Value);
                //Theme
                cmd.Parameters.AddWithValue("@theme", Page.Theme);
                //Custom Theme
                if (customtheme != null)
                    cmd.Parameters.AddWithValue("@custom_themes", customtheme.Values.ToString());
                else
                    cmd.Parameters.AddWithValue("@custom_themes", DBNull.Value);
                //Custom CSS
                if (customcss != null)
                    cmd.Parameters.AddWithValue("@custom_css", customcss.Value.ToString());
                else
                    cmd.Parameters.AddWithValue("@custom_css", DBNull.Value);
                //Extensions
                if (ext != null)
                    cmd.Parameters.AddWithValue("@extensions", ext.Values.ToString());
                else
                    cmd.Parameters.AddWithValue("@extensions", DBNull.Value);
                //Custom JS
                if (customjs != null)
                    cmd.Parameters.AddWithValue("@custom_js", customjs.Value.ToString());
                else
                    cmd.Parameters.AddWithValue("@custom_js", DBNull.Value);
                //Background
                if (img != null)
                    cmd.Parameters.AddWithValue("@background_image", img.Value.ToString());
                else
                    cmd.Parameters.AddWithValue("@background_image", DBNull.Value);
                //Categories
                if (categories != null)
                    cmd.Parameters.AddWithValue("@categories", categories.Value.ToString());
                else
                    cmd.Parameters.AddWithValue("@categories", DBNull.Value);
                //Profile Name
                cmd.Parameters.AddWithValue("@profile_name", profilename.Value.ToString());
                //User ID
                if (id != null)
                {
                    HttpCookie deviceid = HttpContext.Current.Request.Cookies["device"];
                    string key = EncryptClass.Encrypt(Request.Browser.Browser + Request.UserHostAddress + deviceid.Value, pass);
                    string pure_id = EncryptClass.Decrypt(id.Value, key);
                    cmd.Parameters.AddWithValue("@userid", pure_id);
                }
                else if (anonid != null)
                    cmd.Parameters.AddWithValue("@userid", anonid.Value.ToString());
                else
                {
                    HttpCookie httpCookie = new HttpCookie("anonid");
                    httpCookie.Value = Guid.NewGuid().ToString();
                    httpCookie.Expires = DateTime.UtcNow.AddDays(360);
                    Response.Cookies.Add(httpCookie);
                    cmd.Parameters.AddWithValue("@userid", httpCookie.Value.ToString());
                }
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                err.Visible = true;
            }
        }

        protected void openprofile_Click(object sender, EventArgs e)
        {
            openprofile.Visible = false;
            create_profile.Visible = true;
            profilename.Visible = true;
        }

        protected void sync_Click(object sender, EventArgs e)
        {
            HttpCookie anonid = HttpContext.Current.Request.Cookies["anonid"];
            HttpCookie id = HttpContext.Current.Request.Cookies["id"];
            try
            {
                if (id != null && id.Value != null && anonid != null && anonid.Value != null)
                {
                    HttpCookie deviceid = HttpContext.Current.Request.Cookies["device"];
                    string key = EncryptClass.Encrypt(Request.Browser.Browser + Request.UserHostAddress + deviceid.Value, pass);

                    string pure_id = EncryptClass.Decrypt(id.Value, key);
                    ArtadoSql.Update("userid", pure_id, "Profiles", "userid", anonid.Value, con);

                    anonid.Expires = DateTime.UtcNow.AddDays(-1);
                    Response.Cookies.Add(anonid);
                    Session.Abandon();
                }
                else
                {
                    Response.Redirect("https://myacc.artado.xyz/?name=" + api);
                }
            }
            catch
            {
                Response.Redirect("https://myacc.artado.xyz/?name=" + api);
            }
        }
    }
}