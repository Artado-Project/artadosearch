using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Servisler_Home_Support : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://kreosus.com/artadosoft");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Newspaper");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/AddResult");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://twitter.com/intent/tweet?text=Reklamsız,%20Yerli%20ve%20Sade%20Tasarımlı%20Arama%20Motoru%20Artado%20Search%27ı%20şimdi%20deneyin!%20Kişisel%20verilerinize%20saygılı%20ve%20sizi%20takip%20etmez.%20http://artadosearch.com%20%23ArtadoİleArat");
    }
}