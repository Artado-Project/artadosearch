using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.ServiceModel.PeerResolvers;
using System.Net.Mail;
using CsQuery.ExtensionMethods;
using HtmlAgilityPack;
using System.Web.Routing;
using System.Web.Mvc;
using System.Text;

public partial class AramaSonuc : System.Web.UI.Page
{

    private static string theme2;
    protected void Page_Load(object sender, EventArgs e)
    {


        Stopwatch watch = new Stopwatch();
        watch.Start();

        string aranan = Request.QueryString["i"];
        SqlConnection baglanti = new SqlConnection(@"workstation id=ArtadoSearchTest.mssql.somee.com;packet size=4096;user id=artadosoft_SQLLogin_1;pwd=wxc1vmxdpy;data source=ArtadoSearchTest.mssql.somee.com;persist security info=False;initial catalog=ArtadoSearchTest");

        //Web Arama
        SqlDataAdapter adp = new SqlDataAdapter("select *, Link from Sonuclar where Title Like '%" + aranan + "%'", baglanti);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        rptAramaSonuclari.DataSource = dt;
        rptAramaSonuclari.DataBind();

        //Sözlük Arama
        SqlDataAdapter adpsoz = new SqlDataAdapter("select *, Anlam from Sözlük where Kelime Like '%" + aranan + "%'", baglanti);
        DataTable dtsoz = new DataTable();
        adpsoz.Fill(dtsoz); 
        sözlüksonuc.DataSource = dtsoz;
        sözlüksonuc.DataBind();


        arama_çubugu2.Attributes.Add("placeholder", aranan);
        Label1.Text = "Sonuçların Bulunma Süresi: " + watch.Elapsed.TotalSeconds + " saniye";


        //Arananı veritabanına kaydediyor
        SqlConnection baglantiistek = new SqlConnection(@"workstation id = ArtadoSearchTest.mssql.somee.com; packet size = 4096; user id = artadosoft_SQLLogin_1; pwd = wxc1vmxdpy; data source = ArtadoSearchTest.mssql.somee.com; persist security info = False; initial catalog = ArtadoSearchTest");
        if (baglantiistek.State == ConnectionState.Closed)
            baglantiistek.Open();
        string istek = "insert into Arananlar(Kelime) values (@Kelime)";
        SqlCommand komut = new SqlCommand(istek, baglantiistek);
        komut.Parameters.AddWithValue("@Kelime", aranan);
        komut.ExecuteNonQuery();

        try
        {
            string link = "https://www.bing.com/search?q=" + aranan;

            HttpWebRequest istekbing = (HttpWebRequest)WebRequest.Create(link);
            // Google'dan gelen cevabı alıyoruz
            HttpWebResponse cevap = (HttpWebResponse)istekbing.GetResponse();
            // Google'dan gelen cevabı encode edereken karakter sorununun
            // önüne geçmek için gelen cevabın karaktersetine göre ayarlıyoruz.
            Encoding cevapKodlama = Encoding.GetEncoding(cevap.CharacterSet);
            // Google cevabını özel encode ayarıyla birikte okuyoruz.
            StreamReader akis = new StreamReader(cevap.GetResponseStream(), cevapKodlama);

            string html = akis.ReadToEnd();

            // Bu kısımda Google'dan aldığımız sonucu html parse ediyoruz.
            // Html parse ederken C SHARP HtmkAgilityPack API'sinden yararlanıyoruz.
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            HtmlNodeCollection linkler = doc.DocumentNode.SelectNodes("//*[@id='b_results']/li[1]/h2");

            int i = 1;
            foreach (HtmlNode linkt in linkler)
            {
                EkBaşlık.Text += (i++) + " - " + (linkt.InnerHtml + "<br />");

            }
        }
        catch (Exception hata)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            string kime = "artadoyazilim@gmail.com";
            string konu = "Ciddi Hata - Artado Search";
            string icerik = "Ciddi Hata Mesajı: " + hata;

            sc.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("artadoyazilim@gmail.com");
            mail.To.Add(kime);
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
        }


        theme2 = Request.QueryString["theme"];

        int aaron;
        aaron = aranan.Trim().ToLower().IndexOf("aaron swartz");

        int billgates;
        billgates = aranan.Trim().ToLower().IndexOf("bill gates");
        int ataturk;
        ataturk = aranan.Trim().ToLower().IndexOf("mustafa kemal atatürk");

        int dolar;
        dolar = aranan.Trim().ToLower().IndexOf("dolar");

