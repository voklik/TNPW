using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class UcetController : Controller
    {
        // GET: Ucet
   
        public ActionResult Registrace()
        {
         
            return View();
        }

        public ActionResult createUcet(Ucet novyUcet)
        {
            return RedirectToAction("LoginPage", "Login");
        }
        public ActionResult DetailUctu()
        {
            UcetDao ucetDao = new UcetDao();
            Ucet ucet = ucetDao.GetByLogin(User.Identity.Name);

            return View(ucet);
        }
        [HttpPost]
        public ActionResult nastaveniUctu()
        {
            UcetDao ucetDao = new UcetDao();
            Ucet ucet = ucetDao.GetByLogin(User.Identity.Name);

            return PartialView(ucet);
        }


        
            [HttpPost]
        public ActionResult registrovat(string log, string password, Ucet ucet)
        {
            if (!new UcetDao().IsThereLogin(log))
            {
                ucet.Login = log;
                ucet.Heslo=password;
           
           
            if (ModelState.IsValidField("Jmeno") && ModelState.IsValidField("Prijmeni") &&
                ModelState.IsValidField("Prezdivka") && ModelState.IsValidField("Adresa.Mesto") &&
                ModelState.IsValidField("Email") && ModelState.IsValidField("Telefon") && ModelState.IsValidField("Adresa.PSC") && ModelState.IsValidField("Adresa.UliceCP") &&
                ModelState.IsValidField("Adresa.Zeme")&& ModelState.IsValidField("Heslo") && ModelState.IsValidField("Login") )
            {
                ucet.RoleUzivatele = new RoleDao().GetById(1);
                ucet.Aktivovano = true;

                UcetDao ucetDao = new UcetDao();
                AdresaDao adresaDao = new AdresaDao();
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(password);
                Byte[] encodedBytes = md5.ComputeHash(originalBytes);

                String newpassword = BitConverter.ToString(encodedBytes);
                ucet.Heslo = newpassword;
                adresaDao.Create(ucet.Adresa);
                    ucetDao.Create(ucet);
           
                TempData["succes"] = "Registrace byla provedena. Nyní se můžete přihlásit";
                return RedirectToAction("LoginPage","Login");
            }
            else
            {
                TempData["zprava"] = "Registrace nebyla provedena. Něco se pokazilo.";
                return View("Registrace",ucet);
            }

            }
            else
            {
                TempData["zprava"] = "Tento login už je v eshopu používán";
                return View("Registrace", ucet);
            }
            //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult Edit(Ucet ucet)
        {
            ucet.RoleUzivatele = new RoleDao().GetById(ucet.RoleUzivatele.Id);

            if (ModelState.IsValidField("Jmeno") && ModelState.IsValidField("Prijmeni") &&
                ModelState.IsValidField("Prezdivka") && ModelState.IsValidField("Adresa.Mesto") &&
                ModelState.IsValidField("Email") && ModelState.IsValidField("Telefon") && ModelState.IsValidField("Adresa.PSC") && ModelState.IsValidField("Adresa.UliceCP") &&
                ModelState.IsValidField("Adresa.Zeme") && ModelState.IsValidField("Heslo") && ModelState.IsValidField("Login"))
            {
                UcetDao ucetDao=new UcetDao();
                AdresaDao adresaDao = new AdresaDao();
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(ucet.Heslo);
                Byte[] encodedBytes = md5.ComputeHash(originalBytes);

                String newpassword = BitConverter.ToString(encodedBytes);
                ucet.Heslo = newpassword;
                ucetDao.Update(ucet);
                adresaDao.Update(ucet.Adresa);
                TempData["zprava"] = "Editace byla provedena";
                return RedirectToAction("DetailUctu");
            }
            else
            {
                TempData["zprava"] = "Editace nebyla provedena. Něco se pokazilo.";
                return RedirectToAction("DetailUctu");
            }
           
            //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult prehledObjednavek()
        {
            UcetDao ucetDao = new UcetDao();
            Ucet ucet = ucetDao.GetByLogin(User.Identity.Name);
            ObjednavkaDao objednavkaDao = new ObjednavkaDao();
            IList<Objednavka> objednavky = objednavkaDao.GetByUzivatel(ucet.Id);
            ucet.Objednavky = objednavky;


            return PartialView(objednavky);
        }
        [HttpPost]
        public ActionResult getPolozky(int objednavka)
        {
            PolozkaObjednavkaDao polozkaObjednavkaDao = new PolozkaObjednavkaDao();
            IList<PolozkaObjednavka> polozky = polozkaObjednavkaDao.getbyObjednavka(objednavka);
            Objednavka obj = new ObjednavkaDao().GetById(objednavka);
            ViewBag.stav = obj.Stav.Id;
            ViewBag.id = objednavka;
            return PartialView(polozky);
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
            TempData["zprava"] = "Byla poslána žádost o storno. Pokud Objednávka nebyla už odeslána, tak pracovník vyřídí Váš požadavek.";
            return JavaScript("location.reload(true)");
            //return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult zmenaHesla( string pasOld, string pasNew, string pasNewNew)
        {
            UcetDao ucetDao = new UcetDao();
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(pasOld);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            pasOld = BitConverter.ToString(encodedBytes);
            if (pasNew== pasNewNew)
            {
                try
                {

              
              
                Ucet ucet = ucetDao.GetByLoginAndPassword(User.Identity.Name, pasOld);
                if (ucet.Heslo==pasOld)
                {
                     md5 = new MD5CryptoServiceProvider();
                     originalBytes = ASCIIEncoding.Default.GetBytes(pasNew);
                     encodedBytes = md5.ComputeHash(originalBytes);

                    String newpassword = BitConverter.ToString(encodedBytes);
                    ucet.Heslo = newpassword;
                  
                    ucetDao.Update(ucet);
                        TempData["zprava"] = "Změna hesla byla provedena.";
                    return RedirectToAction("DetailUctu");
                }
                    }
                 catch (Exception e)
                {
                    TempData["zprava"] = "Staré heslo nesouhlasí";
                    return RedirectToAction("DetailUctu");
                }

            }
            TempData["zprava"] = "Změna hesla nebyla provede. Nové heslo a potvrzení nového hesla není stejné";
            return RedirectToAction("DetailUctu");
        }


    }
}