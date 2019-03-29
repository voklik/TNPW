using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TNPW.Areas.Administrativa.Controllers
{
   
    [Authorize(Roles = "pracovnik, admin")]
 
    public class HomeController : Controller
    {
        // GET: Administrativa/Home
        public ActionResult Index()
        {
            return View();
        }
 
    }
}