        if (aranan.ToLower() == "aaron swartz".Trim() || aaron >= 0 || aranan.ToLower() == "bill gates".Trim() || billgates >= 0 || aranan.ToLower() == "dolar" || dolar >= 0 || aranan.ToLower() == "mustafa kemal atatürk".Trim() || ataturk >= 0 || aranan.ToLower() == "atatürk".Trim() || aranan.ToLower() == "mustafa kemal".Trim() || aranan.ToLower() == "mustafa kamal ataturk".Trim() || aranan.ToLower() == "mustafa kamal".Trim())
        {
            //Bill Gates
            if (aranan.ToLower() == "bill gates".Trim() || billgates >= 0)
            {
                Panel1.Visible = true;
                Ad.Text = "Bill Gates";
                Meslek.Text = "Microsoft kurucularından, Amerikalı yazar, yazılımcı, girişimci, yatırımcı ve iş adamı";
                Image2.ImageUrl = "/ee5d7c41.jpg";
                Doğum.Text = "1955-";
            }

            //Aaron
            else if (aranan.ToLower() == "aaron swartz".Trim() || aaron >= 0)
            {
                Panel1.Visible = true;
                Image2.ImageUrl = "/indir.jpg";
            }

            //Dolar
            else if (aranan.ToLower() == "dolar" || dolar >= 0)
            {
                Panel1.Visible = true;
                Image2.ImageUrl = "/dolar.jpg";
                Ad.Text = "Amerikan Doları/TL";
                Meslek.Text = "1 Dolar";

                double Dolar;
                DataSet dsDovizKur;
                dsDovizKur = new DataSet();
                dsDovizKur.ReadXml(@"http://www.tcmb.gov.tr/kurlar/today.xml");
                DataRow dr = dsDovizKur.Tables[1].Rows[0];
                Dolar = Convert.ToDouble(dr[4].ToString().Replace('.', ','));
                dr = dsDovizKur.Tables[1].Rows[14];

                Doğum.Text = Dolar.ToString();
            }

            //Atatürk
            if (aranan.ToLower() == "mustafa kemal atatürk".Trim() || ataturk >= 0 || aranan.ToLower() == "atatürk".Trim() || aranan.ToLower() == "mustafa kemal".Trim() || aranan.ToLower() == "mustafa kamal ataturk".Trim() || aranan.ToLower() == "mustafa kamal".Trim())
            {
                Panel1.Visible = true;
                Image2.ImageUrl = "/ataturk.jpg";

                Ad.Text = "Mustafa Kemal Atatürk";
                Meslek.Text = "Türkiye Cumhuriyeti kurucusu, ululararası anlayış, işbirliği, barış yolunda çaba göstermiş üstün kişi";
                Doğum.Text = "1881-193∞";
            }

        }
        else
        {
            Panel1.Visible = false;
        }

        //Google Araması
        int google;
        google = aranan.ToLower().IndexOf(".g");

        if (google >= 0)
        {
            string yenikelime = aranan.Substring(3, aranan.Length - 3);
            Response.Redirect("https://www.google.com/search?hl=tr&q=" + yenikelime);
        }

        //Reddit Araması
        int reddit;
        reddit = aranan.ToLower().IndexOf(".r");

        if (reddit >= 0)
        {
            string subreddit = aranan.Substring(3, aranan.Length - 3);
            Response.Redirect("https://www.reddit.com/r/" + subreddit);
        }
        
        
        //Instagram Araması
        int insta;
        insta = aranan.ToLower().IndexOf(".i");

        if (insta >= 0)
        {
            string iprofile = aranan.Substring(3, aranan.Length - 3); 
            Response.Redirect("https://www.instagram.com/" + iprofile);
        }


        //Youtube Araması
        int yt;
        yt = aranan.ToLower().IndexOf(".yt");

        if (yt >= 0)
        {
            string ytarama = aranan.Substring(3, aranan.Length - 3);
            Response.Redirect("https://www.youtube.com/results?search_query=" + ytarama);
        }

        watch.Stop();
        WebArama.Visible = true;
        EkSonuclar.Visible = true;
        GörselArama.Visible = false;
        SözlükArama.Visible = false;
        MüzikArama.Visible = false;
    }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        theme2 = (string)Session["theme"];
        if (theme2 == "Modern" || theme2 == "Sanatçı")
        {
            Page.Theme = "Klasik";
        }
        else 
        { 
            Page.Theme = theme2;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AramaSonuc.aspx?arananKelime=" + arama_çubugu2.Text.Trim());
        Response.Redirect("AramaSonuc.aspx?theme=" + theme2);
    }



    protected void rptAramaSonuclari_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Response.Redirect("url.aspx");
    } 

    protected void arama_çubugu2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Gönder_Click(object sender, EventArgs e)
    {
        try
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            string kime = "artadoyazilim@gmail.com";
            string konu = "Geri Bildirim - ArtadoSearch";
            string icerik = "E-posta: " + Mail.Text + "<br>" + "Geri Bildirim:" + Deneyim.InnerText;

            sc.Credentials = new NetworkCredential("artadoyazilim@gmail.com", "artado14252023");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(Mail.Text);
            mail.To.Add(kime);
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            sc.Send(mail);

            Sonuc.Text = "Başarılı";
        }
        catch
        {
            Sonuc.Text = "Üzgünüz bir sorun oluştu.";
        }
    }

    protected void Image1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("/Anasayfa");
    }

    protected void Web_Click(object sender, EventArgs e)
    {
        WebArama.Visible = true;
        EkSonuclar.Visible = true;
        GörselArama.Visible = false;
        SözlükArama.Visible = false;
        MüzikArama.Visible = false;
    }

    protected void Görsel_Click(object sender, EventArgs e)
    {
        GörselArama.Visible = true;
        WebArama.Visible = false;
        EkSonuclar.Visible = false;
        MüzikArama.Visible = false;
        SözlükArama.Visible = false;
    }

    protected void Sözlük_Click(object sender, EventArgs e)
    {
        SözlükArama.Visible = true;
        GörselArama.Visible = false;
        WebArama.Visible = false;
        EkSonuclar.Visible = false;
        MüzikArama.Visible = false;
    }

    protected void Müzik_Click(object sender, EventArgs e)
    {
        SözlükArama.Visible = false;
        GörselArama.Visible = false;
        WebArama.Visible = false;
        EkSonuclar.Visible = false;
        MüzikArama.Visible = true;
    }
}