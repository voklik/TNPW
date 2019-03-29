using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace TNPW.utility
{
    public class Utilityzer
    {
        public static int DefaultCountPerPage = 10;


        public static Boolean SendingMail()
        {
            string From = "email";
            string To = "email";
            string Subject = "nazdar";
            string Body = "nazdar";
            try
            {
                MailMessage m = new MailMessage(From, To);
                m.Subject = Subject;
                m.Body = Body;
                m.IsBodyHtml = true;
                m.From = new MailAddress(From);

                m.To.Add(new MailAddress(To));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";

                NetworkCredential authinfo = new NetworkCredential("login" ,"heslo");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = authinfo;
                smtp.Send(m);
                return true;




            }
            catch (Exception ex)
            {
                return false;
            }
        }

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