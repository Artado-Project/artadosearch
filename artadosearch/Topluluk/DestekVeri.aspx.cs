using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DestekVeri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sonuc1.Text = "";
        Sonuc2.Text = "";
        Sonuc3.Text = "";
    }

    protected void Anasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Home");
    }

    protected void Hakkımızda_Click(object sender, EventArgs e)
    {
        Response.Redirect("/About");
    }

    protected void İletişim_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Contact");
    }

    protected void Blog_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Forum");
    }

    protected void DestekOl_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Donate");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if(TextBox1.Text==null || TextBox1.Text == "")
            {
                Sonuc1.Text = "Lütfen geçerli bir bağlantı giriniz. Bağlantılar http:// veya https:// ile başlamalıdır!";
            }
            else if (TextBox1.Text.StartsWith("http"))
            {
                string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

                SqlConnection baglanti = new SqlConnection(admin);

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string titleveri = "insert into Eklenenler(Eklenen) values (@Eklenen)";
                SqlCommand komut = new SqlCommand(titleveri, baglanti);
                komut.Parameters.AddWithValue("@Eklenen", TextBox1.Text);
                komut.ExecuteNonQuery();
                Sonuc1.Text = "Teşekkür ederiz. Sonuç onaylandıktan sonra gösterilecektir.";
            }
            else
            {
                Sonuc1.Text = "Lütfen geçerli bir bağlantı giriniz. Bağlantılar http:// veya https:// ile başlamalıdır!";
            }
        }
        catch
        {
            Sonuc1.Text = "Upss! Bir hata oldu. Merak etme! Bunu düzeltiyoruz.";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            SqlConnection baglanti = new SqlConnection(admin);

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string titleveri = "insert into dbo.Sözlük(Kelime, Anlam, Tarih, Kullanıcı) values (@Kelime, @Anlam, @Tarih, @Kullanıcı)";
            SqlCommand komut = new SqlCommand(titleveri, baglanti);
            HttpCookie old = HttpContext.Current.Request.Cookies["id"];
            if (old != null && old.Value != null)
            {
                komut.Parameters.AddWithValue("@Kelime", TitleText.Text);
                komut.Parameters.AddWithValue("@Anlam", TextBox5.Text);
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now.ToLongDateString());
                komut.Parameters.AddWithValue("@Kullanıcı", old.Value);
                komut.ExecuteNonQuery();
            }
            else
            {
                komut.Parameters.AddWithValue("@Kelime", TitleText.Text);
                komut.Parameters.AddWithValue("@Anlam", TextBox5.Text);
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now.ToLongDateString());
                komut.Parameters.AddWithValue("@Kullanıcı", "Anonim");
                komut.ExecuteNonQuery();
            }
            Sonuc2.Text = "Teşekkür ederiz. Sonucunuz eklenmiştir.";
        }
        catch
        {
            Sonuc2.Text = "Upss! Bir hata oldu. Merak etme! Her şeyi düzgün yaptığından emin ol.";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            SqlConnection baglanti = new SqlConnection(admin);
            baglanti.Open();
            SqlCommand control = new SqlCommand("select * from dbo.Infos where InfoTitle='" + TextBox1.Text + "' and Lang='"+DropDownList1.SelectedValue+"'", baglanti);
            SqlDataReader reading = control.ExecuteReader();

            if (reading.Read())
            {
                Sonuc3.Text = "Bu sonuç zaten veri tabanında var.";
            }
            else
            {
                Sonuc3.Visible = true;
                string istek = "insert into dbo.Infos(InfoTitle, Info, InfoLink, Pic, Category, Link1Name, Link1, Link2Name, Link2, Link3Name, Link3, Lang, Onay) values (@InfoTitle, @Info, @InfoLink, @Pic, @Category, @Link1Name, @Link1, @Link2Name, @Link2, @Link3Name, @Link3, @Lang, @Onay)";
                SqlCommand cmd = new SqlCommand(istek, baglanti);
                cmd.Parameters.AddWithValue("@InfoTitle", TextBox2.Text);
                cmd.Parameters.AddWithValue("@InfoLink", TextBox8.Text);
                cmd.Parameters.AddWithValue("@Info", TextBox3.Text);
                cmd.Parameters.AddWithValue("@Pic", TextBox6.Text);
                cmd.Parameters.AddWithValue("@Category", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Link1Name", TextBox7.Text);
                cmd.Parameters.AddWithValue("@Link1", TextBox8.Text);
                cmd.Parameters.AddWithValue("@Link2Name", TextBox9.Text);
                cmd.Parameters.AddWithValue("@Link2", TextBox0.Text);
                cmd.Parameters.AddWithValue("@Link3Name", TextBox11.Text);
                cmd.Parameters.AddWithValue("@Link3", TextBox12.Text);
                cmd.Parameters.AddWithValue("@Lang", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@Onay", "Waiting");
                cmd.ExecuteNonQuery();
                Sonuc3.Text = "Başarılı";
            }
        }
        catch(Exception hata)
        {
            Sonuc3.Text = "Upss! Bir hata oldu. Merak etme! Her şeyi düzgün yaptığından emin ol." + hata;
        }
    }
}


