using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class PlatformaController : Controller
    {
        // GET: Platforma
        public ActionResult Platforma()
        {
            {
                DataKnihovna.DAO.PlatformaDao platformaDao = new DataKnihovna.DAO.PlatformaDao();
                IList<DataKnihovna.Model.Platforma> hry = platformaDao.GetlAllAktiv();
            
                return View(hry);
            }
        }

    }
}
