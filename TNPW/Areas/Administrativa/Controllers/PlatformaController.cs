using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using  DataKnihovna.Model;

namespace TNPW.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "pracovnik, admin")]
    public class PlatformaController : Controller
    {
        // GET: Platforma
        public ActionResult Platforma()
        {
            {
                DataKnihovna.DAO.PlatformaDao platformaDao = new DataKnihovna.DAO.PlatformaDao();
                IList<DataKnihovna.Model.Platforma> platformy = platformaDao.GetlAll();
               
                return View(platformy);
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
            platforma.Pocet = 0;
            if (ModelState.IsValid)
            {

                platformaDao.Create(platforma);
                return RedirectToAction("Platforma");
            }
            else
            {
                return View("NovaPlatforma", platforma);
            }
        }
        [HttpPost]
        public ActionResult aktivace(String _id)
        {

            int id = int.Parse(_id);
            PlatformaDao vydavatelDao = new PlatformaDao();
            Platforma plat = vydavatelDao.GetById(id);

            if (plat.Aktivovano)
                plat.Aktivovano = false;
            else
                plat.Aktivovano = true;


            vydavatelDao.Update(plat);
            return RedirectToAction("Platforma");

        }

    }
}
