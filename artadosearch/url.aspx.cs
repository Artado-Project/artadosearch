using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection baglanti2 = new SqlConnection(@"Data Source=188.121.44.212;Initial Catalog=artado;Persist Security Info=True;User ID=arda;pwd=ardam1425;MultipleActiveResultSets=True");
        baglanti2.Open();
        string aramaID = Request.QueryString["Link"];
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti2;
        komut.CommandText = "update Sonuçlar set Rank+=5 where Link='" + aramaID + "'";
        komut.ExecuteNonQuery();
        Response.Redirect(aramaID);
    }
}