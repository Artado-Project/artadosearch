using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topluluk_Artado_BizeKatılın : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Home");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/About");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Support");
    }
}