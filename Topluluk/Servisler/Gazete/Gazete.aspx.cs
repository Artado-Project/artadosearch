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
            SqlConnection baglanti = new SqlConnection(@"workstation id=ArtadoSearchTest.mssql.somee.com;packet size=4096;user id=artadosoft_SQLLogin_1;pwd=wxc1vmxdpy;data source=ArtadoSearchTest.mssql.somee.com;persist security info=False;initial catalog=ArtadoSearchTest");
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

                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;


                string kime = arama_çubugu.Text;
                string konu = "Teşekkürler! - Artado Search";
                string icerik = "Merhaba " + TextBox1.Text + "<br/>" + "<br/>" + "Gazetemize abone olduğun için teşekkürler. " + "<a href='http://artadosearch.com/Topluluk/Servisler/İletişim/İletişim.aspx'>Eğer abone olan değilsen bizimle iletişime geçip aboneliği iptal edebilirsin.</a>" + "<br/>" + "<br/>" + "İyi günler!" + "<br/>" + "Artado Software";

                sc.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("artadoyazilim@gmail.com");
                mail.To.Add(kime);
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.Send(mail);

                SmtpClient sc2 = new SmtpClient();
                sc2.Port = 587;
                sc2.Host = "smtp.gmail.com";
                sc2.EnableSsl = true;

                string kime2 = "artadoyazilim@gmail.com";
                string konu2 = "Abone Olundu! - Artado Search";
                string icerik2 = "Ad Soyad: " + TextBox1.Text + "<br>" + "E-posta: " + arama_çubugu.Text;

                sc2.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
                MailMessage mail2 = new MailMessage();
                mail2.From = new MailAddress("artadoyazilim@gmail.com");
                mail2.To.Add(kime2);
                mail2.Subject = konu2;
                mail2.IsBodyHtml = true;
                mail2.Body = icerik2;
                sc2.Send(mail2);
            }
            else
            {
                Sonuc.Text = "Üzgünüz bir sorun oluştu. Geliştirici ekibimize isteğiniz iletildi. ";
            }

        }
        catch(Exception hata)
        {
            Sonuc.Text = "Üzgünüz bir sorun oluştu. Geliştirici ekibimize isteğiniz iletildi. ";

            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            string kime = "artadoyazilim@gmail.com";
            string konu = "Ciddi Hata(Gazete) - Artado Search";
            string icerik = "Ciddi Hata Mesajı: " + hata +"<br>" + "Mail: " + arama_çubugu.Text;

            sc.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("artadoyazilim@gmail.com");
            mail.To.Add(kime);
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            sc.Send(mail);
        }
    }
}