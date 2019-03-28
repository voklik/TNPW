using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;
using TNPW.utility;

namespace TNPW.Areas.Administrativa.Controllers
{
  
    [Authorize(Roles = "pracovnik, admin")]
    public class UcetController : Controller
    {
    public ActionResult Uzivatele(int? _page, int? _itemsOnPage, bool? vse, int? showRole)
        {
            

            int celkem;
            bool _vse= vse.HasValue ? vse.Value : true;
            int itemsOnPage = _itemsOnPage.HasValue ? _itemsOnPage.Value : Utilityzer.DefaultCountPerPage;
            int page = _page.HasValue ? _page.Value : 1;
            int showRol= showRole.HasValue ? showRole.Value : 1;//    Boolean jenomAktivni = _jenomAktivni.HasValue ? _jenomAktivni.Value : true;
            UcetDao ucetDao = new UcetDao();
            IList<Ucet> ucty = ucetDao.getPagedByRole(itemsOnPage, showRol, page, out celkem, _vse);
            ViewBag.pages = (int) Math.Ceiling((double) celkem / (double) itemsOnPage);
            ViewBag.soucasna = page;
            ViewBag.vse = vse;
            ViewBag.perPage = itemsOnPage;
            ViewBag.celkem = celkem;
            ViewBag.showRole = showRol;
            if (Request.IsAjaxRequest())
            {
                return PartialView("UzivateleAjax", ucty);
            }

            return View(ucty);
        }
    public ActionResult Edit(Ucet ucet)
    {
        ucet.RoleUzivatele = new RoleDao().GetById(ucet.RoleUzivatele.Id);

        if (ModelState.IsValidField("Jmeno") && ModelState.IsValidField("Prijmeni") &&
            ModelState.IsValidField("Prezdivka") && ModelState.IsValidField("Adresa.Mesto") &&
            ModelState.IsValidField("Email") && ModelState.IsValidField("Telefon") && ModelState.IsValidField("Adresa.PSC") && ModelState.IsValidField("Adresa.UliceCP") &&
            ModelState.IsValidField("Adresa.Zeme") && ModelState.IsValidField("Heslo") && ModelState.IsValidField("Login"))
        {
            UcetDao ucetDao = new UcetDao();
            AdresaDao adresaDao = new AdresaDao();
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(ucet.Heslo);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            String newpassword = BitConverter.ToString(encodedBytes);
            ucet.Heslo = newpassword;
            ucetDao.Update(ucet);
            adresaDao.Update(ucet.Adresa);
            TempData["zprava"] = "Editace byla provedena";
            return RedirectToAction("DetailUzivatele", new { id = ucet.Id });
            }
        else
        {
            TempData["zprava"] = "Editace nebyla provedena. Něco se pokazilo.";
            return RedirectToAction("ed",new{id=ucet.Id});
        }

        //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
    }
        public ActionResult DetailUzivatele(int id)
    {

        UcetDao ucetDao = new UcetDao();
        Ucet ucet = ucetDao.GetById(id);
     
        ObjednavkaDao objednavkaDao = new ObjednavkaDao();
        IList<Objednavka> objednavky = objednavkaDao.GetByUzivatel(ucet.Id);
        ucet.Objednavky = objednavky;
        foreach (Objednavka objednavka in ucet.Objednavky)
        {
          PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();
            IList<PolozkaObjednavka> polozky = polozkaObjednavkaDao.getbyObjednavka(objednavka.Id);
            objednavka.Polozky = polozky;
        }
;      

        return View(ucet);
    }

    [HttpPost]
        public ActionResult aktivace(int? _page, int? _itemsOnPage, bool? vse, int? showRole,string _id)
        {

        int id = int.Parse(_id);
        UcetDao ucetdao = new UcetDao();
        Ucet ucet = ucetdao.GetById(id);

        if (ucet.Aktivovano)
            ucet.Aktivovano = false;
        else
            ucet.Aktivovano = true;


        ucetdao.Update(ucet);
    
        return RedirectToAction("Uzivatele", new { _page = _page, vse = vse, _itemsOnPage = _itemsOnPage, showRole = showRole });

        }
        [HttpPost]
        public ActionResult aktivace2( string _id)
        {

            int id = int.Parse(_id);
            UcetDao ucetdao = new UcetDao();
            Ucet ucet = ucetdao.GetById(id);

            if (ucet.Aktivovano)
                ucet.Aktivovano = false;
            else
                ucet.Aktivovano = true;


            ucetdao.Update(ucet);

            return RedirectToAction("DetailUzivatele", new {id=id});

        }
        [HttpPost]
        public ActionResult Search(string jmeno, string login, string prezdivka, string prijmeni )
        {
            int celkem;
            UcetDao ucetDao = new UcetDao();
            IList<Ucet> ucty = ucetDao.Search(jmeno, login, prezdivka, prijmeni,out celkem);
           
            ViewBag.celkem = celkem;
            return View("Uzivatele",ucty);
        }
        [HttpPost]
        public JsonResult searchUcetbyLogin(string query)
        {

            UcetDao ucetDao = new UcetDao();
            IList<Ucet> ucty = ucetDao.SearchLogin(query);
            List<String> seznam = (from Ucet u in ucty select u.Login).ToList();
            return Json(seznam, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult searchUcetbyPrijmeni(string query)
        {

            UcetDao ucetDao = new UcetDao();
            IList<Ucet> ucty = ucetDao.SearchPrijmeni(query);
            List<String> seznam = (from Ucet u in ucty select u.Prijmeni).ToList();
            return Json(seznam, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult searchUcetbyPrezdivka(string query)
        {

            UcetDao ucetDao = new UcetDao();
            IList<Ucet> ucty = ucetDao.SearchPrezdivka(query);
            List<String> seznam = (from Ucet u in ucty select u.Prezdivka).ToList();
            return Json(seznam, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult searchUcetbyJmeno(string query)
        {

            UcetDao ucetDao = new UcetDao();
            IList<Ucet> ucty = ucetDao.SearchJmeno(query);
            List<String> seznam = (from Ucet u in ucty select u.Jmeno).ToList();
            return Json(seznam, JsonRequestBehavior.AllowGet);
        }


        public ActionResult nastaveniUctu(int id)
        {
            Ucet ucet = new UcetDao().GetById(id);


            ViewBag.role = new RoleDao().GetlAll();
            return View(ucet);
        }
    }




}