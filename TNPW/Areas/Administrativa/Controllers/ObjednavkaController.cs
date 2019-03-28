using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Areas.Administrativa.Controllers
{
    public class ObjednavkaController : Controller
    {
        // GET: Administrativa/Objednavka
        public ActionResult Objednavky(int? _page, int? _itemsOnPage, bool? vse)
        {


            int celkem;
            bool _vse = vse.HasValue ? vse.Value : false;
            int itemsOnPage = _itemsOnPage.HasValue ? _itemsOnPage.Value : TNPW.utility.Utilityzer.DefaultCountPerPage; ;
            int page = _page.HasValue ? _page.Value : 1;
            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            IList<Objednavka> Objednavka = objednavkaDao.getPaged(itemsOnPage, page, out celkem, _vse);
            ViewBag.pages = (int)Math.Ceiling((double)celkem / (double)itemsOnPage);
            ViewBag.soucasna = page;
            ViewBag.vse = vse;
            ViewBag.perPage = itemsOnPage;
            ViewBag.celkem = celkem;

            if (Request.IsAjaxRequest())
            {
                return PartialView("ObjednavkyAjax", Objednavka);
            }

            return View(Objednavka);
        }

        public ActionResult DetailObjednavky(int id)
        {
            PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();

            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            Objednavka objednavka = objednavkaDao.GetById(id);
            StavDao stavDao = new StavDao();
            


            objednavka.Polozky = polozkaObjednavkaDao.getbyObjednavka(objednavka.Id);

            return View(objednavka);
        }
        [HttpPost]
        public ActionResult PridatPolozku(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult EditObjednavky(int id)
        {

            ViewBag.stavy = new StavDao().getMezi(false, 1, 7);
            ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
            ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            Objednavka objednavka = objednavkaDao.GetById(id);
            return View(objednavka);
        }
        [HttpPost]
        public ActionResult edit(Objednavka objednavka)
        {
            //PlatetbniMoznostDao platetbniMoznostDao= new PlatetbniMoznostDao();
            //objednavka.Platba = platetbniMoznostDao.GetById(objednavka.Platba.Id);
            //objednavka.Stav = new StavDao().GetById(objednavka.Stav.Id);
            // objednavka.Doprava = new DopravaMoznostDao().GetById(objednavka.Doprava.Id);

            //if (ModelState.IsValid)
            if (ModelState.IsValidField("CenaDopravy") && ModelState.IsValidField("CenaPlatby") && ModelState.IsValidField("CenaCelkem") && ModelState.IsValidField("Adresa.Mesto") && ModelState.IsValidField("Adresa.PSC") && ModelState.IsValidField("Adresa.UliceCP") && ModelState.IsValidField("Adresa.Zeme"))
            {
                ObjednavkaDao objednavkaDao = new ObjednavkaDao();
                AdresaDao adresaDao = new AdresaDao();
                adresaDao.Update(objednavka.Adresa);

                objednavkaDao.Update(objednavka);
                return RedirectToAction("DetailObjednavky", new { id = objednavka.Id });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.stavy = new StavDao().getMezi(false, 1, 7);
                ViewBag.platby = new PlatetbniMoznostDao().getAktiv(false);
                ViewBag.dopravy = new DopravaMoznostDao().getAktiv(false);
                return View("EditObjednavky",objednavka);
            }
         
        }
        public ActionResult EditPolozky(int id)
        {

            ViewBag.stavy = new StavDao().getMezi(false,8,12);
            PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();
            PolozkaObjednavka polozka = polozkaObjednavkaDao.GetById(id);
            return View(polozka);
        }

        [HttpPost]
        public ActionResult editPolozka(PolozkaObjednavka polozka)
        {
            if (ModelState.IsValid)
            {
                PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();

                polozkaObjednavkaDao.Update(polozka);
                return RedirectToAction("DetailObjednavky", new { id = polozka.ObjednavkaID });
            }
            else
            {
                ViewBag.stavy = new StavDao().getMezi(false, 8, 12);
                return View("EditPolozky",polozka);
            }

        }
        [HttpPost]
        public ActionResult SearchProPolozku(string nazev,int? id)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.SearchName(nazev);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            ViewBag.objednavkaid = id;
            return PartialView("PridatPolozkuAjax", ucty);
        }
        [HttpPost]
        public ActionResult addPolozku(int idhra ,int idobjednavka)
        {

            PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();
            PolozkaObjednavka polozka = new PolozkaObjednavka();
            GameDao gameDao = new GameDao();
            Hra hra = gameDao.GetById(idhra);
            polozka.Hra = hra;
            polozka.Mnozstvi=1;
            polozka.ObjednavkaID = idobjednavka;
            polozka.TehdejsiCena = hra.aktualniCenasDPH();
            polozka.Stav = new StavDao().GetById(8);
            polozka.Aktivovano = true;
            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            Objednavka objednavka = objednavkaDao.GetById(idobjednavka);
           polozkaObjednavkaDao.Create(polozka);


            objednavka.Polozky = polozkaObjednavkaDao.getbyObjednavka(objednavka.Id);
            objednavka.prepocet();

            objednavkaDao.Update(objednavka);
            return RedirectToAction("DetailObjednavky", new { id = objednavka.Id });
            //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult deletePolozku(int id)
        {

            PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();
            PolozkaObjednavka polozka = polozkaObjednavkaDao.GetById(id);
            ObjednavkaDao objednavkaDao=new ObjednavkaDao();
            Objednavka objednavka = objednavkaDao.GetById(polozka.ObjednavkaID);
            StavDao stavDao = new StavDao();
            polozka.Stav = stavDao.GetById(9);
            polozkaObjednavkaDao.Update(polozka);
           

            objednavka.Polozky = polozkaObjednavkaDao.getbyObjednavka(objednavka.Id);
 objednavka.prepocet();

            objednavkaDao.Update(objednavka);
            return JavaScript("location.reload(true)");
           //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult prepocet(int id)
        {

            PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();
        
            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            Objednavka objednavka = objednavkaDao.GetById(id);
            StavDao stavDao = new StavDao();
         


            objednavka.Polozky = polozkaObjednavkaDao.getbyObjednavka(objednavka.Id);
            objednavka.prepocet();

            objednavkaDao.Update(objednavka);
            return JavaScript("location.reload(true)");
            //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }



        [HttpPost]
        public ActionResult searchObjednavkaCislo(string id)
        {
            int celkem;
            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            IList<Objednavka> objednavkas = objednavkaDao.SearchObjednavku(id, out celkem);
            celkem = objednavkas.Count;
            ViewBag.celkem = celkem;
            return View("Objednavky", objednavkas);
        }
    }
}