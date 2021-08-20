using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Home_Manifest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        Response.Redirect("https://twitter.com/intent/tweet?text=Artado%20Manifestosunu%20destekliyorum!%20%23Artado%C4%B0leArat%20https://www.artadosearch.com/Manifesto");
    }
}