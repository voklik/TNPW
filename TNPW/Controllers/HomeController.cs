using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
      //      return View();
      return RedirectToAction("Hra", "Hra");
        }
        public ActionResult error404()
        {
            return View();
        }
        public ActionResult kontakt()
        {
            return View();
        }
    }
}