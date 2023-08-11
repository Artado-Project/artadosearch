using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace artadosearch
{
    public class ArtadoSql
    {
        //SQL SELECT command 
        public static string Select(string data, string table, string where, string there, string constring, string data_type)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //Get Infos
            string query = "SELECT " + data + " FROM " + table + " where " + where + "='" + there + "' ";
            cmd.CommandText = query;
            if (data_type == "string")
            {
                var info = (string)cmd.ExecuteScalar();
                con.Close();
                return info;
            }
            else
            {
                var info = (int)cmd.ExecuteScalar();
                con.Close();
                return "true";
            }
        }

        public static int SelectInt(string data, string table, string where, string there, string constring)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //Get Infos
            string query = "SELECT " + data + " FROM " + table + " where " + where + "='" + there + "' ";
            cmd.CommandText = query;
            var info = (int)cmd.ExecuteScalar();
            return info;
        }

        //SQL UPDATE command
        public static void Update(string data, string newdata, string table, string where, string there, string constring)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = constring;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //Update Infos
            string query = "update  " + table + " set " + data + "='" + newdata + "' where " + where + "='" + there + "'";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}