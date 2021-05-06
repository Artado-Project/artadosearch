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
        SqlConnection baglanti2 = new SqlConnection(@"workstation id=ArtadoSearchTest.mssql.somee.com;packet size=4096;user id=artadosoft_SQLLogin_1;pwd=wxc1vmxdpy;data source=ArtadoSearchTest.mssql.somee.com;persist security info=False;initial catalog=ArtadoSearchTest");
        string aramaID = Request.QueryString["Link"]; 
        SqlCommand cmd = new SqlCommand("select *, Link from Sonuclar where Link", baglanti2);
        Response.Redirect(aramaID);
    }
}