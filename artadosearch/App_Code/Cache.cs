using Microsoft.Extensions.Caching.Memory;
using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace artadosearch
{
    public class Cache
    {
        //Cache results in DB
        static string con = System.Configuration.ConfigurationManager.ConnectionStrings["search"].ConnectionString.ToString();
        public static void Save(DataTable results, int p)
        {
            SqlConnection connection = new SqlConnection(con);
            foreach (DataRow row in results.Rows)
            {
                int ampIndex = row["URL"].ToString().IndexOf("&amp");
                int saIndex = row["URL"].ToString().IndexOf("&sa");
                string url = string.Empty;
                // Check if "&amp" was found
                if (ampIndex != -1 || saIndex != -1)
                {
                    if (ampIndex != -1)
                    {
                        url = row["URL"].ToString().Substring(0, ampIndex);
                    }
                    else if (saIndex != -1)
                    {
                        url = row["URL"].ToString().Substring(0, saIndex);
                    }
                }
                else
                {
                    url = row["URL"].ToString();
                }

                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cache WHERE URL=@URL", connection);
                cmd.Parameters.AddWithValue("@URL", url);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read() == false)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Cache (Title, URL, Description, Rank) VALUES (@Title, @URL, @Description, @Rank)", connection);

                    command.Parameters.AddWithValue("@Title", row["Title"]);
                    command.Parameters.AddWithValue("@URL", url);
                    command.Parameters.AddWithValue("@Description", row["Description"]);

                    int rank = 100 - p - results.Rows.IndexOf(row);
                    command.Parameters.AddWithValue("@Rank", rank);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Get the cache in the DB
        public static DataTable Get(string q)
        {
            //Setting Sql Connection
            SqlConnection connection = new SqlConnection(con);

            SqlDataAdapter adp;
            adp = new SqlDataAdapter("select TOP (10) * from Cache where (Title Like @q or Description Like @q) order by Rank desc", connection);
            adp.SelectCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@q",
                Value = "%" + q + "%",
            });
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //Cache in memory
        static System.Web.Caching.Cache _cache = HttpRuntime.Cache;

        public static async void CacheResultsInMemo(string query, string source, int currentPage, List<Result> all)
        {
            string cacheKey = string.Format("{0}_{1}_{2}", query, source, currentPage);
            List<Result> results = _cache[cacheKey] as List<Result>;

            if (results == null)
            {
                _cache.Insert(cacheKey, all, null, DateTime.Now.AddMinutes(120), System.Web.Caching.Cache.NoSlidingExpiration); // Cache for 2 hours
            }
        }

        public static List<Result> Get<T>(string cacheKey)
        {
            List<Result> results = _cache[cacheKey] as List<Result>;
            return results;
        }
    }
}