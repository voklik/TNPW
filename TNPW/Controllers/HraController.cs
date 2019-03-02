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
    public class HraController : Controller
    {
        // GET: Hra
        public ActionResult Hra()
        {
            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            IList<DataKnihovna.Model.Hra> hry = hryDao.GetlAll();
        
            return View(hry);
        }
        public ActionResult DetailHry(int id)
        {
            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            DataKnihovna.Model.Hra hra = hryDao.GetById(id);
           
            return View(hra);
        }
        public ActionResult NovaHra()
        {
            PlatformaDao platformaDao = new PlatformaDao();
            IList<Platforma> platformy = platformaDao.GetlAll();

            VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAll();
            ViewBag.platformy = platformy;
            ViewBag.vydavatele = vydavatele;
           // ViewBag.Id = new SelectList(platformy, "Id", "Nazev")

           // ViewBag.platformy = new SelectList(platformy, "Id", "Nazev");
           // ViewBag.vydavatele = new SelectList(vydavatele, "Id", "Nazev");


            return View();
        }
        [HttpPost]
        public ActionResult Add(Hra hra,string _platforma, string _vydavatel, HttpPostedFileBase obrazek)
        {
            PlatformaDao platformaDao = new PlatformaDao();
          VydavatelDao vydavateleDao = new VydavatelDao();
          Vydavatel vyd = vydavateleDao.GetById(int.Parse(_vydavatel));
          Platforma plat = platformaDao.GetById(int.Parse(_platforma));
          hra.Vydavatel = vyd;
          hra.Platforma = plat;
            if (ModelState.IsValid)
            { 
          //  DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
           // hryDao.Create(hra);
            return RedirectToAction("Hra");
              }
            else
            {
                return View("NovaHra", hra);
            }
        }

    }
    
}