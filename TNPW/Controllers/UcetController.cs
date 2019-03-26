using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class UcetController : Controller
    {
        // GET: Ucet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrace()
        {
            String originalPassword = "Michal";
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            String newpassword= BitConverter.ToString(encodedBytes);
            ViewBag.heslo = newpassword;
            return View();
        }

        public ActionResult createUcet(Ucet novyUcet)
        {
            return RedirectToAction("LoginPage", "Login");
        }
    }
}