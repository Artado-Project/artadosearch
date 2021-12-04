using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Blank_Blank : System.Web.UI.Page
{
    //Check connection string in web.config
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();
    string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin2"].ConnectionString.ToString();

    HttpCookie old = HttpContext.Current.Request.Cookies["id"];

    protected void Page_Load(object sender, EventArgs e)
    {
        Keşfet.Visible = false;

        string mode = Request.QueryString["mode"];
        if (mode == "şartlar")
        {
            Akış.Visible = false;
            Keşfet.Visible = false;
            Kullanıcı.Visible = true;
        }
        else if (mode == "test")
        {
            testtxt.Text = "Hoşgeldin Test Kullanıcısı!";
        }
        else
        {
            Akış.Visible = false;
            Keşfet.Visible = false;
            Kullanıcı.Visible = false;
            Kullanıcı.Visible = false;
        }

        SqlConnection baglanti = new SqlConnection(con);

        SqlDataAdapter adp = new SqlDataAdapter("select *, Post from dbo.Posts order by PostID desc", baglanti);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        HttpCookie id = HttpContext.Current.Request.Cookies["id"];
        if (id != null && id.Value != null)
        {
            ProfilePic.Visible = true;
            string sorgu2 = "SELECT Image FROM dbo.Users where PassID='" + id.Value + "' ";
            string image;
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            baglanti.Open();
            image = (string)komut2.ExecuteScalar();
            baglanti.Close();
            ProfilePic.ImageUrl = "/images/" + image;
            GirişPanel.Visible = false;
        }
        else
        {
            ProfilePic.Visible = false;
            GirişPanel.Visible = true;
        }

        if (GirişPanel.Visible == true)
        {
            Post.Visible = false;
        }
        else
        {
            Post.Visible = true;
        }
    }

    protected override void InitializeCulture()
    {
        HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
        if (cookielang != null && cookielang.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
        }
        else
        {
            System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string kulturDilKod = kultur.TwoLetterISOLanguageName;
        }

        base.InitializeCulture();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            Label3.Text = "Boş gönderi atamazsın!";
        }
        else
        {
            try
            {
                SqlConnection baglanti = new SqlConnection(admin);
                string sorgu2 = "SELECT UserID FROM dbo.Users where PassID='" + old.Value + "' ";
                int username;
                SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                username = (int)komut2.ExecuteScalar();

                string sorgu24 = "SELECT Username FROM dbo.Users where PassID='" + old.Value + "' ";
                SqlCommand komut42 = new SqlCommand(sorgu24, baglanti);
                string username2 = (string)komut42.ExecuteScalar();

                string istek = "insert into Posts(Username, Date, Comments, Likes, Post) values (@Username, @Date, @Comments, @Likes, @Post)";
                SqlCommand cmd = new SqlCommand(istek, baglanti);
                cmd.Parameters.AddWithValue("@Username", username2);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToLongDateString());
                cmd.Parameters.AddWithValue("@Answers", 0);
                cmd.Parameters.AddWithValue("@Post", TextBox1.Text);
                cmd.ExecuteNonQuery();
                if (baglanti.State.ToString() == "Open")
                {
                    baglanti.Close();
                    SqlConnection.ClearPool(baglanti);
                }
                Response.Redirect("/BlankApp");
            }
            catch
            {
                Label3.Text = "Üzgünüz bir hata oluştu. Tekrar deneyiniz.";
            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Account?mode=register&url=/BlankApp");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Akış.Visible = false;
        Keşfet.Visible = true;
        Kullanıcı.Visible = false;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Akış.Visible = true;
        Keşfet.Visible = false;
        Kullanıcı.Visible = false;
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text.Trim() == "")
        {
            Label8.Text = "Boş gönderi atamazsın!";
        }
        else
        {
            try
            {
                SqlConnection baglantiistek = new SqlConnection(admin);
                if (baglantiistek.State == ConnectionState.Closed)
                    baglantiistek.Open();
                string istek = "insert into Discover(Username, Post, Like1, Dislike) values (@Username,@Post,@Like1,@Dislike)";
                SqlCommand komut = new SqlCommand(istek, baglantiistek);
                komut.Parameters.AddWithValue("@Username", Session["kullanici"]);
                komut.Parameters.AddWithValue("@Post", TextBox5.Text);
                komut.Parameters.AddWithValue("@Like1", 0);
                komut.Parameters.AddWithValue("@Dislike", 0);
                komut.ExecuteNonQuery();
                baglantiistek.Close();
            }
            catch
            {
                Label8.Text = "Üzgünüz bir hata oluştu. Tekrar deneyiniz.";
            }
        }
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        Akış.Visible = false;
        Keşfet.Visible = false;
        Kullanıcı.Visible = true;
    }

    protected void ProfilePic_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Account?mode=settings");
    }
}