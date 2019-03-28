using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "pracovnik, admin")]
    public class KombinaceMoznostiController : Controller
    {
        // GET: Administrativa/KombinaceMoznosti
        public ActionResult KombinaceMoznosti()
        {
            KombinaceMoznostiDao kombinaceMoznostiDao = new KombinaceMoznostiDao();
            IList<KombinaceMoznosti> kombinace = kombinaceMoznostiDao.GetlAll();
            if (Request.IsAjaxRequest())
            {
                return PartialView("KombinaceMoznostiAjax", kombinace);
            }
            return View(kombinace);
        }
    public ActionResult PlatebMoznosti()
        {
            PlatetbniMoznostDao platetbniMoznostDao = new PlatetbniMoznostDao();
            IList<PlatetbniMoznost> platba = platetbniMoznostDao.GetlAll();
            if (Request.IsAjaxRequest())
            {
                return PartialView("PlatetbniMoznostAjax", platba);
            }
            return View(platba);
        }
        public ActionResult DopravaMoznosti()
        {
            DopravaMoznostDao dopravaMoznostDao = new DopravaMoznostDao();
         
            IList<DopravaMoznost> doprava = dopravaMoznostDao.GetlAll();
            if (Request.IsAjaxRequest())
            {
                return PartialView("DopravaMoznostiAjax", doprava);
            }
            return View(doprava);
        }

        [HttpPost]
        public ActionResult smazatKM(String _id)
        {

            int id = int.Parse(_id);
            KombinaceMoznostiDao dao = new KombinaceMoznostiDao();
            KombinaceMoznosti model = dao.GetById(id);
            dao.Delete(model);

            return RedirectToAction("KombinaceMoznosti");

        }
        [HttpPost]
        public ActionResult editPM(String _id)
        {

            int id = int.Parse(_id);
            PlatetbniMoznostDao dao = new PlatetbniMoznostDao();
            PlatetbniMoznost model = dao.GetById(id);
            return View(model);

        }
        public ActionResult editDM(String _id)
        {

            int id = int.Parse(_id);
            DopravaMoznostDao dao = new DopravaMoznostDao();
            DopravaMoznost model = dao.GetById(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult editKM(String _id)
        {
         
            ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
            ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
            int id = int.Parse(_id);
            KombinaceMoznostiDao dao = new KombinaceMoznostiDao();
            KombinaceMoznosti model = dao.GetById(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult editatPM(PlatetbniMoznost model)
        {
            if (ModelState.IsValidField("Cena") && ModelState.IsValidField("Popis") && ModelState.IsValidField("Nazev"))
            {
                PlatetbniMoznostDao platetbniMoznostDao = new PlatetbniMoznostDao();

                platetbniMoznostDao.Update(model);
                return RedirectToAction("PlatebMoznosti");
            }
            else
            {
                return View("editPM",model);
            }



        }
        [HttpPost]
        public ActionResult editatDM(DopravaMoznost model)
        {

            if (ModelState.IsValidField("Cena") && ModelState.IsValidField("Popis") && ModelState.IsValidField("Nazev"))
            {
                DopravaMoznostDao dopravaMoznostDao = new DopravaMoznostDao();
                dopravaMoznostDao.Update(model);
                return RedirectToAction("DopravaMoznosti");
            }
            else
            {
                return View("editDM", model);
            }


        }
        [HttpPost]
        public ActionResult editatKM(KombinaceMoznosti model)
        {
            if (ModelState.IsValidField("CenaDoprava") && ModelState.IsValidField("CenaPlatebni") && ModelState.IsValidField("CenaObjednavky"))
            {

                KombinaceMoznostiDao dao = new KombinaceMoznostiDao();
                if (dao.IsKombinaceQuery(model.DopravaMoznost.Id, model.PlatbaMoznost.Id, false))
                {
                    ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
                    ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
                    TempData["error"] = "Takováto kombinace už existuje !!!! Nemohou být dvě";
                    return View("editKM", model);

                }
                dao.Update(model);
                return RedirectToAction("KombinaceMoznosti");
            }
            else
            {
                ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
                ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
                return View("editKM", model);
            }


        }
        [HttpPost]
        public ActionResult aktivaceKM(String _id)
        {

            int id = int.Parse(_id);
            KombinaceMoznostiDao dao = new KombinaceMoznostiDao();
            KombinaceMoznosti model = dao.GetById(id);

            if (model.Aktivovano)
                model.Aktivovano = false;
            else
                model.Aktivovano = true;


            dao.Update(model);
            return RedirectToAction("KombinaceMoznosti");

        }
        [HttpPost]
        public ActionResult aktivacePM(String _id)
        {

            int id = int.Parse(_id);
            PlatetbniMoznostDao dao = new PlatetbniMoznostDao();
            PlatetbniMoznost model = dao.GetById(id);

            if (model.Aktivovano)
                model.Aktivovano = false;
            else
                model.Aktivovano = true;


            dao.Update(model);
            return RedirectToAction("PlatebMoznosti");

        }
        [HttpPost]
        public ActionResult aktivaceDM(String _id)
        {

            int id = int.Parse(_id);
            DopravaMoznostDao dao = new DopravaMoznostDao();
            DopravaMoznost model = dao.GetById(id);

            if (model.Aktivovano)
                model.Aktivovano = false;
            else
                model.Aktivovano = true;


            dao.Update(model);
            return RedirectToAction("DopravaMoznosti");

        }









        public ActionResult novaPM()
        {

            return View();

        }
        public ActionResult novaDM()
        {

            return View();

        }
        public ActionResult novaKM()
        {

            ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
            ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
       
            return View();

        }
        [HttpPost]
        public ActionResult addPM(PlatetbniMoznost model)
        {

            if (ModelState.IsValidField("Cena") && ModelState.IsValidField("Popis") && ModelState.IsValidField("Nazev"))
            {
                PlatetbniMoznostDao platetbniMoznostDao = new PlatetbniMoznostDao();
                platetbniMoznostDao.Create(model);
                return RedirectToAction("PlatebMoznosti");
            }
            else
            {
                return View("novaPM",model);

            }


        }
        [HttpPost]
        public ActionResult addDM(DopravaMoznost model)
        {
            if (ModelState.IsValidField("Cena") && ModelState.IsValidField("Popis") && ModelState.IsValidField("Nazev") )
            {
              
                DopravaMoznostDao dopravaMoznostDao = new DopravaMoznostDao();
                dopravaMoznostDao.Create(model);
                return RedirectToAction("DopravaMoznosti");
            }
            else
            {
                return View("novaDM", model);

            }



        }
        [HttpPost]
        public ActionResult addKM(KombinaceMoznosti model)
        {
            if (ModelState.IsValidField("CenaDoprava") && ModelState.IsValidField("CenaPlatebni") && ModelState.IsValidField("CenaObjednavky"))
            {
              
                KombinaceMoznostiDao dao = new KombinaceMoznostiDao();
                if (dao.IsKombinaceQuery(model.DopravaMoznost.Id,model.PlatbaMoznost.Id,false))
                {
                    ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
                    ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
                    TempData["error"] = "Takováto kombinace už existuje !!!! Nemohou být dvě";
                    return View("novaKM", model);

                }
                dao.Create(model);
                return RedirectToAction("KombinaceMoznosti");
            }
            else
            {
                ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
                ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
              
                return View("novaKM", model);

            }

           

        }













    }

    
}