using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna;
using DataKnihovna.DAO;
using DataKnihovna.Model;
namespace TNPW.Areas.Administrativa.Controllers
{
    [ChildActionOnly]
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Panel()
        {
           
            return PartialView();

        }
        public ActionResult HorniPanel()
        {
            return PartialView();
        }
        public ActionResult DolniPanel()
        {
            return PartialView();
        }
    }
}