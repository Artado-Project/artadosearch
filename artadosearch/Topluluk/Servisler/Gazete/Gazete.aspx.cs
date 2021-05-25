using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Gazete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            SqlConnection baglanti = new SqlConnection(admin);
            int mailsembol;
            mailsembol = arama_çubugu.Text.IndexOf("@");
            if (arama_çubugu.Text.EndsWith(".com") || mailsembol >= 0)
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string mailekle = "insert into MailList(Mail) values (@Mail)";
                SqlCommand komut = new SqlCommand(mailekle, baglanti);
                komut.Parameters.AddWithValue("@Mail", arama_çubugu.Text);
                komut.ExecuteNonQuery();
                Sonuc.Text = "Abone olduğunuz için teşekkür ederiz.";
            }
            else
            {
                Sonuc.Text = "E-postanızı kontrol edin";
            }

        }
        catch (Exception hata)
        {
            Sonuc.Text = "<br/>" + "Üzgünüz bir sorun oluştu. Sorunu bize <a href='https://twitter.com/intent/tweet?text=Bir%20sorunum%20var!%20@ArtadoL%20Sorun:" + hata + "'>Twitter<a/> veya <a href='/İletişim'>başka platformlardan<a/> bildirebilirsiniz.";
        }
    }
}