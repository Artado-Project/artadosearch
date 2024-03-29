﻿using System;
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
            SqlConnection connection = new SqlConnection(con);

            if (name == null)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where Genre='" + genre + "' and AppStatus='Approved' order by ID desc", connection);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where Genre='" + genre + "' and Name Like @q and AppStatus='Approved' order by ID desc", connection);
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
        
        // Get products by a specific developer
        public static void ProductsDev(Repeater DataProduct, string devid)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection connection = new SqlConnection(con);

            SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where DevID=" + devid + " and AppStatus='Approved' order by ID desc", connection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataProduct.DataSource = dt;
            DataProduct.DataBind();
        }

        //Get the info of the product
        public static string Info(string info, string product)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection connection = new SqlConnection(con);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand productinfo = new SqlCommand("select " + info + " from artadoco_admin.Products where ID='" + product + "'", connection);
            string reinfo = (string)productinfo.ExecuteScalar();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return reinfo;
        }
    }
}