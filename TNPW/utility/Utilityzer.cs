using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace TNPW.utility
{
    public class Utilityzer
    {
        public static int DefaultCountPerPage = 10;

    

        public static string getCookieValue(string strKey)
        {
            if (HttpContext.Current.Response.Cookies[strKey] != null && HttpContext.Current.Response.Cookies[strKey].Value + "" != "")
            {
                return HttpContext.Current.Response.Cookies[strKey].Value;
            }
            else if (HttpContext.Current.Request.Cookies[strKey] != null)
            {
                HttpContext.Current.Response.Cookies[strKey].Value = HttpContext.Current.Request.Cookies[strKey].Value;
                return HttpContext.Current.Request.Cookies[strKey].Value;
            }
            else
            {
                return "";
            }
        }


    }
}