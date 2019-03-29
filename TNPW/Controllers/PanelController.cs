using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            IList<Platforma> platformy = platformaDao.GetlAllAktiv();
        
            VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAllAktiv();

            ViewBag.platformy = platformy;
          ViewBag.vydavatele =vydavatele;
            return PartialView();
           
        }

        public ActionResult HorniPanel()
        {
            if(User.Identity.Name != "")
            {

           
                PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();

                IList<PolozkaKosik> polozkyKosiks = polozkaKosikDao.GetByUzivatel(new UcetDao().GetUser(User.Identity.Name).Id);
                Kosik kosik = new Kosik(polozkyKosiks);
                if (kosik.Polozky.Count !=0)
                {
                    double cena = 0.0;
                    foreach (PolozkaKosik model in kosik.Polozky)
                    {
                        cena += model.Mnozstvi * model.Hra.aktualniCenasDPH();
                    }
                    ViewBag.kosik = "V košíku je zboží za cenu " + kosik.Celkem + " Kč";
                }
                else
                {
                    ViewBag.kosik = "Košík je prázdný";
                }
               

            }

          

                return PartialView();
        }
        public ActionResult DolniPanel()
        {
            return PartialView();
        }
    }
}