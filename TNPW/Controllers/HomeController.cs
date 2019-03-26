using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
      
            //UcetDao ucetDao = new UcetDao();
            //AdresaDao adresaDao= new AdresaDao();
            //DopravaMoznostDao dopravaMoznostDao=new DopravaMoznostDao();
            //KombinaceMoznostiDao kombinaceMoznostiDao = new KombinaceMoznostiDao();

            //PlatetbniMoznostDao platetbniMoznostDao = new PlatetbniMoznostDao();
      
            //PolozkaObjednavkaDao polozkaObjednavkaDao=new PolozkaObjednavkaDao();
            //StavDao stavDao=new StavDao();

            //IList<Ucet> ucet = ucetDao.GetlAll();
            //IList<Adresa> adresa = adresaDao.GetlAll();
            //IList<DopravaMoznost> doprava = dopravaMoznostDao.GetlAll();
            //IList<PlatetbniMoznost> platba = platetbniMoznostDao.GetlAll();

            //IList<KombinaceMoznosti> kombinace = kombinaceMoznostiDao.GetlAll();

            //IList<PolozkaObjednavka> polozkaObjednavka = polozkaObjednavkaDao.GetlAll();
            //IList<Stav> stav = stavDao.GetlAll();
            //PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();
            //IList<PolozkaKosik> polozkaKosik = polozkaKosikDao.GetlAll();

            return View();
        }
    }
}