using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class VydavatelController : Controller
    {
        // GET: Vydavatel
        public ActionResult Vydavatel()
        {
            {
                DataKnihovna.DAO.VydavatelDao vydavatelDao = new DataKnihovna.DAO.VydavatelDao();
                IList<DataKnihovna.Model.Vydavatel> hry = vydavatelDao.GetlAll();

                return View(hry);
            }
        }

        public ActionResult NovyVydavatel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add( Vydavatel vydavatel)
        {
            DataKnihovna.DAO.VydavatelDao vydavatelDao = new DataKnihovna.DAO.VydavatelDao();
       
            if (ModelState.IsValid)
            {

                vydavatelDao.Create(vydavatel);
                return RedirectToAction("Vydavatel");
            }
            else
            {
                return View("NovyVydavatel", vydavatel);
            }
        }

    }
}