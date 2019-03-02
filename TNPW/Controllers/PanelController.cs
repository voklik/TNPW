using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna;
using DataKnihovna.DAO;
using DataKnihovna.Model;
namespace TNPW.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Panel()
        {
            PlatformaDao platformaDao = new PlatformaDao();
            IList<Platforma> platformy = platformaDao.GetlAll();

             VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAll();
            ViewBag.platformy = platformy;
          ViewBag.vydavatele =vydavatele;
            return PartialView();
           
        }
    }
}