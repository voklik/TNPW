using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
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
                IList<DataKnihovna.Model.Vydavatel> hry = vydavatelDao.GetlAllAktiv();

                return View(hry);
            }
        }

       







    }
}