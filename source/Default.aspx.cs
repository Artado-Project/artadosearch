using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (theme == "Karanlık")
        {
            Panel2.Visible = true;
            Label2.Visible = true;
        }
        else
        {
            Panel2.Visible = false;
            Label2.Visible = false;
        }

        if (theme == "Klasik")
        {
            Panel2.Visible = true;
            Label2.Visible = true;
        }
        else
        {
            Panel2.Visible = false;
            Label2.Visible = false;
        }


        Kontrol.Visible = false;

    }



    private static string theme;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        theme = (string)Session["theme"];
        if ((theme != null) && (theme.Length != 0))
        {
            Page.Theme = theme;
            DropDownList1.Text = theme;
        }
        else
        {
            Page.Theme = "Modern";
        }

        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("/arama?i=" + arama_çubugu.Text.Trim());

        Response.Redirect("/arama?theme=" + theme);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["theme"] = DropDownList1.SelectedItem.Value;
        Page.Response.Redirect(Page.Request.Url.ToString());
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Visible = true;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Kontrol.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Mail");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("/DestekOl");
    }

    protected void Voice_Click(object sender, ImageClickEventArgs e)
    {

    }
}


