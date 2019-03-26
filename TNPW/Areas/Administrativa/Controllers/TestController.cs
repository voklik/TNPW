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
    public class TestController : Controller
    {
        // GET: Administrativa/Test
        public ActionResult Index()
        {
            GameDao gameDao = new GameDao();
            IList<Hra> hry = gameDao.GetlAll();

            List<String> chyby = new List<String>();

            foreach (Hra hra in hry)
            {
                if (hra.Ikona==null)
                {
                    { chyby.Add(string.Format("hra s ID:{0} Nazvem: {1} nemá nastavený obrázek", hra.Id, hra.Nazev)); }

                }
                else if(!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory+ "/uploads/hry/" + hra.Ikona))
                    {chyby.Add(string.Format("hra s ID:{0} Nazvem: {1} má obrázek {2}, který nebyl nalezn v {3}",hra.Id,hra.Nazev,hra.Ikona,("~/uploads/hry/" + hra.Ikona))); }
            }
            return View(chyby);
        }
    }
}