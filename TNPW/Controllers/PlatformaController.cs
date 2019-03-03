using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class PlatformaController : Controller
    {
        // GET: Platforma
        public ActionResult Platforma()
        {
            {
                DataKnihovna.DAO.PlatformaDao platformaDao = new DataKnihovna.DAO.PlatformaDao();
                IList<DataKnihovna.Model.Platforma> hry = platformaDao.GetlAll();

                return View(hry);
            }
        }
        public ActionResult NovaPlatforma()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Platforma platforma)
        {
            DataKnihovna.DAO.PlatformaDao platformaDao = new DataKnihovna.DAO.PlatformaDao();

            if (ModelState.IsValid)
            {

                platformaDao.Create(platforma);
                return RedirectToAction("Platforma");
            }
            else
            {
                return View("NovyVydavatel", platforma);
            }
        }

    }
}
