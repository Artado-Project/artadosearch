using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Asistan_Anasayfa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://artadosearch.com");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Asistan/About");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Support");
    }
}