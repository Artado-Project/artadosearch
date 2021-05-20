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
    string con = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString();
    string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        string akış = Request.QueryString["akış"];
        string keşfet = Request.QueryString["keşfet"];

        if (akış == "true")
        {
            Akış.Visible = true;
            Keşfet.Visible = false;
        }

        if (keşfet == "true")
        {
            Akış.Visible = false;
            Keşfet.Visible = true;
        }

        SqlConnection baglanti = new SqlConnection(con);

        SqlDataAdapter adp = new SqlDataAdapter("select *, Post from arda.Posts order by PostID desc", baglanti);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        SqlDataAdapter dadp = new SqlDataAdapter("select * from arda.Discover order by PostID desc", baglanti);
        DataTable ddt = new DataTable();
        dadp.Fill(ddt);
        Repeater2.DataSource = ddt;
        Repeater2.DataBind();
        baglanti.Close();

        if (Session["kullanici"] != null)
        {
            Mesaj.Visible = true;
            Label6.Text = "Hoşgeldin " + Session["kullanici"];
            GirişPanel.Visible = false;
        }
        else
        {
            GirişPanel.Visible = true;
            Mesaj.Visible = false;
        }

        if (GirişPanel.Visible == true)
        {
            Post.Visible = false;
        }
        else
        {
            Post.Visible = true;
        }

        Giriş.Visible = false;
        Kayıt.Visible = false;
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
                SqlConnection baglantiistek = new SqlConnection(admin);
                if (baglantiistek.State == ConnectionState.Closed)
                    baglantiistek.Open();
                string istek = "insert into Posts(Username, Post) values (@Username,@Post)";
                SqlCommand komut = new SqlCommand(istek, baglantiistek);
                komut.Parameters.AddWithValue("@Username", "Blank_");
                komut.Parameters.AddWithValue("@Post", TextBox1.Text);
                komut.ExecuteNonQuery();
                baglantiistek.Close();

                Response.Redirect("/BlankApp?akış=true");
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://www.artadosearch.com/search?i=" + TextBox3.Text + "&theme=Modern");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Giriş.Visible = true;
        Kayıt.Visible = false;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Giriş.Visible = false;
        Kayıt.Visible = true;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection baglanti = new SqlConnection(admin);
            SqlCommand komut = new SqlCommand("select * from arda.Users", baglanti);
            komut.Parameters.AddWithValue("@Username", Username.Text);
            komut.Parameters.AddWithValue("@Password", Şifre.Text);
            baglanti.Open();
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Session.Add("kullanici", Username.Text);
                Mesaj.Visible = true;
                Label6.Text = "Hoşgeldin " + Session["kullanici"];
                GirişPanel.Visible = false;
                Panel1.Visible = true;
                Giriş.Visible = false;
                Kayıt.Visible = false;
            }
            else
            {
                Label7.Text = "Giriş Başarısız";
            }
            baglanti.Close();
        }
        catch
        {
            Label7.Text = "Giriş Başarısız";
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection baglantiistek = new SqlConnection(admin);
            if (baglantiistek.State == ConnectionState.Closed)
                baglantiistek.Open();
            string istek = "insert into Users(Username, Password) values (@Username,@Password)";
            SqlCommand komut = new SqlCommand(istek, baglantiistek);
            komut.Parameters.AddWithValue("@Username", TextBox2.Text);
            komut.Parameters.AddWithValue("@Password", TextBox4.Text);
            komut.ExecuteNonQuery();
            baglantiistek.Close();

            Session.Add("kullanici", TextBox2.Text);
            Mesaj.Visible = true;
            Label6.Text = "Hoşgeldin " + Session["kullanici"];
            GirişPanel.Visible = false;
            Panel1.Visible = true;
            Giriş.Visible = false;
            Kayıt.Visible = false;
        }
        catch
        {
            Label7.Text = "Bir sorun oluştu.";
        }
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

                Response.Redirect("/BlankApp?keşfet=true");
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
}