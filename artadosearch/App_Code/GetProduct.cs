using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;

namespace artadosearch
{
    public class GetProduct
    {//List all the products
        public static void Products(Repeater DataProduct, string genre, string name)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);

            if (name == null)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where Genre='" + genre + "' and AppStatus='Approved' order by ID desc", baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where Genre='" + genre + "' and Name Like @q and AppStatus='Approved' order by ID desc", baglanti);
                adp.SelectCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@q",
                    Value = "%" + name + "%",
                });
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();
            }
        }

        //Get the info of the product
        public static string Info(string info, string product)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand productinfo = new SqlCommand("select " + info + " from artadoco_admin.Products where ID='" + product + "'", baglanti);
            string reinfo = (string)productinfo.ExecuteScalar();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            return reinfo;
        }
    }
}