using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace artadosearch
{
    public class Lang
    {
        public static void Culture()
        {
            string[] userLanguages = HttpContext.Current.Request.UserLanguages;
            string lang = userLanguages != null && userLanguages.Length > 0 ? userLanguages[0] : "en";
            HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
            if (cookielang != null && cookielang.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
            }
        }
    }
}