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
    }
    public string link;

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            string admin = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            SqlConnection baglanti = new SqlConnection(admin);

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            string titleveri = "insert into Eklenenler(Eklenen) values (@Eklenen)";
            SqlCommand komut = new SqlCommand(titleveri, baglanti);
            komut.Parameters.AddWithValue("@Eklenen", TextBox3.Text);
            komut.ExecuteNonQuery();
            SonucMesajı.Text = "Teşekkür ederiz. Sonuç onaylandıktan sonra gösterilecektir.";


        }
        catch(Exception hata)
        {
            SonucMesajı.Text = "Upss! Bir hata oldu. Merak etme! Bunu düzeltiyoruz.";
        }
    }


   
}


