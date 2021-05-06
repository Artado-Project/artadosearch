using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Home_Updates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Anasayfa_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ArtadoSoft/Anasayfa");
    }

    protected void Hakkımızda_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Hakkımızda");
    }

    protected void İletişim_Click(object sender, EventArgs e)
    {
        Response.Redirect("/İletişim");
    }

    protected void Blog_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Blog");
    }

    protected void DestekOl_Click(object sender, EventArgs e)
    {
        Response.Redirect("/DestekOl");
    }
}