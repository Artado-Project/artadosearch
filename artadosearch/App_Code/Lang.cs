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
            System.Globalization.CultureInfo cul = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string lang = cul.TwoLetterISOLanguageName;
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